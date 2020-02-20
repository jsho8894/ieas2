using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IeasSubC02
{
    class SQLStatement
    {
        //get_codinfo('', )
        static public string 
            SelectSQL = "select bas_empno,bas_resno,bas_name,bas_cname,bas_ename,bas_sex,get_codinfo('NAT',bas_nat),get_codinfo('AD1',bas_ad1),get_codinfo('AD2',bas_ad2),get_codinfo('POS',bas_pos),get_codinfo('PT1',bas_pt1),get_codinfo('PT2',bas_pt2),get_codinfo('PT3',bas_pt3),get_codinfo('DUT',bas_dut),get_thrm_deptinfo(bas_dept),get_thrm_deptinfo(bas_dept2)," +
            "bas_cpodate,bas_cdudate,bas_cdedate,bas_subject,get_deptinfo(bas_dean_dept),bas_cont_mm,bas_emp_sdate,bas_emp_edate, bas_emp_period," +
            "bas_femp_date,bas_cemp_date,bas_emp_date,bas_resdate,bas_retdate,bas_frq,bas_passport,bas_kfta,bas_zip,bas_zipaddr,bas_hdpno,bas_telno," +
            "bas_email,bas_bsks,bas_job_comnm,bas_job_pos,bas_job_telno,bas_levdate,bas_reidate,bas_wsta,get_codinfo('STS',bas_sts),bas_res,bas_loa, bas_univ_wys, bas_ind_wys, " +
            "bas_mil_sta,bas_mil_no, bas_mil_mil , bas_mil_rnk,bas_mil_sdate,bas_mil_edate,bas_rmk " +
            "from THRMP_BAS " +
            "where bas_empno like :bas_empno and bas_name like :bas_name and bas_dept like :bas_dept and bas_pos like :bas_pos ";

        static public string
            UpdateSQL = "update THRMP_BAS set " +
                        "bas_empno= :bas_empno, bas_resno= :bas_resno, bas_name= :bas_name, bas_cname= :bas_cname, bas_ename= :bas_ename, bas_sex= :bas_sex, bas_nat= :bas_nat, bas_ad1 =:bas_ad1, bas_ad2= :bas_ad2, " +
                        "bas_pos= :bas_pos, bas_pt1= :bas_pt1, bas_pt2= :bas_pt2, bas_pt3= :bas_pt3, bas_dut= :bas_dut, bas_dept= :bas_dept, bas_dept2= :bas_dept2, bas_cpodate= :bas_cpodate, bas_cdudate= :bas_cdudate, bas_cdedate= :bas_cdedate, bas_subject= :bas_subject, bas_dean_dept= :bas_dean_dept," +
                        "bas_cont_mm= :bas_cont_mm, bas_emp_sdate= :bas_emp_sdate, bas_emp_edate= :bas_emp_edate, bas_emp_period= :bas_emp_period, bas_femp_date= :bas_femp_date, bas_cemp_date= :bas_cemp_date," +
                        "bas_emp_date= :bas_emp_date, bas_resdate= :bas_resdate, bas_retdate= :bas_retdate, bas_frq= :bas_frq, bas_passport= :bas_passport, bas_kfta= :bas_kfta, bas_zip= :bas_zip, bas_zipaddr= :bas_zipaddr, bas_hdpno= :bas_hdpno, bas_telno= :bas_telno, bas_email= :bas_email, bas_bsks= :bas_bsks, bas_job_comnm= :bas_job_comnm," +
                        "bas_job_pos= :bas_job_pos, bas_job_telno= :bas_job_telno, bas_levdate= :bas_levdate, bas_reidate= :bas_reidate, bas_wsta= :bas_wsta, bas_sts= :bas_sts, bas_res= :bas_res, bas_loa= :bas_loa, bas_univ_wys= :bas_univ_wys, bas_ind_wys= :bas_ind_wys," +
                        "bas_mil_sta= :bas_mil_sta, bas_mil_no= :bas_mil_no, bas_mil_mil= :bas_mil_mil, bas_mil_rnk= :bas_mil_rnk, bas_mil_sdate= :bas_mil_sdate, bas_mil_edate= :bas_mil_edate, bas_rmk= :bas_rmk" +
            " where bas_empno = :key1";

        static public string
            InsertSQL = "insert into THRMP_BAS (bas_empno,bas_resno,bas_name,bas_cname,bas_ename,bas_sex,bas_nat,bas_ad1,bas_ad2," +
            "bas_pos,bas_pt1,bas_pt2,bas_pt3,bas_dut,bas_dept,bas_dept2,bas_cpodate,bas_cdudate,bas_cdedate,bas_subject,bas_dean_dept," +
            "bas_cont_mm,bas_emp_sdate,bas_emp_edate,bas_emp_period,bas_femp_date,bas_cemp_date," +
            "bas_emp_date,bas_resdate,bas_retdate,bas_frq,bas_passport,bas_kfta,bas_zip,bas_zipaddr,bas_hdpno,bas_telno,bas_email,bas_bsks,bas_job_comnm," +
            "bas_job_pos,bas_job_telno,bas_levdate,bas_reidate,bas_wsta,bas_sts,bas_res,bas_loa,bas_univ_wys,bas_ind_wys," +
            "bas_mil_sta,bas_mil_no, bas_mil_mil, bas_mil_rnk,bas_mil_sdate,bas_mil_edate,bas_rmk,datasys1,datasys2,datasys3 ) " +
            "values " +
            "( :bas_empno , :bas_resno , :bas_name , :bas_cname , :bas_ename , :bas_sex , :bas_nat , :bas_ad1 , :bas_ad2 ," +
            " :bas_pos , :bas_pt1, :bas_pt2 , :bas_pt3 , :bas_dut , :bas_dept , :bas_dept2 , :Bas_cpodate , :bas_cdudate , :bas_cdedate , :bas_subject , :bas_dean_dept , " +
            " :bas_cont_mm , :bas_emp_sdate , :bas_emp_edate , :bas_emp_period , :bas_femp_date , :bas_cemp_date , " +
            " :bas_emp_date , :bas_resdate , :bas_retdate , :bas_frq , :bas_passport , :bas_kfta , :bas_zip , :bas_zipaddr ,  :bas_hdpno , :bas_telno , :bas_email , :bas_bsks , :bas_job_comnm , " +
            " :bas_job_pos , :bas_job_telno , :bas_levdate , :bas_reidate , :bas_wsta , :bas_sts , :bas_res , :bas_loa , :bas_univ_wys , :bas_ind_wys , " +
            " :bas_mil_sta , :bas_mil_no , :bas_mil_mil , :bas_mil_rnk , :bas_mil_sdate , :bas_mil_edate , :bas_rmk, sysdate,'A',:datasys3 )";
        static public string
            DeleteSQL = "delete from THRMP_BAS where bas_empno=:key1";

        static public string//국적
            SelectSQL1 = "select cd_code||':'||cd_codnm as codenm from tieas_cd where cd_grpcd = 'NAT'";
        static public string//최종학위(취득기준)
            SelectSQL2 = "select cd_code||':'||cd_codnm as codenm from tieas_cd where cd_grpcd = 'AD1'";
        static public string//최종학위(수료/과정)
            SelectSQL3 = "select cd_code||':'||cd_codnm as codenm from tieas_cd where cd_grpcd = 'AD2'";
        static public string//직급
            SelectSQL4 = "select cd_code||':'||cd_codnm as codenm from tieas_cd where cd_grpcd = 'POS' AND cd_addinfo = '2'";
        static public string//직급구분1
            SelectSQL5 = "select cd_code||':'||cd_codnm as codenm from tieas_cd where cd_grpcd = 'PT1'";
        static public string//직급구분2
            SelectSQL6 = "select cd_code||':'||cd_codnm as codenm from tieas_cd where cd_grpcd = 'PT2'";
        static public string//직급구분3
            SelectSQL7 = "select cd_code||':'||cd_codnm as codenm from tieas_cd where cd_grpcd = 'PT3'";
        static public string//직책(대표)
            SelectSQL8 = "select cd_code||':'||cd_codnm as codenm from tieas_cd where cd_grpcd = 'DUT'";

        static public string//소속,소속2
            SelectSQL9 = "select dept_code||':'||dept_name from thrm_dept";
        static public string//학과장
            SelectSQL09 = "select dept_code||':'||dept_name from tieas_dept";
        static public string//검색
            SelectSQL10 = "select dept_code as codekey, dept_name as codenm from thrm_dept";

        static public string//신분구분
            SelectSQL11 = "select cd_code||':'||cd_codnm as codenm from tieas_cd where cd_grpcd = 'STS'";
        static public string//퇴직사유
            SelectSQL12 = "select cd_codnm from tieas_cd where cd_grpcd = 'RES' order by cd_code";
        static public string//휴직사유
            SelectSQL13 = "select cd_codnm from tieas_cd where cd_grpcd = 'LOA'";
        static public string//군별
            SelectSQL14 = "select cd_codnm from tieas_cd where cd_grpcd = 'MIL'";
        static public string//계급
            SelectSQL15 = "select cd_codnm from tieas_cd where cd_grpcd = 'RNK'";
    
    }
}
