using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using DevExpress.XtraEditors.DXErrorProvider;
using IeasLibrary;

namespace IeasSubC30
{
    public class UcSubC30ViewModel : Notifier, IDataErrorInfo
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
        /// 위원회 이력
        /// </summary>
        private string pnm_empno;//사원번호
        public string Pnm_empno
        {
            get { return pnm_empno; }
            set
            {
                if (value == pnm_empno) return;

                pnm_empno = value;
                OnValueChanged("Pnm_empno");
            }
        }
        private string pnm_date;//징계일자
        public string Pnm_date
        {
            get { return pnm_date; }
            set
            {
                if (value == pnm_date) return;

                pnm_date = value;
                OnValueChanged("Pnm_date");
            }
        }

        private string pnm_type;//징계종류
        public string Pnm_type
        {
            get { return pnm_type; }
            set
            {
                if (value == pnm_type) return;

                pnm_type = value;
                OnValueChanged("Pnm_type");
            }
        }
        public string Pnm_type_Cd
        {
            get { return Utility.GetCode(pnm_type); }
        }
        private string pnm_content;//징계내용
        public string Pnm_content
        {
            get { return pnm_content; }
            set
            {
                if (value == pnm_content) return;

                pnm_content = value;
                OnValueChanged("Pnm_content");
            }
        }
        private string pnm_pos;//직급(당시)
        public string Pnm_pos
        {
            get { return pnm_pos; }
            set
            {
                if (value == pnm_pos) return;

                pnm_pos = value;
                OnValueChanged("Pnm_pos");
            }
        }
        private string pnm_dept;//소속(당시)
        public string Pnm_dept
        {
            get { return pnm_dept; }
            set
            {
                if (value == pnm_dept) return;

                pnm_dept = value;
                OnValueChanged("Pnm_dept");
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
