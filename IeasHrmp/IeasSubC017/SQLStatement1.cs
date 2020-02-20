using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IeasSubC17
{
    class SQLStatement
    {
        static public string
            SelectSQL = "select papp_appno,papp_content,papp_num,papp_date from THRMP_PAPP where papp_appno like :papp_appno";
        static public string
            UpdateSQL = "update THRMP_PAPP set papp_appno= :papp_appno, papp_content= :papp_content, papp_num= :papp_num, papp_date=:papp_date where papp_appno = :key1";
        static public string
            InsertSQL = "insert into THRMP_PAPP (papp_appno, papp_content, papp_num, papp_date) values (:papp_appno, :papp_content, :papp_num, :papp_date)";
        static public string
            DeleteSQL = "delete from THRMP_PAPP where papp_appno=:key1";
    }
}
