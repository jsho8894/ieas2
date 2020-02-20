using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using DevExpress.XtraEditors.DXErrorProvider;
using IeasLibrary;

namespace IeasSubC06
{
    public class UcSubC06ViewModel : Notifier, IDataErrorInfo
    {
        #region Data Binding Model

        /// <summary>
        /// ///////////////////////////////////////////////////////기본사항
        /// </summary>
        /// 





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
        /// 타기관교육경력
        /// </summary>
        private string lecc_empno;//사원번호
        public string Lecc_empno
        {
            get { return lecc_empno; }
            set
            {
                if (value == lecc_empno) return;

                lecc_empno = value;
                OnValueChanged("Lecc_empno");
            }
        }
        private string lecc_sdate;//교육기간(부터)
        public string Lecc_sdate
        {
            get { return lecc_sdate; }
            set
            {
                if (value == lecc_sdate) return;

                lecc_sdate = value;
                OnValueChanged("Lecc_sdate");
            }
        }

        private string lecc_edate;//교육기간(까지)
        public string Lecc_edate
        {
            get { return lecc_edate; }
            set
            {
                if (value == lecc_edate) return;

                lecc_edate = value;
                OnValueChanged("Lecc_edate");
            }
        }
        private string lecc_eduinst;//교육기관
        public string Lecc_eduinst
        {
            get { return lecc_eduinst; }
            set
            {
                if (value == lecc_eduinst) return;

                lecc_eduinst = value;
                OnValueChanged("Lecc_eduinst");
            }
        }
        private string lecc_position;//직책
        public string Lecc_position
        {
            get { return lecc_position; }
            set
            {
                if (value == lecc_position) return;

                lecc_position = value;
                OnValueChanged("Lecc_position");
            }
        }

        private string lecc_career = "Y";//경력인정여부
        public string Lecc_career
        {
            get { return lecc_career; }
            set
            {
                if (value == lecc_career) return;

                lecc_career = value;
                OnValueChanged("Lecc_career");
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
