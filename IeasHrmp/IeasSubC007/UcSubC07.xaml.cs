using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Markup;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Configuration;
using System.ComponentModel;
using IeasLibrary;


namespace IeasSubC07
{

    public partial class UserControl1 : UserControl
    {
        #region 초기 설정
        OracleConnection con = null;
        Utility authority = null;
        BindingList<UcSubC07ViewModel> myViewModel;

        public UserControl1()
        {
            InitializeComponent();
            /*----ViewModel 설정------------------------------*/
            myViewModel = new BindingList<UcSubC07ViewModel>();
            dataGrid.ItemsSource = myViewModel;
            myViewModel.ListChanged += OnListChanged;
        }
        //************************************************************
        // 론처로 부터 초기 설정값 넘겨 받기
        //************************************************************
        public string UserId { get; set; }           // 사용자 ID
        public string UserNm { get; set; }           // 사용자 이름
        public string UserType { get; set; }         // 사용자 유형
        public string ProgramName { get; set; }      // 프로그램 이름
        public string Auth { get; set; }             // 사용권한
        public string PersonalInfo { get; set; }     // 개인정보화면 여부
        public string MyIpAddress { get; set; }      // 사용자 IP Address
        public TextBox SearchCount { get; set; }     // 검색건수 박스 
        public TextBox UserMessage { get; set; }     // 메세지 박스
        public Button[] MainBtn { get; set; }        // 메인기능버튼

        //************************************************************
        //** 단위업무 초기 로드 시
        //************************************************************
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            authority = new Utility();
            authority.ParseAuth(Auth);
            edu_majdeep.ItemsSource = (new UcSubC07ViewModel()).Edu_majdeep_set;

            Utility.SetFuncBtn(MainBtn, "0");
            Utility.SetComboWithCdnm(sel_bas_pos, SQLStatement.SelectSQL2);
            Utility.SetComboWithCdnm(edu_loe, SQLStatement.SelectSQL4);
            Utility.SetComboWithCdnm(edu_gratype, SQLStatement.SelectSQL5);
        }
        #endregion

        #region 기능버튼(조회) Click
        //************************************************************
        //** 조회 버튼 Click
        //************************************************************
        public void BtnSearch_Click()
        {
            try
            {
                con = Utility.SetOracleConnection();
                OracleCommand cmd = con.CreateCommand();

                cmd.CommandText = SQLStatement.SelectSQL1;
                cmd.Parameters.Add("bas_empno", OracleDbType.Varchar2).Value = sel_bas_empno.Text + "%";
                cmd.Parameters.Add("bas_name", OracleDbType.Varchar2).Value = sel_bas_name.Text + "%";
                cmd.Parameters.Add("bas_dept", OracleDbType.Varchar2).Value = Utility.GetCode(sel_bas_dept.Text) + "%";
                cmd.Parameters.Add("bas_pos", OracleDbType.Varchar2).Value = sel_bas_pos.Text + "%";
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "TAB");

                dataGrid2.ItemsSource = ds.Tables["TAB"].DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            finally
            {
                if (con != null) con.Close();
            }
            myViewModel?.Clear();
            sel_bas_empno.Text = "";
            sel_bas_name.Text = "";

            Utility.SetFuncBtn(MainBtn, "0");
        }
        #endregion
        #region  직원 목록 Double Click(현직책 조회)
        //************************************************************
        //** 직원 목록 Double Click(현직책 조회)
        //************************************************************
        private void TableView2_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (authority.Read.Equals("0"))
            {
                Utility.MsgAuthorityViolation("조회");
                return;
            }

            OnMouseDoubleClick();
        }
        //*-----------------------------------------------------------
        private void OnMouseDoubleClick()
        {
            if (dataGrid2.SelectedItems.Count <= 0) return;

            myViewModel?.Clear();
            DataRowView drv = (DataRowView)dataGrid2.SelectedItem;
            edu_empno.Text = (string)drv.Row["bas_empno"];
            bas_name.Text = (string)drv.Row["bas_name"];
            //--DB Handling(Start)-------------------------------------
            try
            {
                con = Utility.SetOracleConnection();
                OracleCommand cmd = con.CreateCommand();
                cmd.CommandText = SQLStatement.SelectSQL;
                cmd.Parameters.Add("edu_empno", OracleDbType.Varchar2).Value = edu_empno.Text;
                OracleDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    var data = new UcSubC07ViewModel
                    {
                        Edu_empno = dr.GetString(0),
                        Edu_loe = dr.GetString(1),
                        Edu_gratype = dr.IsDBNull(2) ? "" : dr.GetString(2),
                        Edu_entdate = Utility.FormatDate(dr.GetString(3)),
                        Edu_gradate = dr.IsDBNull(4) ? "" : Utility.FormatDate(dr.GetString(4)),
                        Edu_acqdate = dr.IsDBNull(5) ? "" : Utility.FormatDate(dr.GetString(5)),
                        Edu_schnm = dr.IsDBNull(6) ? "" : dr.GetString(6),
                        Edu_majdiv = dr.IsDBNull(7) ? "" : dr.GetString(7),
                        Edu_maj = dr.IsDBNull(8) ? "" : dr.GetString(8),
                        Edu_degree = dr.IsDBNull(9) ? "" : dr.GetString(9),
                        Edu_country = dr.IsDBNull(10) ? "" : dr.GetString(10),
                        Edu_majdeep = dr.IsDBNull(11) ? "" : dr.GetString(11),
                        Edu_last = dr.IsDBNull(12) ? "N" : dr.GetString(12),
                        Key1 = dr.GetString(0),
                        Key2 = dr.GetString(1),
                        Key3 = dr.GetString(3),
                        DataStatus = ""
                    };
                    myViewModel.Add(data);
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            finally
            {
                if (con != null) con.Close();
            }
            //--DB Handling(End)-------------------------------------
            SearchCount.Text = myViewModel.Count.ToString();
            if (myViewModel.Count == 0)
            {
                UserMessage.Text = "조건을 만족하는 자료가 없습니다.";
                Utility.SetFuncBtn(MainBtn, "1");
                return;
            }
            UserMessage.Text = "자료가 정상적으로 조회 되었습니다.";
            Utility.SelectingFocusingGridControl(dataGrid, tableView, 0);
            Utility.SetFuncBtn(MainBtn, "2");
        }
        #endregion
        #region 기능버튼(입력) Click
        //************************************************************
        //** 입력 버튼 Click 
        //************************************************************
        public void BtnInsert_Click(int type)
        {
            if (authority.Insert.Equals("0"))
            {
                Utility.MsgAuthorityViolation("입력");
                return;
            }
            int rowIndex = tableView.FocusedRowHandle;
            if (dataGrid.SelectedItems.Count < 1)
            {
                rowIndex = -1;
            }
            rowIndex++;
            UcSubC07ViewModel data = new UcSubC07ViewModel();

            //----데이터 복제(Start)----------------------------------------------------------------------------------
            if ((type == 2) && (dataGrid.SelectedItem != null))
            {
                for (int i = 0; i <= dataGrid.Columns.Count - 1; i++)
                {
                    tableView.Grid.SetCellValue(rowIndex, dataGrid.Columns[i],
                                                          tableView.Grid.GetCellValue(rowIndex - 1, dataGrid.Columns[i]));
                }
                data.DataStatus = "A";
            }
            //----데이터 복제(End)----------------------------------------------------------------------------------

            //---초기화 설정(2019.10.15)--------------
            data.Edu_empno = edu_empno.Text;
            myViewModel.Insert(rowIndex, data);
            SearchCount.Text = myViewModel.Count.ToString();
            //추가된 Row 선택 및 Focus 이동
            Utility.SelectingFocusingGridControl(dataGrid, tableView, rowIndex);
            //최초 입력 Control로 Focus 이동
            edu_loe.Focus();

            Utility.SetFuncBtn(MainBtn, "3");
        }
        #endregion
        #region 기능버튼(수정) Click
        //************************************************************
        //** 수정 버튼 Click (현재 미사용)
        //************************************************************
        public void BtnUpdate_Click()
        {
            MessageBox.Show("수정버튼이 Click 되었습니다.");
        }
        #endregion
        #region 기능버튼(삭제) Click
        //************************************************************
        //** 삭제 버튼 Click (삭제는 DATA 1건씩 처리)
        //************************************************************
        public void BtnDelete_Click()
        {
            if (dataGrid.SelectedItems.Count < 1)
            {
                MessageBox.Show("삭제할 자료를 먼저 선택하세요.", "삭제확인", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            UcSubC07ViewModel vm = (UcSubC07ViewModel)dataGrid.SelectedItem;
            //신규 입력중인 자료는 단순하게 Grid에서 제거만 한다.
            if (vm.DataStatus.Equals("A"))
            {
                myViewModel.Remove(vm);
                SearchCount.Text = myViewModel.Count.ToString();
                return;
            }
            //----------------------------------------------------------------
            if (authority.Delete.Equals("0"))
            {
                Utility.MsgAuthorityViolation("삭제");
                return;
            }

            if (MessageBox.Show(vm.Edu_loe + " 자료를 삭제하시겠습니까?", "삭제확인", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
            {
                return;
            }
            //--DB Handling(Start)-------------------------------------
            try
            {
                con = Utility.SetOracleConnection();
                OracleCommand cmd = con.CreateCommand();
                cmd.CommandText = SQLStatement.DeleteSQL;
                cmd.Parameters.Add("key1", OracleDbType.Varchar2).Value = vm.Key1;
                cmd.Parameters.Add("key2", OracleDbType.Varchar2).Value = vm.Key2;
                cmd.Parameters.Add("key3", OracleDbType.Varchar2).Value = vm.Key3;
                if (cmd.ExecuteNonQuery() > 0)
                {
                    myViewModel.Remove(vm);
                    SearchCount.Text = myViewModel.Count.ToString();
                    UserMessage.Text = "자료가 정상적으로 삭제 되었습니다.";
                }
                else
                {
                    UserMessage.Text = "자료삭제에 문제가 있습니다. 시스템 담당자에게 문의하세요.";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            finally
            {
                if (con != null) con.Close();
            }
            //--DB Handling(End)-------------------------------------
        }
        #endregion
        #region 기능버튼(저장) Click
        //************************************************************
        //** 저장 버튼 Click (여러 건의 DATA 추가입력/수정 후 저장)
        //************************************************************
        public void BtnSave_Click()
        {
            if (MessageBox.Show("입력 및 수정중인 자료를 저장합니다.", "저장확인", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No) return;

            if (!InputCheck()) return;

            OracleTransaction tran = null;
            try
            {
                con = Utility.SetOracleConnection();
                tran = con.BeginTransaction(IsolationLevel.ReadCommitted);
                OracleCommand cmd = con.CreateCommand();
                cmd.BindByName = true;
                cmd.Transaction = tran;
                for (int i = 0; i <= myViewModel.Count - 1; i++)
                {
                    UcSubC07ViewModel vm = (UcSubC07ViewModel)myViewModel.ElementAt(i);
                    if (vm.DataStatus.Equals("")) continue;
                    if (vm.DataStatus.Equals("A"))
                    {
                        cmd.CommandText = SQLStatement.InsertSQL;
                    }
                    if (vm.DataStatus.Equals("U"))
                    {
                        cmd.CommandText = SQLStatement.UpdateSQL;
                        cmd.Parameters.Add("key1", OracleDbType.Varchar2).Value = vm.Key1;
                        cmd.Parameters.Add("key2", OracleDbType.Varchar2).Value = vm.Key2;
                        cmd.Parameters.Add("key3", OracleDbType.Varchar2).Value = vm.Key3;
                    }
                    cmd.Parameters.Add("edu_empno", OracleDbType.Varchar2).Value = vm.Edu_empno;
                    cmd.Parameters.Add("edu_loe", OracleDbType.Varchar2).Value = vm.Edu_loe_Cd;
                    cmd.Parameters.Add("edu_gratype", OracleDbType.Varchar2).Value = vm.Edu_gratype_Cd;
                    cmd.Parameters.Add("edu_entdate", OracleDbType.Varchar2).Value = Utility.FormatDateR(vm.Edu_entdate);
                    cmd.Parameters.Add("edu_gradate", OracleDbType.Varchar2).Value = Utility.FormatDateR(vm.Edu_gradate);
                    cmd.Parameters.Add("edu_acqdate", OracleDbType.Varchar2).Value = Utility.FormatDateR(vm.Edu_acqdate);
                    cmd.Parameters.Add("edu_schnm", OracleDbType.Varchar2).Value = vm.Edu_schnm_Cd;
                    cmd.Parameters.Add("edu_majdiv", OracleDbType.Varchar2).Value = vm.Edu_majdiv_Cd;
                    cmd.Parameters.Add("edu_maj", OracleDbType.Varchar2).Value = vm.Edu_maj;
                    cmd.Parameters.Add("edu_degree", OracleDbType.Varchar2).Value = vm.Edu_degree;
                    cmd.Parameters.Add("edu_country", OracleDbType.Varchar2).Value = vm.Edu_country_Cd;
                    cmd.Parameters.Add("edu_majdeep", OracleDbType.Varchar2).Value = vm.Edu_majdeep_Cd;
                    cmd.Parameters.Add("edu_last", OracleDbType.Varchar2).Value = vm.Edu_last;
                    cmd.Parameters.Add("datasys3", OracleDbType.Varchar2).Value = string.Concat(UserId, ":", UserNm);

                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();  //*----반드시 포함
                }
                tran.Commit();
            }
            catch (Exception ex)
            {
                tran.Rollback();
                MessageBox.Show(ex.Message);
                return;
            }
            finally
            {
                if (con != null) con.Close();
            }
            //**정상 저장 후 초기화*******************************************************
            for (int i = 0; i <= myViewModel.Count - 1; i++)
            {
                UcSubC07ViewModel vm = (UcSubC07ViewModel)myViewModel.ElementAt(i);
                if (vm.DataStatus.Equals("")) continue;
                vm.Key1 = vm.Edu_empno;
                vm.Key2 = vm.Edu_loe;
                vm.Key3 = vm.Edu_entdate;
                vm.DataStatus = "";
            }
            dataGrid.RefreshData();
            UserMessage.Text = "자료가 정상적으로 저장 되었습니다.";
            Utility.SetFuncBtn(MainBtn, "2");
        }
        #endregion
        #region 기능버튼(취소/인쇄/엑셀/종료) Click
        //************************************************************
        //** 취소 버튼 Click
        //************************************************************
        public void BtnCancel_Click()
        {
            if (MessageBox.Show("입력 및 수정중인 자료를 취소합니다.", "취소메세지", MessageBoxButton.YesNo) == MessageBoxResult.No) return;

            OnMouseDoubleClick();
        }
        //************************************************************
        //** 인쇄 버튼 Click
        //************************************************************
        public void BtnPrint_Click()
        {
            MessageBox.Show("인쇄 버튼이 Click 되었습니다.");
        }
        //************************************************************
        //** 엑셀 버튼 Click
        //************************************************************
        public void BtnExcel_Click()
        {
            MessageBox.Show("Excel 버튼이 Click 되었습니다.");
        }
        //************************************************************
        //** 종료 버튼 Click
        //************************************************************
        public void BtnClose_Click()
        {
            if (con != null) con.Close();
        }
        #endregion
        #region KeyBoard 기능버튼 이벤트 핸들링
        //************************************************************
        //** PF1 Key Click (PF1 ~ PF12 까지 이벤트 정의하여 사용가능)==> 론처로부터 발생 이벤트
        //************************************************************
        public void PF1_Click()
        {
            MessageBox.Show("PF1 Key Pressed");
        }
        public void PF3_Click()
        {
            BtnSearch_Click();
        }
        //************************************************************
        //** Insert Key Click (론처로부터 발생 이벤트)
        //************************************************************
        public void InsertKey_Click()
        {
            BtnInsert_Click(1);
        }
        //************************************************************
        //** Delete Key Click (론처로부터 발생 이벤트)
        //************************************************************
        public void DeleteKey_Click()
        {
            BtnDelete_Click();
        }
        //************************************************************
        //** CTRL + Insert Key Click (론처로부터 발생 이벤트)
        //************************************************************
        public void CtrlInsertKey_Click()
        {
            BtnInsert_Click(2);
        }
        #endregion
        #region 입력값 정합성 Check
        //************************************************************
        //** 입력값의 정합성 Check
        //************************************************************
        private Boolean InputCheck()
        {
            if (myViewModel.Count <= 0)
            {
                MessageBox.Show("저장할 DATA가 없습니다.");
                return false;
            }
            for (int i = 0; i <= myViewModel.Count - 1; i++)
            {
                UcSubC07ViewModel vm = (UcSubC07ViewModel)myViewModel.ElementAt(i);
                if (vm.DataStatus.Equals("")) continue;   //수정 및 신규입력 자료만 입력 Check

                if (vm.HasError)
                {
                    Utility.ShowValidationCheckMsg(vm.GetErrorMsg, i + 1);
                    return false;
                }
            }
            return true;
        }
        #endregion
        #region 자료수정 이벤트 발생 시 기능버튼 핸들링
        //************************************************************
        //** 자료에 수정이 발생했을 때 기능 버튼 핸들링
        //************************************************************
        private void OnListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.ItemChanged)
            {
                if (authority.Update.Equals("0"))
                {
                    UserMessage.Text = "자료를 수정할 권한이 없습니다.";
                    return;
                }
                Utility.SetFuncBtn(MainBtn, "3");
            }
        }
        #endregion
        #region 부서 코드를 입력시 부서코드/부서명 읽서오기
        //************************************************************
        //** 부서 코드를 입력시 부서코드/부서명 읽서오기
        //************************************************************
        private void Seach_user_id_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Utility.ShowSearchCDWindow(SQLStatement.SelectSQL3, "부서코드", out string result) == true)
            {
                //if (dataGrid.SelectedItems.Count < 1) return;
                //((UcSub02ViewModel)dataGrid.SelectedItem).Bas_dept = result;
                sel_bas_dept.Text = result;
                sel_bas_dept.Focus();
            }

        }
        private void Seach_user_id_MouseDown2(object sender, MouseButtonEventArgs e)
        {
            if (Utility.ShowSearchCDWindow(SQLStatement.SelectSQL6, "학교명", out string result) == true)
            {
                //if (dataGrid.SelectedItems.Count < 1) return;
                //((UcSub02ViewModel)dataGrid.SelectedItem).Bas_dept = result;
                edu_schnm.Text = result;
                edu_schnm.Focus();
            }

        }
        private void Seach_user_id_MouseDown3(object sender, MouseButtonEventArgs e)
        {
            if (Utility.ShowSearchCDWindow(SQLStatement.SelectSQL8, "취득국가", out string result) == true)
            {
                //if (dataGrid.SelectedItems.Count < 1) return;
                //((UcSub02ViewModel)dataGrid.SelectedItem).Bas_dept = result;
                edu_country.Text = result;
                edu_country.Focus();
            }

        }
        private void Seach_user_id_MouseDown4(object sender, MouseButtonEventArgs e)
        {
            if (Utility.ShowSearchCDWindow(SQLStatement.SelectSQL7, "전공계열", out string result) == true)
            {
                //if (dataGrid.SelectedItems.Count < 1) return;
                //((UcSub02ViewModel)dataGrid.SelectedItem).Bas_dept = result;
                edu_majdiv.Text = result;
                edu_majdiv.Focus();
            }

        }

        #endregion
    }
}
