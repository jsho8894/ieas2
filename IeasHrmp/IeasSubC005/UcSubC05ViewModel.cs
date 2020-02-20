using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using DevExpress.XtraEditors.DXErrorProvider;
using IeasLibrary;

namespace IeasSubC05
{
    public class UcSubC05ViewModel : Notifier, IDataErrorInfo
    {
        #region Data Binding Model

        /// <summary>
        /// ///////////////////////////////////////////////////////기본사항
        /// </summary>
        /// 

        public List<string> inout
        {
            get
            {
                return new List<string>() { "내부", "외부" };
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
        /// <summary>
        /// 수상이력
        /// </summary>
        private string award_empno;//사원번호
        public string Award_empno
        {
            get { return award_empno; }
            set
            {
                if (value == award_empno) return;

                award_empno = value;
                OnValueChanged("Award_empno");
            }
        }
        private string award_date;//수상일자
        public string Award_date
        {
            get { return award_date; }
            set
            {
                if (value == award_date) return;

                award_date = value;
                OnValueChanged("Award_date");
            }
        }

        private string award_type;//수상종류
        public string Award_type
        {
            get { return award_type; }
            set
            {
                if (value == award_type) return;

                award_type = value;
                OnValueChanged("Award_type");
            }
        }
        public string Award_type_Cd
        {
            get { return Utility.GetCode(award_type); }
        }

        private string award_no;//수여번호
        public string Award_no
        {
            get { return award_no; }
            set
            {
                if (value == award_no) return;

                award_no = value;
                OnValueChanged("Award_no");
            }
        }
        private string award_kind;//수상종별
        public string Award_kind
        {
            get { return award_kind; }
            set
            {
                if (value == award_kind) return;

                award_kind = value;
                OnValueChanged("Award_kind");
            }
        }
        private string award_organ;//시행처
        public string Award_organ
        {
            get { return award_organ; }
            set
            {
                if (value == award_organ) return;

                award_organ = value;
                OnValueChanged("Award_organ");
            }
        }
        private string award_content;//수상내용
        public string Award_content
        {
            get { return award_content; }
            set
            {
                if (value == award_content) return;

                award_content = value;
                OnValueChanged("Award_content");
            }
        }
        private string award_inout;//내외구분
        public string Award_inout
        {
            get { return award_inout; }
            set
            {
                if (value == award_inout) return;

                award_inout = value;
                OnValueChanged("Award_inout");
            }
        }
        private string award_pos;//직급(당시)
        public string Award_pos
        {
            get { return award_pos; }
            set
            {
                if (value == award_pos) return;

                award_pos = value;
                OnValueChanged("Award_pos");
            }
        }
        private string award_dept;//소속(당시)
        public string Award_dept
        {
            get { return award_dept; }
            set
            {
                if (value == award_dept) return;

                award_dept = value;
                OnValueChanged("Award_dept");
            }
        }



        public string Key1 { get; set; }
        public string Key2 { get; set; }

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


            }
            return validationMessage;
        }
        /*---------------------------------------------------------------------------*/
        #endregion
    }
}
