using FISCA.Presentation.Controls;
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

namespace ElementaryAbsence
{
    public partial class MainForm : BaseForm
    {
        List<string> _ids;
        List<StudentRecord> _students;
        ClassRecord _class;
        int _schoolYear, _semester;
        AccessHelper _A;
        Dictionary<string, AbsenceObj> _abDic;

        public MainForm()
        {
            InitializeComponent();

            _A = new AccessHelper();
            _abDic = new Dictionary<string, AbsenceObj>();

            _class = K12.Data.Class.SelectByID(K12.Presentation.NLDPanels.Class.SelectedSource[0]);
            _students = K12.Data.Student.SelectByClassIDs(K12.Presentation.NLDPanels.Class.SelectedSource);
            _ids = _students.Select(x => x.ID).ToList();

            //班級名稱及老師姓名
            string teacher = _class.Teacher == null ? string.Empty : ":" + _class.Teacher.Name;
            lblClassName.Text = _class.Name + teacher;

            //預設學年度學期
            _schoolYear = int.Parse(K12.Data.School.DefaultSchoolYear);
            _semester = int.Parse(K12.Data.School.DefaultSemester);

            for (int i = -2; i <= 2; i++)
            {
                cboSchoolYear.Items.Add(_schoolYear + i);
            }

            cboSemester.Items.Add(1);
            cboSemester.Items.Add(2);

            cboSchoolYear.Text = _schoolYear + "";
            cboSemester.Text = _semester + "";

            //班級學生清單
            foreach (StudentRecord stu in _students)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dgv, stu.SeatNo, stu.Name, stu.StudentNumber);
                row.Tag = stu.ID;
                dgv.Rows.Add(row);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            GetDays();
        }

        private void GetDays()
        {
            this.Text = string.Format("請假天數輸入(學年度:{0} 學期:{1})", _schoolYear, _semester);

            _abDic.Clear();
            string str_ids = string.Join("','", _ids);
            str_ids = "'" + str_ids + "'";
            string sql = string.Format("ref_student_id in ({0}) and school_year={1} and semester={2}", str_ids, _schoolYear, _semester);

            //班級無學生不執行查詢
            if (_ids.Count > 0)
            {
                List<AbsenceObj> objs = _A.Select<AbsenceObj>(sql);
                foreach (AbsenceObj obj in objs)
                {
                    _abDic.Add(obj.RefStudentId + "", obj);
                }
            }

            //資料呈現
            foreach (DataGridViewRow row in dgv.Rows)
            {
                string id = row.Tag + "";
                if(_abDic.ContainsKey(id))
                {
                    row.Cells[colPersonal.Index].Value = _abDic[id].PersonalDays;
                    row.Cells[colSick.Index].Value = _abDic[id].SickDays;
                }
                else
                {
                    row.Cells[colPersonal.Index].Value = null;
                    row.Cells[colSick.Index].Value = null;
                }

                //紀錄
                row.Cells[colPersonal.Index].Tag = row.Cells[colPersonal.Index].Value;
                row.Cells[colSick.Index].Tag = row.Cells[colSick.Index].Value;
            }
        }

        private void cboSchoolYear_SelectedValueChanged(object sender, EventArgs e)
        {
            ValidateSchoolYear();
        }

        private void cboSemester_SelectedValueChanged(object sender, EventArgs e)
        {
            ValidateSemester();
        }

        private void cboSchoolYear_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ValidateSchoolYear();
            }
        }

        private void cboSemester_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ValidateSemester();
            }
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == colPersonal.Index || e.ColumnIndex == colSick.Index)
                dgv.BeginEdit(true);
        }

        private void dgv_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == colPersonal.Index || e.ColumnIndex == colSick.Index)
            {
                DataGridViewCell cell = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex];

                string value = cell.Value + "";

                cell.ErrorText = string.Empty;

                if (!string.IsNullOrWhiteSpace(value))
                {
                    int i;
                    if (!int.TryParse(cell.Value + "", out i))
                    {
                        cell.ErrorText = "請假天數請輸入數字";
                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (HasError())
            {
                MessageBox.Show("資料有誤,請確認後再儲存");
                return;
            }

            //分類需要新增,更新,刪除的資料
            List<AbsenceObj> insert = new List<AbsenceObj>();
            List<AbsenceObj> update = new List<AbsenceObj>();
            List<AbsenceObj> delete = new List<AbsenceObj>();

            foreach (DataGridViewRow row in dgv.Rows)
            {
                string id = row.Tag + "";
                string str_pday = row.Cells[colPersonal.Index].Value + "";
                string str_sday = row.Cells[colSick.Index].Value + "";
                int? int_pday = null;
                int? int_sday = null;

                int i;
                if (int.TryParse(str_pday, out i))
                    int_pday = i;
                if (int.TryParse(str_sday, out i))
                    int_sday = i;

                if (_abDic.ContainsKey(id))
                {
                    AbsenceObj obj = _abDic[id];
                    obj.PersonalDays = int_pday;
                    obj.SickDays = int_sday;

                    if (obj.PersonalDays == null && obj.SickDays == null)
                    {
                        delete.Add(obj);
                    }
                    else
                    {
                        update.Add(obj);
                    }
                }
                else
                {
                    if (int_pday != null || int_sday != null)
                    {
                        AbsenceObj obj = new AbsenceObj();
                        obj.RefStudentId = int.Parse(id);
                        obj.SchoolYear = _schoolYear;
                        obj.Semester = _semester;
                        obj.PersonalDays = int_pday;
                        obj.SickDays = int_sday;
                        insert.Add(obj);
                    }
                }
            }

            if (insert.Count > 0)
                _A.InsertValues(insert);

            if (update.Count > 0)
                _A.UpdateValues(update);

            if (delete.Count > 0)
                _A.DeletedValues(delete);

            WriteLog();
        }

        private void WriteLog()
        {
            StringBuilder sb = new StringBuilder();
            foreach (DataGridViewRow row in dgv.Rows)
            {
                DataGridViewCell pcell = row.Cells[colPersonal.Index];
                DataGridViewCell scell = row.Cells[colSick.Index];
                string name = row.Cells[colName.Index].Value + "";
                string studentNo = row.Cells[colStudentNo.Index].Value + "";
                string p_before = pcell.Tag + "";
                string p_after = pcell.Value + "";
                string s_before = scell.Tag + "";
                string s_after = scell.Value + "";

                if (p_before != p_after)
                {
                    sb.AppendLine(string.Format("學生:{0} 學號:{1} 事假天數由「{2}」改為「{3}」", name, studentNo, p_before, p_after));
                }

                if (s_before != s_after)
                {
                    sb.AppendLine(string.Format("學生:{0} 學號:{1} 病假天數由「{2}」改為「{3}」", name, studentNo, s_before, s_after));
                }
            }

            if (!string.IsNullOrWhiteSpace(sb.ToString()))
            {
                sb.Insert(0, string.Format("學年度:{0} 學期:{1}\r\n",_schoolYear,_semester));
                FISCA.LogAgent.ApplicationLog.Log("請假天數輸入", "編輯", sb.ToString());
            }

            MessageBox.Show("儲存完成");
            GetDays();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ValidateSchoolYear()
        {
            int schoolYear;

            if (int.TryParse(cboSchoolYear.Text, out schoolYear))
            {
                _schoolYear = schoolYear;
                GetDays();
            }
            else
            {
                MessageBox.Show("學年度必須是數字");
                return;
            }
        }

        private void ValidateSemester()
        {
            int semester;

            if (int.TryParse(cboSemester.Text, out semester))
            {
                _semester = semester;
                GetDays();
            }
            else
            {
                MessageBox.Show("學期必須是數字");
                return;
            }
        }

        private bool HasError()
        {
            //檢查錯誤
            foreach (DataGridViewRow row in dgv.Rows)
            {
                string p_error = row.Cells[colPersonal.Index].ErrorText;
                string s_error = row.Cells[colSick.Index].ErrorText;
                if (!string.IsNullOrWhiteSpace(p_error) || !string.IsNullOrWhiteSpace(s_error))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
