using FISCA.Permission;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementaryAbsence
{
    public class Program
    {
        [FISCA.MainMethod]
        public static void main()
        {
            //更新UDM
            if(!FISCA.RTContext.IsDiagMode)
                FISCA.ServerModule.AutoManaged("http://module.ischool.com.tw/module/282133/ischool.nehs.absence/udm.xml");

            //更新UDT
            FISCA.UDT.AccessHelper a = new FISCA.UDT.AccessHelper();
            a.Select<AbsenceObj>("uid is null");
            a.Select<SettingObj>("uid is null");

            FISCA.Presentation.RibbonBarItem item1 = FISCA.Presentation.MotherForm.RibbonBarItems["班級", "學務"];
            item1["請假天數輸入"].Image = Properties.Resources.date_field_write_64;
            item1["請假天數輸入"].Enable = false;
            item1["請假天數輸入"].Click += delegate
            {
                new MainForm().ShowDialog();
            };

            K12.Presentation.NLDPanels.Class.SelectedSourceChanged += delegate
            {
                item1["請假天數輸入"].Enable = K12.Presentation.NLDPanels.Class.SelectedSource.Count == 1 && Permissions.ElementaryAbsence權限;
            };

            FISCA.Presentation.RibbonBarItem item2 = FISCA.Presentation.MotherForm.RibbonBarItems["教務作業", "基本設定"];
            item2["管理"]["1~6年級請假天數輸入開放設定"].Enable = Permissions.ElementaryAbsence開放設定權限;
            item2["管理"]["1~6年級請假天數輸入開放設定"].Click += delegate
            {
                new OpeningEditForm().ShowDialog();
            };

            Catalog permission1 = RoleAclSource.Instance["班級"]["功能按鈕"];
            permission1.Add(new RibbonFeature(Permissions.ElementaryAbsence, "請假天數輸入"));
            Catalog permission2 = RoleAclSource.Instance["教務作業"]["功能按鈕"];
            permission2.Add(new RibbonFeature(Permissions.ElementaryAbsence開放設定, "1~6年級請假天數輸入開放設定"));
        }
    }
}
