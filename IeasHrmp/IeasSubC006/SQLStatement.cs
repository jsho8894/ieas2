using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IeasSubC06
{
    class SQLStatement
    {
        //get_codinfo('', )
        static public string
            SelectSQL = " select lecc_empno,lecc_sdate,lecc_edate,lecc_eduinst,lecc_position,lecc_career " +
            " from THRMP_LECC " +
            " where lecc_empno like :lecc_empno ";
        
        static public string
            SelectSQL1 = "select bas_empno,bas_name,get_thrm_deptinfo(bas_dept) as bas_dept,get_codinfo('POS',bas_pos) as bas_pos " +
            "from THRMP_BAS " +
            "where bas_empno like :bas_empno and bas_name like :bas_name and bas_dept like :bas_dept and bas_pos like :bas_pos ";

        static public string
            UpdateSQL = "update THRMP_LECC set " +
                        "lecc_empno= :lecc_empno, lecc_sdate= :lecc_sdate, lecc_edate= :lecc_edate, lecc_eduinst= :lecc_eduinst, lecc_position= :lecc_position, lecc_career= :lecc_career," +
                        " datasys1=sysdate,datasys2='U',datasys3=:datasys3" +
                        " where lecc_empno = :key1 And lecc_sdate = :key2 And lecc_eduinst = :key3 ";

        static public string
            InsertSQL = "insert into THRMP_LECC (lecc_empno,lecc_sdate,lecc_edate,lecc_eduinst,lecc_position,lecc_career,datasys1,datasys2,datasys3)" +
            "values " +
            "( :lecc_empno, :lecc_sdate, :lecc_edate, :lecc_eduinst, :lecc_position, :lecc_career, sysdate,'A',:datasys3 )";

        static public string
            DeleteSQL = "delete from THRMP_LECC where lecc_empno = :key1 And lecc_sdate = :key2 And lecc_eduinst = :key3";

        static public string//직급 검색
            SelectSQL2 = "select cd_code||':'||cd_codnm as codenm from tieas_cd where cd_grpcd = 'POS' AND cd_addinfo = '2'";

        static public string//소속검색
            SelectSQL3 = "select dept_code as codekey, dept_name as codenm from thrm_dept";






    }
}
