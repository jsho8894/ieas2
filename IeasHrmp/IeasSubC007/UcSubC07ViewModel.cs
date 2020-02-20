using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using DevExpress.XtraEditors.DXErrorProvider;
using IeasLibrary;

namespace IeasSubC07
{
    public class UcSubC07ViewModel : Notifier, IDataErrorInfo
    {
        #region Data Binding Model

        /// <summary>
        /// ///////////////////////////////////////////////////////기본사항
        /// </summary>
        /// 

        public List<string> Edu_majdeep_set
        {
            get
            {
                return new List<string>() {"1", "2"};
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
        /// <summary>
        /// 학력사항
        /// </summary>
        private string edu_empno;//사원번호
        public string Edu_empno
        {
            get { return edu_empno; }
            set
            {
                if (value == edu_empno) return;

                edu_empno = value;
                OnValueChanged("Edu_empno");
            }
        }
        private string edu_loe;//학위종류
        public string Edu_loe
        {
            get { return edu_loe; }
            set
            {
                if (value == edu_loe) return;

                edu_loe = value;
                OnValueChanged("Edu_loe");
            }
        }
        public string Edu_loe_Cd
        {
            get { return Utility.GetCode(edu_loe); }
        }
        private string edu_gratype;//취득구분
        public string Edu_gratype
        {
            get { return edu_gratype; }
            set
            {
                if (value == edu_gratype) return;

                edu_gratype = value;
                OnValueChanged("Edu_gratype");
            }
        }
        public string Edu_gratype_Cd
        {
            get { return Utility.GetCode(edu_gratype); }
        }
        private string edu_entdate;//학위기간(입학일)
        public string Edu_entdate
        {
            get { return edu_entdate; }
            set
            {
                if (value == edu_entdate) return;

                edu_entdate = value;
                OnValueChanged("Edu_entdate");
            }
        }
        private string edu_gradate;//학위기간(졸업일)
        public string Edu_gradate
        {
            get { return edu_gradate; }
            set
            {
                if (value == edu_gradate) return;

                edu_gradate = value;
                OnValueChanged("Edu_gradate");
            }
        }
        private string edu_acqdate;//취득년월일
        public string Edu_acqdate
        {
            get { return edu_acqdate; }
            set
            {
                if (value == edu_acqdate) return;

                edu_acqdate = value;
                OnValueChanged("Edu_acqdate");
            }
        }
        private string edu_schnm;//학교명
        public string Edu_schnm
        {
            get { return edu_schnm; }
            set
            {
                if (value == edu_schnm) return;

                edu_schnm = value;
                OnValueChanged("Edu_schnm");
            }
        }
        public string Edu_schnm_Cd
        {
            get { return Utility.GetCode(edu_schnm); }
        }
        private string edu_majdiv;//전공계열
        public string Edu_majdiv
        {
            get { return edu_majdiv; }
            set
            {
                if (value == edu_majdiv) return;

                edu_majdiv = value;
                OnValueChanged("Edu_majdiv");
            }
        }
        public string Edu_majdiv_Cd
        {
            get { return Utility.GetCode(edu_majdiv); }
        }
        private string edu_maj;//전공명
        public string Edu_maj
        {
            get { return edu_maj; }
            set
            {
                if (value == edu_maj) return;

                edu_maj = value;
                OnValueChanged("Edu_maj");
            }
        }
        private string edu_degree;//학위명
        public string Edu_degree
        {
            get { return edu_degree; }
            set
            {
                if (value == edu_degree) return;

                edu_degree = value;
                OnValueChanged("Edu_degree");
            }
        }
        private string edu_country;//취득국가
        public string Edu_country
        {
            get { return edu_country; }
            set
            {
                if (value == edu_country) return;

                edu_country = value;
                OnValueChanged("Edu_country");
            }
        }
        public string Edu_country_Cd
        {
            get { return Utility.GetCode(edu_country); }
        }
        private string edu_majdeep = "2";//전공심화과정여부
        public string Edu_majdeep
        {
            get { return edu_majdeep; }
            set
            {
                if (value == edu_majdeep) return;

                edu_majdeep = value;
                OnValueChanged("Edu_majdeep");
            }
        }
        public string Edu_majdeep_Cd
        {
            get { return Utility.GetCode(edu_majdeep); }
        }

        private string edu_last = "N";//최종여부
        public string Edu_last
        {
            get { return edu_last; }
            set
            {
                if (value == edu_last) return;

                edu_last = value;
                OnValueChanged("Edu_last");
            }
        }


        public string Key1 { get; set; }
        public string Key2 { get; set; }
        public string Key3 { get; set; }
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