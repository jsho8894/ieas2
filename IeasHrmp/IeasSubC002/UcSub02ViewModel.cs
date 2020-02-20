using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using DevExpress.XtraEditors.DXErrorProvider;
using IeasLibrary;

namespace IeasSubC02
{
    public class UcSubC02ViewModel : Notifier, IDataErrorInfo
    {
        #region Data Binding Model

        /// <summary>
        /// ///////////////////////////////////////////////////////기본사항
        /// </summary>
        /// 

        public List<string> Sex_set
        {
            get
            {
                return new List<string>() { "남", "여" };
            }
        }

        public List<string> Cont_mm_set
        {
            get
            {
                return new List<string>() { "","01","02","03","04","05","06","07","08","09","10","11","12" };
            }
        }

        public List<string> Wsta_set
        {
            get
            {
                return new List<string>() { "", "재직","휴직","퇴직" };
            }
        }

        public List<string> Mil_sta_set
        {
            get
            {
                return new List<string>() { "","복무", "면제", "미필" };
            }
        }
        public List<string> kfta_set
        {
            get
            {
                return new List<string>() { "","Y", "N" };
            }
        }

        public List<string> bsks_set
        {
            get
            {
                return new List<string>() { "","Y", "N" };
            }
        }




        private string bas_empno;//사원번호
        public string Bas_empno
        {
            get { return bas_empno; }
            set
            {
                if (value == bas_empno) return;

                bas_empno = value;
                OnValueChanged("Bas_empno");
            }
        }

        private string bas_name;//이름
        public string Bas_name
        {
            get { return bas_name; }
            set
            {
                if (value == bas_name) return;

                bas_name = value;
                OnValueChanged("Bas_name");
            }
        }

        private string bas_ename;//영문이름
        public string Bas_ename
        {
            get { return bas_ename; }
            set
            {
                if (value == bas_ename) return;

                bas_ename = value;
                OnValueChanged("Bas_ename");
            }
        }
        private string bas_cname;//한문이름
        public string Bas_cname
        {
            get { return bas_cname; }
            set
            {
                if (value == bas_cname) return;

                bas_cname = value;
                OnValueChanged("Bas_cname");
            }
        }
        
        private string bas_resno;//주민번호
        public string Bas_resno
        {
            get { return bas_resno; }
            set
            {
                if (value == bas_resno) return;

                bas_resno = value;
                OnValueChanged("Bas_resno");
            }
        }

        private string bas_sex;//성별
        public string Bas_sex
        {
            get { return bas_sex; }
            set
            {
                if (value == bas_sex) return;

                bas_sex = value;
                OnValueChanged("Bas_sex");
            }
        }

        private string bas_nat;//국적
        public string Bas_nat
        {
            get { return bas_nat; }
            set
            {
                if (value == bas_nat) return;

                bas_nat = value;
                OnValueChanged("Bas_nat");
            }
        }
        public string Bas_nat_Cd
        {
            get { return Utility.GetCode(bas_nat); }
        }

        private string bas_ad1;//최종학위(취득기준)
        public string Bas_ad1
        {
            get { return bas_ad1; }
            set
            {
                if (value == bas_ad1) return;

                bas_ad1 = value;
                OnValueChanged("Bas_ad1");
            }
        }

        public string Bas_ad1_Cd
        {
            get { return Utility.GetCode(bas_ad1); }
        }

        private string bas_ad2;//최종학위(수료/과정)
        public string Bas_ad2
        {
            get { return bas_ad2; }
            set
            {
                if (value == bas_ad2) return;

                bas_ad2 = value;
                OnValueChanged("Bas_ad2");
            }
        }

        public string Bas_ad2_Cd
        {
            get { return Utility.GetCode(bas_ad2); }
        }

        private string bas_resdate;//정년퇴사 예정일
        public string Bas_resdate
        {
            get { return bas_resdate; }
            set
            {
                if (value == bas_resdate) return;

                bas_resdate = value;
                OnValueChanged("Bas_resdate");
            }
        }

        private string bas_emp_date;//대학최초 임용일
        public string Bas_emp_date
        {
            get { return bas_emp_date; }
            set
            {
                if (value == bas_emp_date) return;

                bas_emp_date = value;
                OnValueChanged("Bas_emp_date");
            }
        }

        private string bas_frq;//외국인 체류자격
        public string Bas_frq
        {
            get { return bas_frq; }
            set
            {
                if (value == bas_frq) return;

                bas_frq = value;
                OnValueChanged("Bas_frq");
            }
        }

        private string bas_passport;//외국인 여권번호
        public string Bas_passport
        {
            get { return bas_passport; }
            set
            {
                if (value == bas_passport) return;

                bas_passport = value;
                OnValueChanged("Bas_passport");
            }
        }

        private string bas_bsks;//본교출신여부
        public string Bas_bsks
        {
            get { return bas_bsks; }
            set
            {
                if (value == bas_bsks) return;

                bas_bsks = value;
                OnValueChanged("Bas_bsks");
            }
        }

        private string bas_kfta;//교총가입여부
        public string Bas_kfta
        {
            get { return bas_kfta; }
            set
            {
                if (value == bas_kfta) return;

                bas_kfta = value;
                OnValueChanged("Bas_kfta");
            }
        }

        private string bas_zip;//우편번호
        public string Bas_zip
        {
            get { return bas_zip; }
            set
            {
                if (value == bas_zip) return;

                bas_zip = value;
                OnValueChanged("Bas_zip");
            }
        }

        private string bas_zipaddr;//우편번호주소
        public string Bas_zipaddr
        {
            get { return bas_zipaddr; }
            set
            {
                if (value == bas_zipaddr) return;

                bas_zipaddr = value;
                OnValueChanged("Bas_zipaddr");
            }
        }


        private string bas_email;//이메일주소
        public string Bas_email
        {
            get { return bas_email; }
            set
            {
                if (value == bas_email) return;

                bas_email = value;
                OnValueChanged("Bas_email");
            }
        }

        private string bas_telno;//집전화
        public string Bas_telno
        {
            get { return bas_telno; }
            set
            {
                if (value == bas_telno) return;

                bas_telno = value;
                OnValueChanged("Bas_telno");
            }
        }

        private string bas_hdpno;//휴대전화
        public string Bas_hdpno
        {
            get { return bas_hdpno; }
            set
            {
                if (value == bas_hdpno) return;

                bas_hdpno = value;
                OnValueChanged("Bas_hdpno");
            }
        }


        private int bas_univ_wys = 0;//타대학 근무년수
        public int Bas_univ_wys
        {
            get { return bas_univ_wys; }
            set
            {
                if (value == bas_univ_wys) return;

                bas_univ_wys = value;
                OnValueChanged("Bas_univ_wys");
            }
        }


        private int bas_ind_wys = 0;//산업체 근무년수
        public int Bas_ind_wys
{
            get { return bas_ind_wys; }
            set
            {
                if (value == bas_ind_wys) return;

                bas_ind_wys = value;
                OnValueChanged("Bas_ind_wys");
            }
        }

        private string bas_mil_sta;//복무구분
        public string Bas_mil_sta
        {
            get { return bas_mil_sta; }
            set
            {
                if (value == bas_mil_sta) return;

                bas_mil_sta = value;
                OnValueChanged("Bas_mil_sta");
            }
        }

        private string bas_mil_no;//군번
        public string Bas_mil_no
        {
            get { return bas_mil_no; }
            set
            {
                if (value == bas_mil_no) return;

                bas_mil_no = value;
                OnValueChanged("Bas_mil_no");
            }
        }

        private string bas_mil_mil;//군별
        public string Bas_mil_mil
        {
            get { return bas_mil_mil; }
            set
            {
                if (value == bas_mil_mil) return;

                bas_mil_mil = value;
                OnValueChanged("Bas_mil_mil");
            }
        }

        private string bas_mil_rnk;//계급
        public string Bas_mil_rnk
        {
            get { return bas_mil_rnk; }
            set
            {
                if (value == bas_mil_rnk) return;

                bas_mil_rnk = value;
                OnValueChanged("Bas_mil_rnk");
            }
        }

        private string bas_mil_sdate;//복무시작일
        public string Bas_mil_sdate
        {
            get { return bas_mil_sdate; }
            set
            {
                if (value == bas_mil_sdate) return;

                bas_mil_sdate = value;
                OnValueChanged("Bas_mil_sdate");
            }
        }

        private string bas_mil_edate;//복무만료일
        public string Bas_mil_edate
        {
            get { return bas_mil_edate; }
            set
            {
                if (value == bas_mil_edate) return;

                bas_mil_edate = value;
                OnValueChanged("Bas_mil_edate");
            }
        }

        private string bas_rmk;//참고사항
        public string Bas_rmk
        {
            get { return bas_rmk; }
            set
            {
                if (value == bas_rmk) return;

                bas_rmk = value;
                OnValueChanged("Bas_rmk");
            }
        }
        /// <summary>
        /// ///////////////////////////////////////////////////////////인사사항
        /// </summary>
        /// 
        private string bas_pos;//직급
        public string Bas_pos
        {
            get { return bas_pos; }
            set
            {
                if (value == bas_pos) return;

                bas_pos = value;
                OnValueChanged("Bas_pos");
            }
        }
        public string Bas_pos_Cd
        {
            get { return Utility.GetCode(bas_pos); }
        }

        private string bas_cpodate;//현직급일자
        public string Bas_cpodate
        {
            get { return bas_cpodate; }
            set
            {
                if (value == bas_cpodate) return;

                bas_cpodate = value;
                OnValueChanged("Bas_cpodate");
            }
        }

        private string bas_dut;//대표직책
        public string Bas_dut
        {
            get { return bas_dut; }
            set
            {
                if (value == bas_dut) return;

                bas_dut = value;
                OnValueChanged("Bas_dut");
            }
        }

        public string Bas_dut_Cd
        {
            get { return Utility.GetCode(bas_dut); }
        }

        private string bas_cdudate;//현직책일자
        public string Bas_cdudate
        {
            get { return bas_cdudate; }
            set
            {
                if (value == bas_cdudate) return;

                bas_cdudate = value;
                OnValueChanged("Bas_cdudate");
            }
        }

        private string bas_dept;//부서(소속)
        public string Bas_dept
        {
            get { return bas_dept; }
            set
            {
                if (value == bas_dept) return;

                bas_dept = value;
                OnValueChanged("Bas_dept");
            }
        }

        public string Bas_dept_Cd
        {
            get { return Utility.GetCode(bas_dept); }
        }



        private string bas_cdedate;//현부서일자
        public string Bas_cdedate
        {
            get { return bas_cdedate; }
            set
            {
                if (value == bas_cdedate) return;

                bas_cdedate = value;
                OnValueChanged("Bas_cdedate");
            }
        }
        private string bas_dept2;//부서2(소속)
        public string Bas_dept2
        {
            get { return bas_dept2; }
            set
            {
                if (value == bas_dept2) return;

                bas_dept2 = value;
                OnValueChanged("Bas_dept2");
            }
        }
        public string Bas_dept2_Cd//부서 코드만
        {
            get { return Utility.GetCode(bas_dept2); }
        }
        private string bas_pt1;//직급구분1
        public string Bas_pt1
        {
            get { return bas_pt1; }
            set
            {
                if (value == bas_pt1) return;

                bas_pt1 = value;
                OnValueChanged("Bas_pt1");
            }
        }

        public string Bas_pt1_Cd
        {
            get { return Utility.GetCode(bas_pt1); }
        }


        private string bas_pt2;//직급구분2
        public string Bas_pt2
        {
            get { return bas_pt2; }
            set
            {
                if (value == bas_pt2) return;

                bas_pt2 = value;
                OnValueChanged("Bas_pt2");
            }
        }

        public string Bas_pt2_Cd
        {
            get { return Utility.GetCode(bas_pt2); }
        }

        private string bas_pt3;//직급구분3
        public string Bas_pt3
        {
            get { return bas_pt3; }
            set
            {
                if (value == bas_pt3) return;

                bas_pt3 = value;
                OnValueChanged("Bas_pt3");
            }
        }
        public string Bas_pt3_Cd
        {
            get { return Utility.GetCode(bas_pt3); }
        }
        private string bas_dean_dept;//학과장
        public string Bas_dean_dept
        {
            get { return bas_dean_dept; }
            set
            {
                if (value == bas_dean_dept) return;

                bas_dean_dept = value;
                OnValueChanged("Bas_dean_dept");
            }
        }

        public string Bas_dean_dept_Cd
        {
            get { return Utility.GetCode(bas_dean_dept); }
        }

        private string bas_subject;//담당과목
        public string Bas_subject
        {
            get { return bas_subject; }
            set
            {
                if (value == bas_subject) return;

                bas_subject = value;
                OnValueChanged("Bas_subject");
            }
        }

        private string bas_emp_sdate;//최근임용일(시작)
        public string Bas_emp_sdate
        {
            get { return bas_emp_sdate; }
            set
            {
                if (value == bas_emp_sdate) return;

                bas_emp_sdate = value;
                OnValueChanged("Bas_emp_sdate");
            }
        }

        private string bas_emp_edate;//최근임용일(끝)
        public string Bas_emp_edate
        {
            get { return bas_emp_edate; }
            set
            {
                if (value == bas_emp_edate) return;

                bas_emp_edate = value;
                OnValueChanged("Bas_emp_edate");
            }
        }

        
        private double bas_emp_period = 0;//임용기간
        public double Bas_emp_period
        {
            get { return bas_emp_period; }
            set
            {
                if (value == bas_emp_period) return;

                bas_emp_period = value;
                OnValueChanged("Bas_emp_period");
            }
        }



        private string bas_cont_mm;//연봉계약월
        public string Bas_cont_mm
        {
            get { return bas_cont_mm; }
            set
            {
                if (value == bas_cont_mm) return;

                bas_cont_mm = value;
                OnValueChanged("Bas_cont_mm");
            }
        }


        private string bas_femp_date;//전임 임용일자
        public string Bas_femp_date
        {
            get { return bas_femp_date; }
            set
            {
                if (value == bas_femp_date) return;

                bas_femp_date = value;
                OnValueChanged("Bas_femp_date");
            }
        }

        private string bas_cemp_date;//법인임용일
        public string Bas_cemp_date
        {
            get { return bas_cemp_date; }
            set
            {
                if (value == bas_cemp_date) return;

                bas_cemp_date = value;
                OnValueChanged("Bas_cemp_date");
            }
        }

        private string bas_retdate;//퇴사일자
        public string Bas_retdate
        {
            get { return bas_retdate; }
            set
            {
                if (value == bas_retdate) return;

                bas_retdate = value;
                OnValueChanged("Bas_retdate");
            }
        }

        private string bas_job_comnm;//본직(기관명)
        public string Bas_job_comnm
        {
            get { return bas_job_comnm; }
            set
            {
                if (value == bas_job_comnm) return;

                bas_job_comnm = value;
                OnValueChanged("Bas_job_comnm");
            }
        }

        private string bas_job_pos;//본직(담당업무)
        public string Bas_job_pos
        {
            get { return bas_job_pos; }
            set
            {
                if (value == bas_job_pos) return;

                bas_job_pos = value;
                OnValueChanged("Bas_job_pos");
            }
        }

        private string bas_job_telno;//본직(전화번호)
        public string Bas_job_telno
        {
            get { return bas_job_telno; }
            set
            {
                if (value == bas_job_telno) return;

                bas_job_telno = value;
                OnValueChanged("Bas_job_telno");
            }
        }
        private string bas_levdate;//휴직일자
        public string Bas_levdate
        {
            get { return bas_levdate; }
            set
            {
                if (value == bas_levdate) return;

                bas_levdate = value;
                OnValueChanged("Bas_levdate");
            }
        }
        private string bas_reidate;//복직일자
        public string Bas_reidate
        {
            get { return bas_reidate; }
            set
            {
                if (value == bas_reidate) return;

                bas_reidate = value;
                OnValueChanged("Bas_reidate");
            }
        }
        private string bas_wsta;//재직상태
        public string Bas_wsta
        {
            get { return bas_wsta; }
            set
            {
                if (value == bas_wsta) return;

                bas_wsta = value;
                OnValueChanged("Bas_wsta");
            }
        }

        private string bas_sts;//신분구분
        public string Bas_sts
        {
            get { return bas_sts; }
            set
            {
                if (value == bas_sts) return;

                bas_sts = value;
                OnValueChanged("Bas_sts");
            }
        }

        public string Bas_sts_Cd
        {
            get { return Utility.GetCode(bas_sts); }
        }

        private string bas_res;//퇴직사유
        public string Bas_res
        {
            get { return bas_res; }
            set
            {
                if (value == bas_res) return;

                bas_res = value;
                OnValueChanged("Bas_res");
            }
        }

        private string bas_loa;//휴직사유
        public string Bas_loa
        {
            get { return bas_loa; }
            set
            {
                if (value == bas_loa) return;

                bas_loa = value;
                OnValueChanged("Bas_loa");
            }
        }

        
        public string Key1{ get; set; }
        #endregion
        #region 반드시 포함해야함(수정 필요없음)
        private string dataStatus = "A";
        public string DataStatus
        {
            get { return dataStatus; }
            set
            {
                dataStatus = value;
            }
        }
        void OnValueChanged(string fn)
        {
            OnPropertyChanged(fn);

            if (dataStatus.Equals("A")) { return; }
            dataStatus = "U";
            OnPropertyChanged("DataStatus");
        }
        #endregion
        #region Validation Check(수정 필요없음)
        private Dictionary<string, string> errMsg = new Dictionary<string, string> { };
        public bool HasError
        {
            get
            {
                if (errMsg.Count > 0) return true;
                else return false;
            }
        }
        private string SetErrorMsg(string propertyName, string msg)
        {
            errMsg.Add(propertyName, msg);
            return msg;
        }
        private string SetErrorMsgIfEmpty(string propertyName, string val, string msg)
        {
            if (string.IsNullOrEmpty(val))
            {
                msg = "[" + msg + "] 반드시 입력해야 합니다.";
                errMsg.Add(propertyName, msg);
                return msg;
            }
            return String.Empty;
        }
        public Dictionary<string, string> GetErrorMsg
        {
            get { return errMsg; }
        }
        //--IDataErrorInfo Members---------------------------
        public string Error
        {
            get
            {
                if (errMsg.Count > 0) return errMsg.ElementAt(0).Value;
                else return string.Empty;
            }
        }
        public string this[string columnName]
        {
            get
            {
                return Validate(columnName);
            }
        }
        //--IDataErrorInfo Members---------------------------
        #endregion
        #region Validation Rule을 정의하세요
        /*---------------------------------------------------------------------------*/
        /* Validation Rule를 여기에다 정의하세요
        /*---------------------------------------------------------------------------*/
        private string Validate(string propertyName)
        {
            // Return error message if there is error on else return empty or null string
            string validationMessage = string.Empty;
            errMsg.Remove(propertyName);
            switch (propertyName)
            {
                case "Bas_empno":
                    validationMessage = SetErrorMsgIfEmpty(propertyName, bas_empno, "사원번호를입력하시오");
                    break;
                case "User_name":
                    validationMessage = SetErrorMsgIfEmpty(propertyName, bas_name, "이름을 입력하시오");
                    break;

            }
            return validationMessage;
        }
        /*---------------------------------------------------------------------------*/
        #endregion
    }
}