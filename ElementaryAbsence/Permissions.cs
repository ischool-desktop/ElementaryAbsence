using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementaryAbsence
{
    class Permissions
    {
        public static string ElementaryAbsence { get { return "ElementaryAbsence.68EDE1C3-C4F6-42FD-97FD-5F9AAEDAB512"; } }

        public static bool ElementaryAbsence權限
        {
            get { return FISCA.Permission.UserAcl.Current[ElementaryAbsence].Executable; }
        }

        public static string ElementaryAbsence開放設定 { get { return "ElementaryAbsence開放設定.68EDE1C3-C4F6-42FD-97FD-5F9AAEDAB512"; } }

        public static bool ElementaryAbsence開放設定權限
        {
            get { return FISCA.Permission.UserAcl.Current[ElementaryAbsence開放設定].Executable; }
        }

        public static string 小學請假天數 { get { return "ElementaryAbsence.Detail"; } }

    }
}
