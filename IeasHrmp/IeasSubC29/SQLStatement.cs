using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IeasSubC30
{
    class SQLStatement
    {
        //get_codinfo('', )
        static public string
            SelectSQL = "select pnm_empno,pnm_date,get_codinfo('PNM',pnm_type),pnm_content,pnm_pos,pnm_dept " +
            "from THRMP_PUNISHMENT " +
            "where pnm_empno like :pnm_empno";

        static public string
            SelectSQL1 = "select bas_empno,bas_name,get_thrm_deptinfo(bas_dept) as bas_dept,get_codinfo('POS',bas_pos) as bas_pos " +
            "from THRMP_BAS " +
            "where bas_empno like :bas_empno and bas_name like :bas_name and bas_dept like :bas_dept and bas_pos like :bas_pos ";

        static public string
            UpdateSQL = "update THRMP_PUNISHMENT set " +
                        "pnm_type= :pnm_type ,pnm_content= :pnm_content ,pnm_pos= :pnm_pos ,pnm_dept= :pnm_dept ,datasys1=sysdate,datasys2='U',datasys3=:datasys3" +
                        " where pnm_empno = :key1 and pnm_date = :key2 ";

        static public string
            InsertSQL = "insert into THRMP_PUNISHMENT (pnm_empno ,pnm_date ,pnm_type ,pnm_content ,pnm_pos ,pnm_dept ,datasys1,datasys2,datasys3)" +
            "values " +
            "( :pnm_empno , :pnm_date , :pnm_type , :pnm_content, :pnm_pos, :pnm_dept , sysdate,'A',:datasys3 )";

        static public string
            DeleteSQL = "delete from THRMP_PUNISHMENT where pnm_empno = :key1 and pnm_date =key2";

        static public string//직급
            SelectSQL3 = "select cd_code||':'||cd_codnm as codenm from tieas_cd where cd_grpcd = 'POS' AND cd_addinfo = '2'";

        static public string//검색
            SelectSQL4 = "select dept_code as codekey, dept_name as codenm from thrm_dept";
        static public string//검색
            SelectSQL5 = "select cd_code||':'||cd_codnm as codenm from tieas_cd where cd_grpcd = 'PNM' ";
        static public string//검색
            SelectSQL6 = "select cd_codnm as codenm from tieas_cd where cd_grpcd = 'POS'";







    }
}
