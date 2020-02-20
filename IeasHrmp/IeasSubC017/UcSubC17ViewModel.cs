using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using IeasLibrary;

namespace IeasSubC17
{
    public class UcSubC17ViewModel : Notifier, IDataErrorInfo
    {
        #region Data Binding Model
        private string papr_appno;
        public string Papr_appno
        {
            get { return papr_appno; }
            set
            {
                if (value == papr_appno) return;

                papr_appno = value;
                OnValueChanged("Papr_appno");
            }
        }

        private string papr_content;
        public string Papr_content
        {
            get { return papr_content; }
            set
            {
                if (value == papr_content) return;

                papr_content = value;
                OnValueChanged("Papr_content");
            }
        }

        private int papr_num =1;
        public int Papr_num
        {
            get { return papr_num; }
            set
            {
                if (value == papr_num) return;

                papr_num = value;
                OnValueChanged("Papr_num");
            }
        }

        private string papr_date;
        public string Papr_date
        {
            get { return papr_date; }
            set
            {
                if (value == papr_date) return;

                papr_date = value;
                OnValueChanged("Papr_date");
            }
        }


        private string key1;
        public string Key1
        {
            get { return key1; }
            set
            {
                if (value == key1) return;

                key1 = value;
                //****함수이름 차이에 주의하세요
                OnPropertyChanged("Key1");
            }
        }
        #endregion
        #region 고정된 코드값 정의
        public List<string> ColorSet
        {
            get
            {
                return new List<string>() { "", "RED", "WHITE", "BLACK", "YELLOW", "GREEN", "BLUE" };
            }
        }
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
                case "Papr_appno":
                    if (Utility.GetByteLength(papr_appno) <= 0)
                    {
                        validationMessage = SetErrorMsg(propertyName, "인사발령번호를 입력하세요");
                    }
                    break;
                case "Papr_content":
                    if (Utility.GetByteLength(papr_content) <= 0)
                    {
                        validationMessage = SetErrorMsg(propertyName, "내용을 입력하세요");
                    }
                    break;
                case "Papr_num":
                    if (papr_num <= 0)
                    {
                        validationMessage = SetErrorMsg(propertyName, "발령인원수가 미달되었습니다");
                    }
                    break;
            }
            return validationMessage;
        }
        /*---------------------------------------------------------------------------*/
        #endregion
    }
}
