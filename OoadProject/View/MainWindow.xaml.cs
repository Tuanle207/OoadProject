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
        public MainWindow()
        {
            InitializeComponent();
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
            mainControl.Content = new HomeScreen();
        }

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (((ListViewItem)((ListView)sender).SelectedItem).Name)
            {
                case "ItemHome":
                    lbTitle.Content = "TRANG CHỦ";
                    mainControl.Content = new HomeScreen();
                    break;
                case "ItemSell":
                    this.lbTitle.Content = "BÁN HÀNG";
                    mainControl.Content = new SellUserControl();
                    break;
                case "ItemProduct":
                    this.lbTitle.Content = "QUẢN LÝ SẢN PHẨM";
                    mainControl.Content = new ItemManagerScreen();
                    break;
                case "ItemImportProduct":
                    this.lbTitle.Content = "QUẢN LÝ ĐƠN ĐẶT HÀNG";
                    mainControl.Content = new ManagementOrderUserControl();
                    break;
                case "ItemWarranty":
                    this.lbTitle.Content = "BẢO HÀNH SẢN PHẨM";
                    mainControl.Content = new WarrantyOrderUserControl();
                    break;
                case "ItemStaff":
                    this.lbTitle.Content = "QUẢN LÝ NHÂN VIÊN";
                    mainControl.Content = new NhanVienUserControl();
                    break;
                case "ItemReport":
                    this.lbTitle.Content = "BÁO CÁO THỐNG KÊ";
                    mainControl.Content = new ReportUserControl();
                    break;
                case "ItemSetting":
                    this.lbTitle.Content = "THAY ĐỔI CÁC THAM SỐ";
                    mainControl.Content = new SettingUserControl();
                    break;
            }
        }
    }
}
