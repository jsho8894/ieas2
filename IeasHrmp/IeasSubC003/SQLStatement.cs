using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IeasSubC03
{
    class SQLStatement
    {
        //get_codinfo('', )
        static public string 
            SelectSQL = "select duty_empno,duty_dutcd,duty_sdate,duty_edate,duty_rept " +
            "from THRMP_DUTY " +
            "where duty_empno like :duty_empno";

        static public string
            SelectSQL1 = "select bas_empno,bas_name,get_thrm_deptinfo(bas_dept) as bas_dept,get_codinfo('POS',bas_pos) as bas_pos " +
            "from THRMP_BAS " +
            "where bas_empno like :bas_empno and bas_name like :bas_name and bas_dept like :bas_dept and bas_pos like :bas_pos ";

        static public string
            InsertSQL = "insert into THRMP_DUTY ( duty_empno , duty_dutcd , duty_sdate , duty_edate , duty_rept , datasys1 , datasys2 , datasys3 )" +
            "values " +
            "( :duty_empno , :duty_dutcd , :duty_sdate , :duty_edate, :duty_rept , sysdate, 'A' ,:datasys3 )";

        static public string
            UpdateSQL = "update THRMP_DUTY set " +
                        "duty_dutcd= :duty_dutcd,duty_sdate= :duty_sdate ,duty_edate= :duty_edate ,duty_rept= :duty_rept ,datasys1=sysdate,datasys2='U',datasys3=:datasys3" +
                        " where duty_empno = :key1";

        static public string
            DeleteSQL = "delete from THRMP_DUTY where duty_empno = :key1 and duty_dutcd = :key2 and duty_sdate = :key3";

        static public string//직급
            SelectSQL2 = "select cd_code||':'||cd_codnm as codenm from tieas_cd where cd_grpcd = 'POS' AND cd_addinfo = '2'";

        static public string//소속검색
            SelectSQL3 = "select dept_code as codekey, dept_name as codenm from thrm_dept";

        static public string//직급
            SelectSQL4 = "select dept_code from thrm_dept";



    }
}
