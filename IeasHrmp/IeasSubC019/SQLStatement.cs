using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IeasSubC19
{
    class SQLStatement
    {
        static public string
            SelectSQL = "select papr_appno,papr_content,papr_num,papr_date from THRMP_PAPP where papr_appno like :papr_appno";
        static public string
            UpdateSQL = "update THRMP_PAPR set papr_appno= :papr_appno, papr_content= :papr_content, papr_num= :papr_num, papr_date=:papr_date where papr_appno = :key1";
        static public string
            InsertSQL = "insert into THRMP_PAPR (papr_appno, papr_content, papr_num, papr_date) values (:papr_appno, :papr_content, :papr_num, :papr_date)";
        static public string
            DeleteSQL = "delete from THRMP_PAPR where papr_appno=:key1";
    }
}
