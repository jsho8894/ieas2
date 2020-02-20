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


namespace IeasSubC02
{

    public partial class UserControl1 : UserControl
    {
        #region 초기 설정
        OracleConnection con = null;
        Utility authority = null;
        BindingList<UcSubC02ViewModel> myViewModel;

        public UserControl1()
        {
            InitializeComponent();
            /*----ViewModel 설정------------------------------*/
            myViewModel = new BindingList<UcSubC02ViewModel>();
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
            bas_sex.ItemsSource = (new UcSubC02ViewModel()).Sex_set;
            bas_cont_mm.ItemsSource = (new UcSubC02ViewModel()).Cont_mm_set;
            bas_wsta.ItemsSource = (new UcSubC02ViewModel()).Wsta_set;
            bas_mil_sta.ItemsSource = (new UcSubC02ViewModel()).Mil_sta_set;
            bas_kfta.ItemsSource = (new UcSubC02ViewModel()).kfta_set;
            bas_bsks.ItemsSource = (new UcSubC02ViewModel()).bsks_set;
            


            Utility.SetFuncBtn(MainBtn, "1");
            //*--DB => ComboBox--------------------------------------------
            Utility.SetComboWithCdnm(bas_nat, SQLStatement.SelectSQL1);
            Utility.SetComboWithCdnm(bas_ad1, SQLStatement.SelectSQL2);
            Utility.SetComboWithCdnm(bas_ad2, SQLStatement.SelectSQL3);
            Utility.SetComboWithCdnm(bas_pos, SQLStatement.SelectSQL4);
            Utility.SetComboWithCdnm(bas_pt1, SQLStatement.SelectSQL5);
            Utility.SetComboWithCdnm(bas_pt2, SQLStatement.SelectSQL6);
            Utility.SetComboWithCdnm(bas_pt3, SQLStatement.SelectSQL7);
            Utility.SetComboWithCdnm(bas_dut, SQLStatement.SelectSQL8);
            Utility.SetComboWithCdnm(bas_dept, SQLStatement.SelectSQL9);
            Utility.SetComboWithCdnm(bas_dept2, SQLStatement.SelectSQL9);
            Utility.SetComboWithCdnm(bas_dean_dept, SQLStatement.SelectSQL09);
            Utility.SetComboWithCdnm(bas_sts, SQLStatement.SelectSQL11);
            Utility.SetComboWithCdnm(bas_res, SQLStatement.SelectSQL12);
            Utility.SetComboWithCdnm(bas_loa, SQLStatement.SelectSQL13);
            Utility.SetComboWithCdnm(bas_mil_mil, SQLStatement.SelectSQL14);
            Utility.SetComboWithCdnm(bas_mil_rnk, SQLStatement.SelectSQL15);
        }
        #endregion

        #region 기능버튼(조회) Click
        //************************************************************
        //** 조회 버튼 Click
        //************************************************************
        public void BtnSearch_Click()
        {
            if (authority.Read.Equals("0"))
            {
                Utility.MsgAuthorityViolation("조회");
                return;
            }


            myViewModel?.Clear();
            //--DB Handling(Start)-------------------------------------
            try
            {
                con = Utility.SetOracleConnection();
                OracleCommand cmd = con.CreateCommand();
                cmd.CommandText = SQLStatement.SelectSQL;
                cmd.BindByName = true;
                cmd.Parameters.Add("bas_empno", OracleDbType.Varchar2).Value = searchText.Text + "%";
                cmd.Parameters.Add("bas_name", OracleDbType.Varchar2).Value = searchText_Copy.Text + "%";
                cmd.Parameters.Add("bas_dept", OracleDbType.Varchar2).Value = Utility.GetCode(searchText_Copy2.Text) + "%";
                cmd.Parameters.Add("bas_pos", OracleDbType.Varchar2).Value = searchText_Copy1.Text + "%";
                OracleDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    var data = new UcSubC02ViewModel
                    {
                        
                        Bas_empno = dr.GetString(0),
                        Bas_resno = dr.GetString(1) ,
                        Bas_name = dr[2].ToString(),
                        //dr.GetString(2), // 나중에 null못넣게 제거
                        Bas_cname = dr.IsDBNull(3) ? "" : dr.GetString(3),
                        Bas_ename = dr.IsDBNull(4) ? "" : dr.GetString(4),
                        Bas_sex = dr.IsDBNull(5) ? "" : dr.GetString(5),
                        Bas_nat = dr.IsDBNull(6) ? "" : dr.GetString(6),
                        Bas_ad1 = dr.IsDBNull(7) ? "" : dr.GetString(7),
                        Bas_ad2 = dr.IsDBNull(8) ? "" : dr.GetString(8),
                        Bas_pos = dr.IsDBNull(9) ? "" : dr.GetString(9), // 나중에 null못넣게 제거
                        Bas_pt1 = dr.IsDBNull(10) ? "" : dr.GetString(10),
                        Bas_pt2 = dr.IsDBNull(11) ? "" : dr.GetString(11),
                        Bas_pt3 = dr.IsDBNull(12) ? "" : dr.GetString(12),
                        Bas_dut = dr.IsDBNull(13) ? "" : dr.GetString(13),// 나중에 null못넣게 제거
                        Bas_dept = dr.IsDBNull(14) ? "" : dr.GetString(14),// 나중에 null못넣게 제거
                        Bas_dept2 = dr.IsDBNull(15) ? "" : dr.GetString(15),
                        Bas_cpodate = dr.IsDBNull(16) ? "" : Utility.FormatDate(dr.GetString(16)),
                        Bas_cdudate = dr.IsDBNull(17) ? "" : Utility.FormatDate(dr.GetString(17)),
                        Bas_cdedate = dr.IsDBNull(18) ? "" : Utility.FormatDate(dr.GetString(18)),
                        Bas_subject = dr.IsDBNull(19) ? "" : dr.GetString(19),
                        Bas_dean_dept = dr.IsDBNull(20) ? "" : dr.GetString(20),
                        Bas_cont_mm = dr.IsDBNull(21) ? "" : dr.GetString(21),
                        Bas_emp_sdate = dr.IsDBNull(22) ? "" : Utility.FormatDate(dr.GetString(22)),
                        Bas_emp_edate = dr.IsDBNull(23) ? "" : Utility.FormatDate(dr.GetString(23)),
                        
                        Bas_emp_period = dr.IsDBNull(24) ? 0 : dr.GetDouble(24),

                        Bas_femp_date = dr.IsDBNull(25) ? "" : Utility.FormatDate(dr.GetString(25)),
                        Bas_cemp_date = dr.IsDBNull(26) ? "" : Utility.FormatDate(dr.GetString(26)),
                        Bas_emp_date = dr.IsDBNull(27) ? "" : Utility.FormatDate(dr.GetString(27)),
                        Bas_resdate = dr.IsDBNull(28) ? "" : Utility.FormatDate(dr.GetString(28)),
                        Bas_retdate = dr.IsDBNull(29) ? "" : Utility.FormatDate(dr.GetString(29)),
                        Bas_frq = dr.IsDBNull(30) ? "" : dr.GetString(30),
                        Bas_passport = dr.IsDBNull(31) ? "" : dr.GetString(31),
                        Bas_kfta = dr.IsDBNull(32) ? "" : dr.GetString(32),
                        Bas_zip = dr.IsDBNull(33) ? "" : dr.GetString(33),
                        Bas_zipaddr = dr.IsDBNull(34) ? "" : dr.GetString(34),
                        Bas_hdpno = dr.IsDBNull(35) ? "" : dr.GetString(35),
                        Bas_telno = dr.IsDBNull(36) ? "" : dr.GetString(36),
                        Bas_email = dr.IsDBNull(37) ? "" : dr.GetString(37),
                        Bas_bsks = dr.IsDBNull(38) ? "" : dr.GetString(38),
                        Bas_job_comnm = dr.IsDBNull(39) ? "" : dr.GetString(39),
                        Bas_job_pos = dr.IsDBNull(40) ? "" : dr.GetString(40),
                        Bas_job_telno = dr.IsDBNull(41) ? "" : dr.GetString(41),
                        Bas_levdate = dr.IsDBNull(42) ? "" : Utility.FormatDate(dr.GetString(42)),
                        Bas_reidate = dr.IsDBNull(43) ? "" : Utility.FormatDate(dr.GetString(43)),
                        Bas_wsta = dr.IsDBNull(44) ? "" : dr.GetString(44),

                        Bas_sts = dr.IsDBNull(45) ? "" : dr.GetString(45),
                        Bas_res = dr.IsDBNull(46) ? "" : dr.GetString(46),
                        Bas_loa = dr.IsDBNull(47) ? "" : dr.GetString(47),

                        Bas_univ_wys = dr.IsDBNull(48) ? 0 : dr.GetInt32(48),
                        Bas_ind_wys = dr.IsDBNull(49) ? 0 : dr.GetInt32(49),

                        Bas_mil_sta = dr.IsDBNull(50) ? "" : dr.GetString(50),
                        Bas_mil_no = dr.IsDBNull(51) ? "" : dr.GetString(51),
                        Bas_mil_mil = dr.IsDBNull(52) ? "" : dr.GetString(52),
                        Bas_mil_rnk = dr.IsDBNull(53) ? "" : dr.GetString(53),
                        Bas_mil_sdate = dr.IsDBNull(54) ? "" : Utility.FormatDate(dr.GetString(54)),
                        Bas_mil_edate = dr.IsDBNull(55) ? "" : Utility.FormatDate(dr.GetString(55)),
                        Bas_rmk = dr.IsDBNull(56) ? "" : dr.GetString(56),
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
            }
            else
            {
                UserMessage.Text = "자료가 정상적으로 조회 되었습니다.";
                //**-개인정보 조회 Loging----------------------------
                if (PersonalInfo.Equals("1"))
                {
                    Utility.PersonalInfo_Logging(UserId, UserNm, MyIpAddress, ProgramName, "조회", myViewModel.Count);
                }
                Utility.SelectingFocusingGridControl(dataGrid, tableView, 0);
                Utility.SetFuncBtn(MainBtn, "2");
            }
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
            UcSubC02ViewModel data = new UcSubC02ViewModel();
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

            UcSubC02ViewModel vm = (UcSubC02ViewModel)dataGrid.SelectedItem;
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
                    UcSubC02ViewModel vm = (UcSubC02ViewModel)myViewModel.ElementAt(i);
                    if (vm.DataStatus.Equals("")) continue;
                    if (vm.DataStatus.Equals("A"))
                    {
                        cmd.CommandText = SQLStatement.InsertSQL;
                    }

                    if (vm.DataStatus.Equals("U"))
                    {
                        cmd.CommandText = SQLStatement.UpdateSQL;
                    }

                    cmd.Parameters.Add("bas_empno", OracleDbType.Varchar2).Value = vm.Bas_empno;
                    cmd.Parameters.Add("bas_resno", OracleDbType.Varchar2).Value = vm.Bas_resno;
                    cmd.Parameters.Add("bas_name", OracleDbType.Varchar2).Value = vm.Bas_name;
                    cmd.Parameters.Add("bas_cname", OracleDbType.Varchar2).Value = vm.Bas_cname;
                    cmd.Parameters.Add("bas_ename", OracleDbType.Varchar2).Value = vm.Bas_ename;
                    cmd.Parameters.Add("bas_sex", OracleDbType.Varchar2).Value = vm.Bas_sex;

                    cmd.Parameters.Add("bas_nat", OracleDbType.Varchar2).Value = vm.Bas_nat_Cd;
                    cmd.Parameters.Add("bas_ad1", OracleDbType.Varchar2).Value = vm.Bas_ad1_Cd;
                    cmd.Parameters.Add("bas_ad2", OracleDbType.Varchar2).Value = vm.Bas_ad2_Cd;
                    cmd.Parameters.Add("bas_pos", OracleDbType.Varchar2).Value = vm.Bas_pos_Cd;
                    cmd.Parameters.Add("bas_pt1", OracleDbType.Varchar2).Value = vm.Bas_pt1_Cd;

                    cmd.Parameters.Add("bas_pt2", OracleDbType.Varchar2).Value = vm.Bas_pt2_Cd;
                    cmd.Parameters.Add("bas_pt3", OracleDbType.Varchar2).Value = vm.Bas_pt3_Cd;
                    cmd.Parameters.Add("bas_dut", OracleDbType.Varchar2).Value = vm.Bas_dut_Cd;
                    cmd.Parameters.Add("bas_dept", OracleDbType.Varchar2).Value = vm.Bas_dept_Cd ;
                    cmd.Parameters.Add("bas_dept2", OracleDbType.Varchar2).Value = vm.Bas_dept2_Cd;

                    cmd.Parameters.Add("bas_cpodate", OracleDbType.Varchar2).Value = Utility.FormatDateR(vm.Bas_cpodate);
                    cmd.Parameters.Add("bas_cdudate", OracleDbType.Varchar2).Value = Utility.FormatDateR(vm.Bas_cdudate);
                    cmd.Parameters.Add("bas_cdedate", OracleDbType.Varchar2).Value = Utility.FormatDateR(vm.Bas_cdedate);
                    cmd.Parameters.Add("bas_subject", OracleDbType.Varchar2).Value = vm.Bas_subject;               
                    cmd.Parameters.Add("bas_dean_dept", OracleDbType.Varchar2).Value = vm.Bas_dean_dept_Cd;

                    cmd.Parameters.Add("bas_cont_mm", OracleDbType.Varchar2).Value = vm.Bas_cont_mm;
                    cmd.Parameters.Add("bas_emp_sdate", OracleDbType.Varchar2).Value = Utility.FormatDateR(vm.Bas_emp_sdate);
                    cmd.Parameters.Add("bas_emp_edate", OracleDbType.Varchar2).Value = Utility.FormatDateR(vm.Bas_emp_edate);
                    cmd.Parameters.Add("bas_emp_period", OracleDbType.Varchar2).Value = vm.Bas_emp_period;

                    cmd.Parameters.Add("bas_femp_date", OracleDbType.Varchar2).Value = Utility.FormatDateR(vm.Bas_femp_date);
                    cmd.Parameters.Add("bas_cemp_date", OracleDbType.Varchar2).Value = Utility.FormatDateR(vm.Bas_cemp_date);
                    cmd.Parameters.Add("bas_emp_date", OracleDbType.Varchar2).Value = Utility.FormatDateR(vm.Bas_emp_date);
                    cmd.Parameters.Add("bas_resdate", OracleDbType.Varchar2).Value = Utility.FormatDateR(vm.Bas_resdate);

                    cmd.Parameters.Add("bas_retdate", OracleDbType.Varchar2).Value = Utility.FormatDateR(vm.Bas_retdate);
                    cmd.Parameters.Add("bas_frq", OracleDbType.Varchar2).Value = vm.Bas_frq;
                    cmd.Parameters.Add("bas_passport", OracleDbType.Varchar2).Value = vm.Bas_passport;
                    cmd.Parameters.Add("bas_kfta", OracleDbType.Varchar2).Value = vm.Bas_kfta;
                    cmd.Parameters.Add("bas_zip", OracleDbType.Varchar2).Value = vm.Bas_zip;

                    cmd.Parameters.Add("bas_zipaddr", OracleDbType.Varchar2).Value = vm.Bas_zipaddr;
                    cmd.Parameters.Add("bas_hdpno", OracleDbType.Varchar2).Value = vm.Bas_hdpno;
                    cmd.Parameters.Add("bas_telno", OracleDbType.Varchar2).Value = vm.Bas_telno;
                    cmd.Parameters.Add("bas_email", OracleDbType.Varchar2).Value = vm.Bas_email;

                    cmd.Parameters.Add("bas_bsks", OracleDbType.Varchar2).Value = vm.Bas_bsks;
                    cmd.Parameters.Add("bas_job_comnm", OracleDbType.Varchar2).Value = vm.Bas_job_comnm;
                    cmd.Parameters.Add("bas_job_pos", OracleDbType.Varchar2).Value = vm.Bas_job_pos;
                    cmd.Parameters.Add("bas_job_telno", OracleDbType.Varchar2).Value = vm.Bas_job_telno;
                    cmd.Parameters.Add("bas_levdate", OracleDbType.Varchar2).Value = Utility.FormatDateR(vm.Bas_levdate);

                    cmd.Parameters.Add("bas_reidate", OracleDbType.Varchar2).Value = Utility.FormatDateR(vm.Bas_reidate);
                    cmd.Parameters.Add("bas_wsta", OracleDbType.Varchar2).Value = vm.Bas_wsta;
                    cmd.Parameters.Add("bas_sts", OracleDbType.Varchar2).Value = vm.Bas_sts_Cd;
                    cmd.Parameters.Add("bas_res", OracleDbType.Varchar2).Value = vm.Bas_res;
                    cmd.Parameters.Add("bas_loa", OracleDbType.Varchar2).Value = vm.Bas_loa;

                    cmd.Parameters.Add("bas_univ_wys", OracleDbType.Varchar2).Value = vm.Bas_univ_wys;
                    cmd.Parameters.Add("bas_ind_wys", OracleDbType.Varchar2).Value = vm.Bas_ind_wys;
                    cmd.Parameters.Add("bas_mil_sta", OracleDbType.Varchar2).Value = vm.Bas_mil_sta;
                    cmd.Parameters.Add("bas_mil_no", OracleDbType.Varchar2).Value = vm.Bas_mil_no;
                    cmd.Parameters.Add("bas_mil_mil", OracleDbType.Varchar2).Value = vm.Bas_mil_mil;
                    
                    cmd.Parameters.Add("bas_mil_rnk", OracleDbType.Varchar2).Value = vm.Bas_mil_rnk;
                    cmd.Parameters.Add("bas_mil_sdate", OracleDbType.Varchar2).Value = Utility.FormatDateR(vm.Bas_mil_sdate);
                    cmd.Parameters.Add("bas_mil_edate", OracleDbType.Varchar2).Value = Utility.FormatDateR(vm.Bas_mil_edate);
                    cmd.Parameters.Add("bas_rmk", OracleDbType.Varchar2).Value = vm.Bas_rmk;
                    cmd.Parameters.Add("datasys3", OracleDbType.Varchar2).Value = string.Concat(UserId, ":", UserNm);


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
                UcSubC02ViewModel vm = (UcSubC02ViewModel)myViewModel.ElementAt(i);
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
                UcSubC02ViewModel vm = (UcSubC02ViewModel)myViewModel.ElementAt(i);
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
                ((UcSubC02ViewModel)dataGrid.SelectedItem).Bas_dept = result;

            }
        }*/
        private void Seach_user_id_MouseDown(object sender, MouseButtonEventArgs e)
        {

                if (Utility.ShowSearchCDWindow(SQLStatement.SelectSQL10, "부서코드", out string result) == true)
                {
                    //if (dataGrid.SelectedItems.Count < 1) return;
                    //((UcSubC02ViewModel)dataGrid.SelectedItem).Bas_dept = result;
                    searchText_Copy2.Text = result;
                    searchText_Copy2.Focus();
            }

        }
        

        #endregion

    }
}
