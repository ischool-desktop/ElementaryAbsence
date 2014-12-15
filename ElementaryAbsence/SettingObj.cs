using FISCA.UDT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElementaryAbsence
{
    [FISCA.UDT.TableName("ischool.elementaryabsence.setting")]
    public class SettingObj : ActiveRecord
    {
        [FISCA.UDT.Field(Field = "opening_date")]
        public DateTime? OpeningDate { get; set; }

        [FISCA.UDT.Field(Field = "finished_date")]
        public DateTime? FinishedDate { get; set; }
    }
}
