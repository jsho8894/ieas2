using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using DevExpress.XtraEditors.DXErrorProvider;
using IeasLibrary;

namespace IeasSubC04
{
    public class UcSubC04ViewModel : Notifier, IDataErrorInfo
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
        private string cmt_empno;//사원번호
        public string Cmt_empno
        {
            get { return cmt_empno; }
            set
            {
                if (value == cmt_empno) return;

                cmt_empno = value;
                OnValueChanged("Cmt_empno");
            }
        }
        private string cmt_cmtnm;//위원회
        public string Cmt_cmtnm
        {
            get { return cmt_cmtnm; }
            set
            {
                if (value == cmt_cmtnm) return;

                cmt_cmtnm = value;
                OnValueChanged("Cmt_cmtnm");
            }
        }

        private string cmt_sdate;//임명일자
        public string Cmt_sdate
        {
            get { return cmt_sdate; }
            set
            {
                if (value == cmt_sdate) return;

                cmt_sdate = value;
                OnValueChanged("Cmt_sdate");
            }
        }
        private string cmt_edate;//임면일자
        public string Cmt_edate
        {
            get { return cmt_edate; }
            set
            {
                if (value == cmt_edate) return;

                cmt_edate = value;
                OnValueChanged("Cmt_edate");
            }
        }



        public string Key1 { get; set; }

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
