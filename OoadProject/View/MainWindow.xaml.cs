using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OoadProject.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool _mouseDown;
        private double x;
        private double y;

        private HomeScreen _homeScreen;
        private SellUserControl _sellScreen;
        private ItemManagerScreen _itemManagementScreen;
        private ManagementOrderUserControl _orderManagementScreen;
        private ListWarrantyOrderUserControl _warrantyOrderScreen;
        private StaffUserControl _userScreen;
        //private ReportUserControl _reportScreen;
        private SettingUserControl _settingScreen;

        public MainWindow()
        {
            InitializeComponent();

            _mouseDown = false;

            _homeScreen = new HomeScreen();
            _sellScreen = new SellUserControl();
            _itemManagementScreen = new ItemManagerScreen();
            _orderManagementScreen = new ManagementOrderUserControl();
            _warrantyOrderScreen = new ListWarrantyOrderUserControl();
            _userScreen = new StaffUserControl();
            //_reportScreen = new ReportUserControl();
            _settingScreen = new SettingUserControl();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            mainControl.Content = _homeScreen;
        }

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (((ListViewItem)((ListView)sender).SelectedItem).Name)
            {
                case "ItemHome":
                    lbTitle.Content = "TRANG CHỦ";
                    mainControl.Content = _homeScreen;
                    break;
                case "ItemSell":
                    this.lbTitle.Content = "BÁN HÀNG";
                    mainControl.Content = _sellScreen;
                    break;
                case "ItemProduct":
                    this.lbTitle.Content = "QUẢN LÝ SẢN PHẨM";
                    mainControl.Content = _itemManagementScreen;
                    break;
                case "ItemImportProduct":
                    this.lbTitle.Content = "QUẢN LÝ ĐƠN ĐẶT HÀNG";
                    mainControl.Content = _orderManagementScreen;
                    break;
                case "ItemWarranty":
                    this.lbTitle.Content = "BẢO HÀNH SẢN PHẨM";
                    mainControl.Content = _warrantyOrderScreen;
                    break;
                case "ItemStaff":
                    this.lbTitle.Content = "QUẢN LÝ NHÂN VIÊN";
                    mainControl.Content = _userScreen;
                    break;
                //case "ItemReport":
                //    this.lbTitle.Content = "BÁO CÁO THỐNG KÊ";
                //    mainControl.Content = _reportScreen;
                //    break;
                case "ItemSetting":
                    this.lbTitle.Content = "THAY ĐỔI CÁC THAM SỐ";
                    mainControl.Content = _settingScreen;
                    break;
            }
        }

        private void lbTitle_MouseMove(object sender, MouseEventArgs e)
        {
            if (_mouseDown == true)
            {
                var position = e.GetPosition(this);
                this.Left += position.X - x;
                this.Top += position.Y - y;
            }
        }

        private void lbTitle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            _mouseDown = true;
            var position = e.GetPosition(this);
            this.x = position.X;
            this.y = position.Y;
        }

        private void lbTitle_MouseUp(object sender, MouseEventArgs e)
        {
            _mouseDown = false;
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            (new LoginWindow()).Show();
            this.Close();
        }

        private void btnUpdatePassword_Click(object sender, RoutedEventArgs e)
        {
            new UpdatePasswordWindow().ShowDialog();
        }
    }
}
