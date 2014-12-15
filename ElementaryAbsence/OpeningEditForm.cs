using FISCA.Presentation.Controls;
using FISCA.UDT;
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
    public partial class OpeningEditForm : BaseForm
    {
        AccessHelper _A;
        SettingObj _setting;
        public OpeningEditForm()
        {
            InitializeComponent();
            _A = new AccessHelper();

            List<SettingObj> list = _A.Select<SettingObj>();

            if (list.Count > 0)
                _setting = list[0];
            else
                _setting = new SettingObj();

            if (_setting.OpeningDate.HasValue)
                dtOpen.Value = _setting.OpeningDate.Value;
            if (_setting.FinishedDate.HasValue)
                dtClose.Value = _setting.FinishedDate.Value;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _setting.OpeningDate = dtOpen.Value;
            _setting.FinishedDate = dtClose.Value;

            _setting.Save();

            MessageBox.Show("儲存完成");
            this.Close();
        }
    }
}
