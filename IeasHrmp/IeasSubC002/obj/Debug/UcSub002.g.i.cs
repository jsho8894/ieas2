#pragma checksum "..\..\UcSub002.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "65EAF5CFFBBCDAFE0D856709E65B67318DBAA75F5F34A389C43265EC65B58C57"
//------------------------------------------------------------------------------
// <auto-generated>
//     이 코드는 도구를 사용하여 생성되었습니다.
//     런타임 버전:4.0.30319.42000
//
//     파일 내용을 변경하면 잘못된 동작이 발생할 수 있으며, 코드를 다시 생성하면
//     이러한 변경 내용이 손실됩니다.
// </auto-generated>
//------------------------------------------------------------------------------

using DevExpress.Core;
using DevExpress.Xpf.Core;
using DevExpress.Xpf.Core.ConditionalFormatting;
using DevExpress.Xpf.Core.DataSources;
using DevExpress.Xpf.Core.Serialization;
using DevExpress.Xpf.Core.ServerMode;
using DevExpress.Xpf.DXBinding;
using DevExpress.Xpf.Editors;
using DevExpress.Xpf.Editors.DataPager;
using DevExpress.Xpf.Editors.DateNavigator;
using DevExpress.Xpf.Editors.ExpressionEditor;
using DevExpress.Xpf.Editors.Filtering;
using DevExpress.Xpf.Editors.Flyout;
using DevExpress.Xpf.Editors.Popups;
using DevExpress.Xpf.Editors.Popups.Calendar;
using DevExpress.Xpf.Editors.RangeControl;
using DevExpress.Xpf.Editors.Settings;
using DevExpress.Xpf.Editors.Settings.Extension;
using DevExpress.Xpf.Editors.Validation;
using DevExpress.Xpf.Grid;
using DevExpress.Xpf.Grid.ConditionalFormatting;
using DevExpress.Xpf.Grid.LookUp;
using DevExpress.Xpf.Grid.TreeList;
using DevExpress.Xpf.LayoutControl;
using IeasLibrary;
using IeasSubC002;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interactivity;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace IeasSubC02
{


    /// <summary>
    /// UserControl1
    /// </summary>
    public partial class UserControl1 : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector
    {


#line 26 "..\..\UcSub002.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock textBlock;

#line default
#line hidden


#line 27 "..\..\UcSub002.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox searchText;

#line default
#line hidden


#line 32 "..\..\UcSub002.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.Grid.TableView tableView;

#line default
#line hidden

        private bool _contentLoaded;

        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent()
        {
            if (_contentLoaded)
            {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/IeasSubC002;component/ucsub002.xaml", System.UriKind.Relative);

#line 1 "..\..\UcSub002.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);

#line default
#line hidden
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target)
        {
            switch (connectionId)
            {
                case 1:

#line 15 "..\..\UcSub002.xaml"
                    ((IeasSubC002.UserControl1)(target)).Loaded += new System.Windows.RoutedEventHandler(this.UserControl_Loaded);

#line default
#line hidden
                    return;
                case 2:
                    this.textBlock = ((System.Windows.Controls.TextBlock)(target));
                    return;
                case 3:
                    this.searchText = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 4:
                    this.tableView = ((DevExpress.Xpf.Grid.TableView)(target));
                    return;
                case 5:
                    this.stuno = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 6:
                    this.resno1 = ((System.Windows.Controls.TextBox)(target));

#line 47 "..\..\UcSub002.xaml"
                    this.resno1.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.Price_TextChanged);

#line default
#line hidden
                    return;
                case 7:
                    this.resno2 = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 8:
                    this.name = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 9:
                    this.ename = ((System.Windows.Controls.TextBox)(target));

#line 52 "..\..\UcSub002.xaml"
                    this.ename.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.Price_TextChanged);

#line default
#line hidden
                    return;
                case 10:
                    this.cname = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 11:
                    this.sex = ((System.Windows.Controls.CheckBox)(target));
                    return;
                case 12:
                    this.ad1 = ((System.Windows.Controls.ComboBox)(target));
                    return;
                case 13:
                    this.ad2 = ((System.Windows.Controls.ComboBox)(target));
                    return;
                case 14:
                    this.nat = ((System.Windows.Controls.TextBox)(target));

#line 62 "..\..\UcSub002.xaml"
                    this.nat.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.Price_TextChanged);

#line default
#line hidden
                    return;
                case 15:
                    this.pt1 = ((System.Windows.Controls.ComboBox)(target));
                    return;
                case 16:
                    this.pt21 = ((System.Windows.Controls.ComboBox)(target));
                    return;
                case 17:
                    this.apt3 = ((System.Windows.Controls.ComboBox)(target));
                    return;
                case 18:
                    this.emp_date = ((System.Windows.Controls.DatePicker)(target));
                    return;
                case 19:
                    this.resdate = ((System.Windows.Controls.DatePicker)(target));
                    return;
                case 20:
                    this.kfta = ((System.Windows.Controls.CheckBox)(target));
                    return;
                case 21:
                    this.retdate = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 22:
                    this.passport = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 23:
                    this.bsks = ((System.Windows.Controls.CheckBox)(target));
                    return;
                case 24:
                    this.zip = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 25:
                    this.zipaddr = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 26:
                    this.addr = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 27:
                    this.hpdno = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 28:
                    this.telno = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 29:
                    this.email1 = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 30:
                    this.email2 = ((System.Windows.Controls.ComboBox)(target));
                    return;
                case 31:
                    this.univ_wys = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 32:
                    this.ind_wys = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 33:
                    this.milsta = ((System.Windows.Controls.ComboBox)(target));
                    return;
                case 34:
                    this.milno = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 35:
                    this.milmil = ((System.Windows.Controls.ComboBox)(target));
                    return;
                case 36:
                    this.milrnk = ((System.Windows.Controls.ComboBox)(target));
                    return;
                case 37:
                    this.milsdate = ((System.Windows.Controls.DatePicker)(target));
                    return;
                case 38:
                    this.miledate = ((System.Windows.Controls.DatePicker)(target));
                    return;
                case 39:
                    this.rmk = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 40:
                    this.pos = ((System.Windows.Controls.ComboBox)(target));
                    return;
                case 41:
                    this.cpodate = ((System.Windows.Controls.DatePicker)(target));
                    return;
                case 42:
                    this.dut = ((System.Windows.Controls.ComboBox)(target));
                    return;
                case 43:
                    this.cdudate = ((System.Windows.Controls.DatePicker)(target));
                    return;
                case 44:
                    this.dept = ((System.Windows.Controls.ComboBox)(target));
                    return;
                case 45:
                    this.cdedate = ((System.Windows.Controls.DatePicker)(target));
                    return;
                case 46:
                    this.cont_mm = ((System.Windows.Controls.TextBox)(target));

#line 130 "..\..\UcSub002.xaml"
                    this.cont_mm.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.Price_TextChanged);

#line default
#line hidden
                    return;
                case 47:
                    this.deandept = ((System.Windows.Controls.ComboBox)(target));
                    return;
                case 48:
                    this.subject = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 49:
                    this.emp_sdate = ((System.Windows.Controls.DatePicker)(target));
                    return;
                case 50:
                    this.emp_edate = ((System.Windows.Controls.DatePicker)(target));
                    return;
                case 51:
                    this.remp_mm = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 52:
                    this.cont = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 53:
                    this.nemp_mm = ((System.Windows.Controls.DatePicker)(target));
                    return;
                case 54:
                    this.femp_date = ((System.Windows.Controls.DatePicker)(target));
                    return;
                case 55:
                    this.cemp_date = ((System.Windows.Controls.DatePicker)(target));
                    return;
                case 56:
                    this.letdate = ((System.Windows.Controls.DatePicker)(target));
                    return;
                case 57:
                    this.job_comnm = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 58:
                    this.job_pos = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 59:
                    this.job_telno = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 60:
                    this.levdate = ((System.Windows.Controls.DatePicker)(target));
                    return;
                case 61:
                    this.reidate = ((System.Windows.Controls.DatePicker)(target));
                    return;
                case 62:
                    this.wsta = ((System.Windows.Controls.ComboBox)(target));
                    return;
                case 63:
                    this.sts = ((System.Windows.Controls.ComboBox)(target));
                    return;
                case 64:
                    this.res = ((System.Windows.Controls.ComboBox)(target));
                    return;
                case 65:
                    this.loa = ((System.Windows.Controls.ComboBox)(target));
                    return;
            }
            this._contentLoaded = true;
        }

        internal System.Windows.Controls.TextBlock textBlock_Copy;
        internal System.Windows.Controls.TextBox searchText_Copy;
        internal System.Windows.Controls.TextBlock textBlock_Copy1;
        internal System.Windows.Controls.TextBlock textBlock_Copy2;
        internal System.Windows.Controls.TextBox searchText_Copy2;
        internal System.Windows.Controls.TextBox stuno;
        internal System.Windows.Controls.TextBox resno1;
        internal System.Windows.Controls.TextBox name;
        internal System.Windows.Controls.TextBox ename;
        internal System.Windows.Controls.TextBox cname;
        internal System.Windows.Controls.ComboBox sex;
        internal System.Windows.Controls.ComboBox ad1;
        internal System.Windows.Controls.ComboBox ad2;
        internal System.Windows.Controls.TextBox nat;
        internal System.Windows.Controls.ComboBox pt1;
        internal System.Windows.Controls.ComboBox pt21;
        internal System.Windows.Controls.ComboBox pt3;
        internal System.Windows.Controls.DatePicker empdate;
        internal System.Windows.Controls.DatePicker resdate;
        internal System.Windows.Controls.TextBox retdate;
        internal System.Windows.Controls.TextBox passport;
        internal System.Windows.Controls.TextBox zip;
        internal System.Windows.Controls.TextBox zipaddr;
        internal System.Windows.Controls.TextBox addr;
        internal System.Windows.Controls.TextBox telno;
        internal System.Windows.Controls.TextBox hpdno;
        internal System.Windows.Controls.TextBox email1;
        internal System.Windows.Controls.TextBox univ_wys;
        internal System.Windows.Controls.TextBox ind_wys;
        internal System.Windows.Controls.ComboBox milsta;
        internal System.Windows.Controls.TextBox milno;
        internal System.Windows.Controls.ComboBox milmil;
        internal System.Windows.Controls.ComboBox milrnk;
        internal System.Windows.Controls.DatePicker milsdate;
        internal System.Windows.Controls.DatePicker miledate;
        internal System.Windows.Controls.TextBox rmk;
        internal System.Windows.Controls.ComboBox pos;
        internal System.Windows.Controls.DatePicker cpodate;
        internal System.Windows.Controls.ComboBox dut;
        internal System.Windows.Controls.DatePicker cdudate;
        internal System.Windows.Controls.TextBox dept;
        internal System.Windows.Controls.DatePicker cdedate;
        internal System.Windows.Controls.TextBox cont_mm;
        internal System.Windows.Controls.ComboBox deandept;
        internal System.Windows.Controls.TextBox subject;
        internal System.Windows.Controls.DatePicker emp_sdate;
        internal System.Windows.Controls.DatePicker emp_edate;
        internal System.Windows.Controls.TextBox period;
        internal System.Windows.Controls.TextBox remp_mm;
        internal System.Windows.Controls.DatePicker nemp_mm;
        internal System.Windows.Controls.DatePicker femp_date;
        internal System.Windows.Controls.DatePicker cemp_date;
        internal System.Windows.Controls.DatePicker letdate;
        internal System.Windows.Controls.TextBox job_comnm;
        internal System.Windows.Controls.TextBox job_pos;
        internal System.Windows.Controls.TextBox job_telno;
        internal System.Windows.Controls.DatePicker levdate;
        internal System.Windows.Controls.DatePicker reidate;
        internal System.Windows.Controls.ComboBox wsta;
        internal System.Windows.Controls.ComboBox sts;
        internal System.Windows.Controls.ComboBox res;
        internal System.Windows.Controls.ComboBox loa;
        internal System.Windows.Controls.TextBox hpdno1;
        internal System.Windows.Controls.TextBox hpdno2;
        internal System.Windows.Controls.ComboBox kfta;
        internal System.Windows.Controls.ComboBox bsks;
        internal System.Windows.Controls.ComboBox searchText_Copy1;
    }
}

