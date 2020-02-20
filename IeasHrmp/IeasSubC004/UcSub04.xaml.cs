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


namespace IeasSubC04
{

    public partial class UserControl1 : UserControl
    {
        #region 초기 설정
        OracleConnection con = null;
        Utility authority = null;
        BindingList<UcSubC04ViewModel> myViewModel;

        public UserControl1()
        {
            InitializeComponent();
            /*----ViewModel 설정------------------------------*/
            myViewModel = new BindingList<UcSubC04ViewModel>();
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

            Utility.SetFuncBtn(MainBtn, "0");
            Utility.SetComboWithCdnm(sel_bas_pos, SQLStatement.SelectSQL3);
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
        #region  직원 목록 Double Click(위원회 조회)
        //************************************************************
        //** 직원 목록 Double Click(위원회 조회)
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
            cmt_empno.Text = (string)drv.Row["bas_empno"];
            bas_name.Text = (string)drv.Row["bas_name"];
            //--DB Handling(Start)-------------------------------------
            try
            {
                con = Utility.SetOracleConnection();
                OracleCommand cmd = con.CreateCommand();
                cmd.CommandText = SQLStatement.SelectSQL;
                cmd.Parameters.Add("cmt_empno", OracleDbType.Varchar2).Value = cmt_empno.Text;
                OracleDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    var data = new UcSubC04ViewModel
                    {
                        Cmt_empno = dr.GetString(0),
                        Cmt_cmtnm = dr.GetString(1),
                        Cmt_sdate = Utility.FormatDate(dr.GetString(2)),
                        Cmt_edate = Utility.FormatDate(dr.GetString(3)),
                        Key1 = dr.GetString(0),
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
            UcSubC04ViewModel data = new UcSubC04ViewModel();
            myViewModel.Insert(rowIndex, data);
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
            data.Cmt_empno = cmt_empno.Text;

            SearchCount.Text = myViewModel.Count.ToString();
            //추가된 Row 선택 및 Focus 이동
            Utility.SelectingFocusingGridControl(dataGrid, tableView, rowIndex);
            //최초 입력 Control로 Focus 이동
            cmt_cmtnm.Focus();

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

            UcSubC04ViewModel vm = (UcSubC04ViewModel)dataGrid.SelectedItem;
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

            if (MessageBox.Show(vm.Cmt_cmtnm + " 자료를 삭제하시겠습니까?", "삭제확인", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
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
                    UcSubC04ViewModel vm = (UcSubC04ViewModel)myViewModel.ElementAt(i);
                    if (vm.DataStatus.Equals("")) continue;
                    if (vm.DataStatus.Equals("A"))
                    {
                        cmd.CommandText = SQLStatement.InsertSQL;
                    }
                    if (vm.DataStatus.Equals("U"))
                    {
                        cmd.CommandText = SQLStatement.UpdateSQL;
                        cmd.Parameters.Add("key1", OracleDbType.Varchar2).Value = vm.Key1;
                    }
                    cmd.Parameters.Add("cmt_empno", OracleDbType.Varchar2).Value = vm.Cmt_empno;
                    cmd.Parameters.Add("cmt_cmtnm", OracleDbType.Varchar2).Value = vm.Cmt_cmtnm;
                    cmd.Parameters.Add("cmt_sdate", OracleDbType.Varchar2).Value = Utility.FormatDateR(vm.Cmt_sdate);
                    cmd.Parameters.Add("cmt_edate", OracleDbType.Varchar2).Value = Utility.FormatDateR(vm.Cmt_edate);
                    cmd.Parameters.Add("datasys3", OracleDbType.Varchar2).Value = string.Concat(UserId, ":", UserNm);

                    /* if (vm.DataStatus.Equals("U"))
                     {
                         cmd.Parameters.Add("key1", OracleDbType.Varchar2).Value = vm.Key1;
                     }*/
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
                UcSubC04ViewModel vm = (UcSubC04ViewModel)myViewModel.ElementAt(i);
                if (vm.DataStatus.Equals("")) continue;
                vm.Key1 = vm.Cmt_empno;

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
                UcSubC04ViewModel vm = (UcSubC04ViewModel)myViewModel.ElementAt(i);
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
            if (Utility.ShowSearchCDWindow(SQLStatement.SelectSQL4, "부서코드", out string result) == true)
            {
                //if (dataGrid.SelectedItems.Count < 1) return;
                //((UcSub02ViewModel)dataGrid.SelectedItem).Bas_dept = result;
                sel_bas_dept.Text = result;
                sel_bas_dept.Focus();
            }
        }
        private void Seach_user_id_MouseDown2(object sender, MouseButtonEventArgs e)
        {
            if (Utility.ShowSearchCDWindow(SQLStatement.SelectSQL5, "위원회코드", out string result) == true)
            {
                if (dataGrid.SelectedItems.Count < 1) return;
                ((UcSubC04ViewModel)dataGrid.SelectedItem).Cmt_cmtnm = Utility.GetCodeNM(result);
                //result

            }
        }
        
        #endregion

    }
}
