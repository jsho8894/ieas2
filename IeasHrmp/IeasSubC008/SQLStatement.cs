using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IeasSubC08
{
    class SQLStatement
    {
        //get_codinfo('', )
        static public string
            SelectSQL = "select bas_empno,bas_resno,bas_name,bas_cname,bas_ename,bas_sex,get_codname('NAT',bas_nat),get_codinfo('AD1',bas_ad1),get_codname('AD2',bas_ad2),get_codname('POS',bas_pos),get_codname('PT1',bas_pt1)," +
            "get_codname('PT2',bas_pt2)as,get_codname('PT3',bas_pt3),get_codname('DUT',bas_dut),get_thrm_deptinfo(bas_dept),get_thrm_deptinfo(bas_dept2)," +
            "bas_cpodate,bas_cdudate,bas_cdedate,bas_subject,get_deptname(bas_dean_dept),bas_cont_mm,bas_emp_sdate,bas_emp_edate, bas_emp_period," +
            "bas_femp_date,bas_cemp_date,bas_emp_date,bas_resdate,bas_retdate,bas_frq,bas_passport,bas_kfta,bas_zip,bas_zipaddr,bas_hdpno,bas_telno," +
            "bas_email,bas_bsks,bas_job_comnm,bas_job_pos,bas_job_telno,bas_levdate,bas_reidate,bas_wsta,get_codname('STS',bas_sts),bas_res,bas_loa, bas_univ_wys, bas_ind_wys, " +
            "bas_mil_sta,bas_mil_no, bas_mil_mil , bas_mil_rnk,bas_mil_sdate,bas_mil_edate,bas_rmk " +
            " from THRMP_BAS " +
            "where bas_empno like :bas_empno ";

        static public string
            SelectSQL1 = "select bas_empno,bas_name,get_thrm_deptinfo(bas_dept) as bas_dept,get_codinfo('POS',bas_pos) as bas_pos " +
            "from THRMP_BAS " +
            "where bas_empno like :bas_empno and bas_name like :bas_name and bas_dept like :bas_dept and bas_pos like :bas_pos ";

        static public string//직급
            SelectSQL2 = "select cd_code||':'||cd_codnm as codenm from tieas_cd where cd_grpcd = 'POS' AND cd_addinfo = '2'";

        static public string[] SelectSQL3 = new string[8];
        static public void Setsql() { 

            SelectSQL3[1] = "select duty_dutcd,duty_sdate,duty_edate,duty_rept " +
            "from THRMP_DUTY " +
            "where duty_empno like :bas_empno";

            SelectSQL3[2] = "select cmt_cmtnm,cmt_sdate,cmt_edate " +
            "from THRMP_CMT " +
            "where cmt_empno like :bas_empno";

            SelectSQL3[3] = "select award_date,get_codname('AWD',award_type) as award_type ,award_no,award_kind,award_organ,award_content,award_inout,award_pos,award_dept " +
            "from THRMP_AWARD " +
            "where award_empno like :bas_empno";

            SelectSQL3[4] = "select pnm_date,get_codname('PNM',pnm_type) as pnm_type ,pnm_content,pnm_pos,pnm_dept " +
            "from THRMP_PUNISHMENT " +
            "where pnm_empno like :bas_empno";

            SelectSQL3[5] = "select edu_loe ,edu_gratype ,edu_entdate ,edu_gradate ,edu_acqdate ,edu_schnm ,edu_majdiv ,edu_maj ,edu_degree ,edu_country ,edu_majdeep ,edu_last " +
            " from THRMP_EDU " +
            " where edu_empno like :bas_empno";

            SelectSQL3[6] = " select lecc_sdate,lecc_edate,lecc_eduinst,lecc_position,lecc_career " +
            " from THRMP_LECC " +
            " where lecc_empno like :bas_empno ";
        }

        static public string//검색
            SelectSQL10 = "select dept_code as codekey, dept_name as codenm from thrm_dept";


}
}
