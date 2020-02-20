using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IeasSubC05
{
    class SQLStatement
    {
        //get_codinfo('', )
        static public string
            SelectSQL = "select award_empno,award_date,get_codinfo('AWD',award_type),award_no,award_kind,award_organ,award_content,award_inout,award_pos,award_dept " +
            "from THRMP_AWARD " +
            "where award_empno like :award_empno";
        
        static public string
            SelectSQL1 = "select bas_empno,bas_name,get_thrm_deptinfo(bas_dept) as bas_dept,get_codinfo('POS',bas_pos) as bas_pos " +
            "from THRMP_BAS " +
            "where bas_empno like :bas_empno and bas_name like :bas_name and bas_dept like :bas_dept and bas_pos like :bas_pos ";

        static public string
            UpdateSQL = "update THRMP_AWARD set " +
                        "award_date= :award_date, award_type= :award_type,award_no= :award_no, award_kind= :award_kind, award_organ= :award_organ, award_content= award_content, award_inout= :award_inout, award_pos= :award_pos, award_dept= :award_dept," +
                        " datasys1=sysdate,datasys2='U',datasys3=:datasys3" +
                        " where award_empno = :key1";

        static public string
            InsertSQL = "insert into THRMP_AWARD (award_empno,award_date,award_type,award_no,award_kind,award_organ,award_content,award_inout,award_pos,award_dept,datasys1,datasys2,datasys3)" +
            "values " +
            "( :award_empno, :award_date , :award_type , :award_no , :award_kind , :award_organ , :award_content , :award_inout , :award_pos , :award_dept, sysdate,'A',:datasys3 )";

        static public string
            DeleteSQL = "delete from THRMP_AWARD where award_empno = :key1 And award_date = :key2";

        static public string//직급 검색
            SelectSQL2 = "select cd_code||':'||cd_codnm as codenm from tieas_cd where cd_grpcd = 'POS' AND cd_addinfo = '2'";

        static public string//직급 검색
            SelectSQL5 = "select cd_codnm as codenm from tieas_cd where cd_grpcd = 'POS' AND cd_addinfo = '2'";

        static public string//소속검색
            SelectSQL3 = "select dept_code as codekey, dept_name as codenm from thrm_dept";

        static public string//소속검색
            SelectSQL6 = "select dept_name as codenm from thrm_dept";

        static public string//수상기록검색
            SelectSQL4 = "select cd_code||':'||cd_codnm as codenm from tieas_cd where cd_grpcd = 'AWD'";






    }
}
