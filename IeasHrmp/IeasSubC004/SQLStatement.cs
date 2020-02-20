using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IeasSubC04
{
    class SQLStatement
    {
        //get_codinfo('', )
        static public string
            SelectSQL = "select cmt_empno,cmt_cmtnm,cmt_sdate,cmt_edate " +
            "from THRMP_CMT " +
            "where cmt_empno like :cmt_empno";

        static public string
            SelectSQL1 = "select bas_empno,bas_name,get_thrm_deptinfo(bas_dept) as bas_dept,get_codinfo('POS',bas_pos) as bas_pos " +
            "from THRMP_BAS " +
            "where bas_empno like :bas_empno and bas_name like :bas_name and bas_dept like :bas_dept and bas_pos like :bas_pos ";

        static public string
            UpdateSQL = "update THRMP_CMT set " +
                        "cmt_empno= :cmt_empno,cmt_cmtnm= :cmt_cmtnm,cmt_sdate= :cmt_sdate ,cmt_edate= :cmt_edate ,datasys1=sysdate,datasys2='U',datasys3=:datasys3" +
                        " where cmt_empno = :key1";

        static public string
            InsertSQL = "insert into THRMP_CMT (cmt_empno,cmt_cmtnm,cmt_sdate,cmt_edate,datasys1,datasys2,datasys3)" +
            "values " +
            "( :cmt_empno , :cmt_cmtnm , :cmt_sdate , :cmt_edate , sysdate,'A',:datasys3 )";

        static public string
            DeleteSQL = "delete from THRMP_CMT where cmt_empno = :key1";

        static public string//직급
            SelectSQL3 = "select cd_code||':'||cd_codnm as codenm from tieas_cd where cd_grpcd = 'POS' AND cd_addinfo = '2'";

        static public string//검색
            SelectSQL4 = "select dept_code as codekey, dept_name as codenm from thrm_dept";
        static public string//검색
            SelectSQL5 = "select cd_code as codekey, cd_codnm as codenm from tieas_cd where cd_grpcd = 'CMT' ";






    }
}
