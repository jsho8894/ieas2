using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IeasSubC07
{
    class SQLStatement
    {
        //get_codinfo('', )
        static public string 
            SelectSQL = "select edu_empno ,edu_loe ,edu_gratype ,edu_entdate ,edu_gradate ,edu_acqdate ,edu_schnm ,edu_majdiv ,edu_maj ,edu_degree ,edu_country ,edu_majdeep ,edu_last " +
            " from THRMP_EDU " +
            " where edu_empno like :edu_empno";
        
        static public string
            SelectSQL1 = "select bas_empno,bas_name,get_thrm_deptinfo(bas_dept) as bas_dept,get_codinfo('POS',bas_pos) as bas_pos " +
            "from THRMP_BAS " +
            "where bas_empno like :bas_empno and bas_name like :bas_name and bas_dept like :bas_dept and bas_pos like :bas_pos ";

        static public string
            InsertSQL = "insert into THRMP_EDU ( edu_empno ,edu_loe ,edu_gratype ,edu_entdate ,edu_gradate ,edu_acqdate ,edu_schnm ,edu_majdiv ,edu_maj ,edu_degree ,edu_country ,edu_majdeep ,edu_last , datasys1 , datasys2 , datasys3 )" +
            "values " +
            "( :edu_empno ,:edu_loe ,:edu_gratype ,:edu_entdate ,:edu_gradate ,:edu_acqdate ,:edu_schnm ,:edu_majdiv ,:edu_maj ,:edu_degree ,:edu_country ,:edu_majdeep ,:edu_last, sysdate, 'A' ,:datasys3 )";

        static public string
            UpdateSQL = "update THRMP_EDU set " +
                        " edu_loe = :edu_loe ,edu_gratype = :edu_gratype ,edu_entdate= :edu_entdate ,edu_gradate = :edu_gradate ,edu_acqdate = :edu_acqdate ,edu_schnm = :edu_schnm ,edu_majdiv = :edu_majdiv ,edu_maj = :edu_maj ,edu_degree = :edu_degree ,edu_country = :edu_country ,edu_majdeep = :edu_majdeep ,edu_last = :edu_last ,datasys1=sysdate,datasys2='U',datasys3=:datasys3" +
                        " where edu_empno = :key1 and edu_loe = :key2 and edu_entdate = :key3 ";

        static public string
            DeleteSQL = "delete from THRMP_EDU where edu_empno = :key1 and edu_loe = :key2 and edu_entdate = :key3";

        static public string//직급
            SelectSQL2 = "select cd_code||':'||cd_codnm as codenm from tieas_cd where cd_grpcd = 'POS' AND cd_addinfo = '2'";

        static public string//소속검색
            SelectSQL3 = "select dept_code as codekey, dept_name as codenm from thrm_dept";

        static public string//학위종류
            SelectSQL4 = "select cd_code as codekey, cd_codnm as codenm from tieas_cd where cd_grpcd = 'AD1' ";
        static public string//취득종류
            SelectSQL5 = "select cd_code as codekey, cd_codnm as codenm from tieas_cd where cd_grpcd = 'AD2' ";

        static public string//학교명
            SelectSQL6 = "select univ_code as codekey, univ_name as codenm from TIEAS_UNIV";
        static public string//전공계열
            SelectSQL7 = "select cd_code as codekey, cd_codnm as codenm from tieas_cd where cd_grpcd = 'AD3' ";
        static public string//취득국가
            SelectSQL8 = "select cd_code as codekey, cd_codnm as codenm from tieas_cd where cd_grpcd = 'NAT' ";



    }
}
