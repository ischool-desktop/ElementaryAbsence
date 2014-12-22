using Campus.Windows;
using FISCA.Presentation;
using FISCA.UDT;
using K12.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FCode = Framework.Security.FeatureCodeAttribute;

namespace ElementaryAbsence
{
    [FCode("ElementaryAbsence.Detail", "1~6年級請假天數")]
    public partial class DetailForm : DetailContent
    {
        AccessHelper _A;
        List<AbsenceObj> _records;
        StudentRecord _student;
        BackgroundWorker _BW;
        bool _pending;
        ChangeListener _listener;

        public DetailForm()
        {
            InitializeComponent();
            Group = "一至六年級請假天數";

            _pending = false;

            _A = new AccessHelper();
            _records = new List<AbsenceObj>();

            PrimaryKeyChanged += new EventHandler(StudentChanged);
            SaveButtonClick += new EventHandler(Save);

            _BW = new BackgroundWorker();
            _BW.DoWork += new DoWorkEventHandler(_BW_DoWork);
            _BW.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_BW_Completed);

            _listener = new ChangeListener();
            _listener.Add(new DataGridViewSource(dgv));
            _listener.StatusChanged += StatusChanged;
        }

        private void StatusChanged(object sender, ChangeEventArgs e)
        {
            SaveButtonVisible = e.Status == ValueStatus.Dirty;
        }

        private void _BW_Completed(object sender, RunWorkerCompletedEventArgs e)
        {
            SaveButtonVisible = false;

            _listener.SuspendListen();
            dgv.Rows.Clear();
            foreach (AbsenceObj obj in _records)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dgv, obj.SchoolYear, obj.Semester, obj.PersonalDays, obj.SickDays);
                dgv.Rows.Add(row);
            }

            _listener.Reset();
            _listener.ResumeListen();

            if (_pending)
            {
                _pending = false;
                _BW.RunWorkerAsync();
            }
        }

        private void _BW_DoWork(object sender, DoWorkEventArgs e)
        {
            _student = K12.Data.Student.SelectByID(PrimaryKey);
            _records = _A.Select<AbsenceObj>("ref_student_id=" + _student.ID);
        }

        private void Save(object sender, EventArgs e)
        {
            dgv.EndEdit();

            bool pass = true;

            List<AbsenceObj> insert = new List<AbsenceObj>();
            List<string> check = new List<string>();

            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.IsNewRow)
                    continue;

                string str_schoolYear = row.Cells[colSchoolYear.Index].Value + "";
                string str_semester = row.Cells[colSemester.Index].Value + "";
                string str_personal = row.Cells[colPersonal.Index].Value + "";
                string str_sick = row.Cells[colSick.Index].Value + "";
                string key = str_schoolYear + "#" + str_semester;

                int sy;
                row.Cells[colSchoolYear.Index].ErrorText = string.Empty;
                if (!int.TryParse(str_schoolYear, out sy))
                {
                    row.Cells[colSchoolYear.Index].ErrorText = "學年度必須是整數數字";
                    pass = false;
                }

                int sm;
                row.Cells[colSemester.Index].ErrorText = string.Empty;
                if (!int.TryParse(str_semester, out sm))
                {
                    row.Cells[colSemester.Index].ErrorText = "學期必須是整數數字";
                    pass = false;
                }

                int p;
                int? pd = null;
                row.Cells[colPersonal.Index].ErrorText = string.Empty;
                if (!string.IsNullOrWhiteSpace(str_personal))
                {
                    if (int.TryParse(str_personal, out p))
                    {
                        pd = p;
                    }
                    else
                    {
                        row.Cells[colPersonal.Index].ErrorText = "事假必須是整數數字";
                        pass = false;
                    }
                }

                int s;
                int? sd = null;
                row.Cells[colSick.Index].ErrorText = string.Empty;
                if (!string.IsNullOrWhiteSpace(str_sick))
                {
                    if (int.TryParse(str_sick, out s))
                    {
                        sd = s;
                    }
                    else
                    {
                        row.Cells[colSick.Index].ErrorText = "病假必須是整數數字";
                        pass = false;
                    }
                }

                if (check.Contains(key))
                {
                    row.ErrorText = "學年度與學期的組合重覆";
                    pass = false;
                }
                check.Add(key);

                AbsenceObj obj = new AbsenceObj();
                obj.RefStudentId = int.Parse(_student.ID);
                obj.SchoolYear = sy;
                obj.Semester = sm;
                obj.PersonalDays = pd;
                obj.SickDays = sd;

                insert.Add(obj);
            }

            if (!pass)
                return;

            StringBuilder sb = new StringBuilder();
            if (_records.Count > 0)
            {
                sb.AppendLine("儲存前紀錄:");
                foreach (AbsenceObj obj in _records)
                {
                    sb.AppendLine(string.Format("學年度:{0} 學期:{1} 事假:{2} 病假:{3}", obj.SchoolYear, obj.Semester, obj.PersonalDays, obj.SickDays));
                }
                _A.DeletedValues(_records);
            }

            if (insert.Count > 0)
            {
                sb.AppendLine("儲存後紀錄:");
                foreach (AbsenceObj obj in insert)
                {
                    sb.AppendLine(string.Format("學年度:{0} 學期:{1} 事假:{2} 病假:{3}", obj.SchoolYear, obj.Semester, obj.PersonalDays, obj.SickDays));
                }
                _A.InsertValues(insert);
            }

            if (sb.Length > 0)
            {
                sb.Insert(0, string.Format("學生:{0} 學號:{1} \r\n", _student.Name, _student.StudentNumber));
                FISCA.LogAgent.ApplicationLog.Log("一至六年級請假天數", "編輯", sb.ToString());
            }

            StudentChanged(null, null);
        }

        private void StudentChanged(object sender, EventArgs e)
        {
            if (_BW.IsBusy)
                _pending = true;
            else
                _BW.RunWorkerAsync();
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgv.BeginEdit(true);
        }
    }
}
