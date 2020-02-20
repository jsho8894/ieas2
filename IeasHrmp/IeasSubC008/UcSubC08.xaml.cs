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
using DevExpress.XtraGrid;
using DevExpress.Xpf.Core;
using DevExpress.Xpf.Grid;

namespace IeasSubC08
{

    public partial class UserControl1 : UserControl
    {
        #region 초기 설정
        OracleConnection con = null;
        Utility authority = null;
        BindingList<UcSubC08ViewModel> myViewModel;

        bool[] dbread = new bool[] { false, false, false, false, false, false, false, false };

        public UserControl1()
        {
            InitializeComponent();
            /*----ViewModel 설정------------------------------*/
            myViewModel = new BindingList<UcSubC08ViewModel>();
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
            Utility.SetComboWithCdnm(searchText_pos, SQLStatement.SelectSQL2);
            SQLStatement.Setsql();


            Utility.SetFuncBtn(MainBtn, "1");
            //*--DB => ComboBox--------------------------------------------

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
                cmd.Parameters.Add("bas_empno", OracleDbType.Varchar2).Value = searchText_empno.Text + "%";
                cmd.Parameters.Add("bas_name", OracleDbType.Varchar2).Value = searchText_name.Text + "%";
                cmd.Parameters.Add("bas_dept", OracleDbType.Varchar2).Value = Utility.GetCode(searchText_dept.Text) + "%";
                cmd.Parameters.Add("bas_pos", OracleDbType.Varchar2).Value = searchText_pos.Text + "%";
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "TAB");

                dataGrid.ItemsSource = ds.Tables["TAB"].DefaultView;
            }
            catch (Exception ex)
            {
                return;
            }
            finally
            {
                if (con != null) con.Close();
            }
            
           /* bas_empno.Text = "";
            bas_resno.Text = "";
            bas_name.Text = "";
            bas_cname.Text = "";
            bas_ename.Text = "";

            bas_hdpno.Text = "";
            bas_telno.Text = "";
            bas_email.Text = "";
            bas_mil_sta.Text = "";
            bas_mil_mil.Text = "";
            bas_mil_rnk.Text = "";

            bas_resdate.Text = "";
            bas_levdate.Text = "";
            bas_reidate.Text = "";


            bas_wsta.Text = "";
            bas_sts.Text = "";
            bas_pos.Text = "";
            bas_dut.Text = "";
            bas_dept.Text = "";
            bas_rmk.Text = "";
            */

           
            /*-------초기화---------------*/
            searchText_empno.Text = "";
            searchText_name.Text = "";
            Utility.SelectingFocusingGridControl(dataGrid, tableView, 1);
            Utility.SetFuncBtn(MainBtn, "0");
        }
        #endregion
        #region  교원전체정보 Double Click(전체 인사기록 조회)
        //************************************************************
        //** 직원 목록 Double Click(전체 인사기록 조회)
        //************************************************************
        private void TableView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (authority.Read.Equals("0"))
            {
                Utility.MsgAuthorityViolation("조회");
                return;
            }
            tableView_MouseDown(null,null);
        }
        //*-----------------------------------------------------------
        private void tableView_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (dataGrid.SelectedItems.Count <= 0) return;

            dataGrid1.ItemsSource = null;
            dataGrid2.ItemsSource = null;
            dataGrid3.ItemsSource = null;
            dataGrid4.ItemsSource = null;
            dataGrid5.ItemsSource = null;
            dataGrid6.ItemsSource = null;
            for (int i = 0; i < 8; i++) dbread[i] = false;

            DataRowView drv = (DataRowView)dataGrid.SelectedItem;
            bas_empno.Text = (string)drv.Row["bas_empno"];
            //--DB Handling(Start)-------------------------------------
            try
            {
                con = Utility.SetOracleConnection();
                OracleCommand cmd = con.CreateCommand();
                cmd.BindByName = true;
                cmd.CommandText = SQLStatement.SelectSQL;
                cmd.Parameters.Add("bas_empno", OracleDbType.Varchar2).Value = bas_empno.Text;
                OracleDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    bas_empno.Text = dr[0].ToString();
                    bas_resno.Text = dr[1].ToString();
                    bas_name.Text = dr[2].ToString();
                    
                    bas_cname.Text = dr[3].ToString();
                    bas_ename.Text = dr[4].ToString();
                    bas_sex.Text = dr[5].ToString();
                    bas_nat.Text = dr[6].ToString();
                    bas_ad1.Text = dr[7].ToString();
                    bas_ad2.Text = dr[8].ToString();
                    bas_pos.Text = dr[9].ToString();
                    bas_pt1.Text = dr[10].ToString();
                    bas_pt2.Text = dr[11].ToString();
                    bas_pt3.Text = dr[12].ToString();
                    bas_dut.Text = dr[13].ToString();
                    bas_dept.Text = dr[14].ToString();
                    bas_dept2.Text = dr[15].ToString();
                    bas_cpodate.Text = Utility.FormatDate(dr[16].ToString());
                    bas_cdudate.Text = Utility.FormatDate(dr[17].ToString());
                    bas_cdedate.Text = Utility.FormatDate(dr[18].ToString());
                    bas_subject.Text = dr[19].ToString();
                    bas_dean_dept.Text = dr[20].ToString();
                    bas_cont_mm.Text = dr[21].ToString();
                    bas_emp_sdate.Text = Utility.FormatDate(dr[22].ToString());
                    bas_emp_edate.Text = Utility.FormatDate(dr[23].ToString());
                
                    bas_emp_period.Text = dr[24].ToString();

                    bas_femp_date.Text = Utility.FormatDate(dr[25].ToString());
                    bas_cemp_date.Text = Utility.FormatDate(dr[26].ToString());
                    bas_emp_date.Text = Utility.FormatDate(dr[27].ToString());
                    bas_resdate.Text = Utility.FormatDate(dr[28].ToString());
                    bas_retdate.Text = Utility.FormatDate(dr[29].ToString());
                    bas_frq.Text = dr[30].ToString();
                    bas_passport.Text = dr[31].ToString();
                    bas_kfta.Text = dr[32].ToString();
                    bas_zip.Text = dr[33].ToString();
                    bas_zipaddr.Text = dr[34].ToString();
                    bas_hdpno.Text = dr[35].ToString();
                    bas_telno.Text = dr[36].ToString();
                    bas_email.Text = dr[37].ToString();
                    bas_bsks.Text = dr[38].ToString();
                    bas_job_comnm.Text = dr[39].ToString();
                    bas_job_pos.Text = dr[40].ToString();
                    bas_job_telno.Text = dr[41].ToString();
                    bas_levdate.Text = Utility.FormatDate(dr[41].ToString());
                    bas_reidate.Text = Utility.FormatDate(dr[42].ToString());
                    bas_wsta.Text = dr[43].ToString();

                    bas_sts.Text = dr[44].ToString();
                    bas_res.Text = dr[45].ToString();
                    bas_loa.Text = dr[46].ToString();
                
                    bas_univ_wys.Text = dr[47].ToString();
                    bas_ind_wys.Text = dr[48].ToString();

                    bas_mil_sta.Text = dr[49].ToString();
                    bas_mil_no.Text = dr[50].ToString();
                    bas_mil_mil.Text = dr[51].ToString();
                    bas_mil_rnk.Text = dr[52].ToString();
                    bas_mil_sdate.Text = Utility.FormatDate(dr[53].ToString());
                    bas_mil_edate.Text = Utility.FormatDate(dr[54].ToString());
                    bas_rmk.Text = dr[55].ToString();



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
            UserMessage.Text = "자료가 정상적으로 조회 되었습니다.";
            Utility.SetFuncBtn2(MainBtn, "1");
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
            UcSubC08ViewModel data = new UcSubC08ViewModel();
            myViewModel.Insert(rowIndex, data);
            //----데이터 복제----------------------------------------------------------------------------------
            if ((type == 2) && (dataGrid.SelectedItem != null))
            {
                for (int i = 0; i <= dataGrid.Columns.Count - 1; i++)
                {
                    tableView.Grid.SetCellValue(rowIndex, dataGrid.Columns[i],
                                                          tableView.Grid.GetCellValue(rowIndex - 1, dataGrid.Columns[i]));
                }
                data.DataStatus = "A";
            }
            //----데이터 복제----------------------------------------------------------------------------------
            SearchCount.Text = myViewModel.Count.ToString();
            //추가된 Row 선택 및 Focus 이동
            Utility.SelectingFocusingGridControl(dataGrid, tableView, rowIndex);
            //최초 입력 Control로 Focus 이동
            bas_empno.Focus();

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

            UcSubC08ViewModel vm = (UcSubC08ViewModel)dataGrid.SelectedItem;
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

            if (MessageBox.Show(vm.Bas_empno + " 자료를 삭제하시겠습니까?", "삭제확인", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
            {
                return;
            }
            //--DB Handling(Start)-------------------------------------
            try
            {
                con = Utility.SetOracleConnection();
                OracleCommand cmd = con.CreateCommand();
                //cmd.CommandText = SQLStatement.DeleteSQL;
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
            if (MessageBox.Show("입력 및 수정중인 자료를 저장합니다.", "저장확인",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No) return;

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
                    UcSubC08ViewModel vm = (UcSubC08ViewModel)myViewModel.ElementAt(i);
                    if (vm.DataStatus.Equals("")) continue;
                    if (vm.DataStatus.Equals("A"))
                    {
                    }

                    if (vm.DataStatus.Equals("U"))
                    {
                    }
                    if (vm.DataStatus.Equals("U"))
                    {
                        cmd.Parameters.Add("key1", OracleDbType.Varchar2).Value = vm.Key1;
                    }
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
                UcSubC08ViewModel vm = (UcSubC08ViewModel)myViewModel.ElementAt(i);
                if (vm.DataStatus.Equals("")) continue;
                vm.Key1 = vm.Bas_empno;
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

            BtnSearch_Click();
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
                UcSubC08ViewModel vm = (UcSubC08ViewModel)myViewModel.ElementAt(i);
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
                    Utility.MsgAuthorityViolation("수정");
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
        /*private void Search_code_Click(object sender, RoutedEventArgs e)
        {
            if (Utility.ShowSearchCDWindow(SQLStatement.SelectSQL10, "부서코드", out string result) == true)
            {
                if (dataGrid.SelectedItems.Count < 1) return;
                ((UcSubC08ViewModel)dataGrid.SelectedItem).Bas_dept = result;

            }
        }*/
        private void Seach_user_id_MouseDown(object sender, MouseButtonEventArgs e)
        {

            if (Utility.ShowSearchCDWindow(SQLStatement.SelectSQL10, "부서코드", out string result) == true)
            {
                //if (dataGrid.SelectedItems.Count < 1) return;
                //((UcSubC08ViewModel)dataGrid.SelectedItem).Bas_dept = result;
                searchText_dept.Text = result;
                searchText_dept.Focus();
            }

        }
        #endregion

        #region 전체 기록조회
        private void TabItem_GotFocus(object sender, RoutedEventArgs e)
        {
            TabItem ti = (TabItem)sender;
            int tag = Convert.ToInt16(ti.Tag);

            if (dbread[tag]) return;
            dbread[tag] = true;

            try
            {
                con = Utility.SetOracleConnection();
                OracleCommand cmd = con.CreateCommand();

                cmd.CommandText = SQLStatement.SelectSQL3[tag];
                cmd.Parameters.Add("bas_empno", OracleDbType.Varchar2).Value = bas_empno.Text+"%";
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "TAB");

                var grid = (GridControl)this.FindName("dataGrid" + tag.ToString());
                grid.ItemsSource = ds.Tables["TAB"].DefaultView;


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
        }



        #endregion
    }
}
