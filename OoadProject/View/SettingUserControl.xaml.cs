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
    /// Interaction logic for SettingUserControl.xaml
    /// </summary>
    public partial class SettingUserControl : UserControl
    {
        public SettingUserControl()
        {
            InitializeComponent();
        }

        private void uscSetting_Loaded(object sender, RoutedEventArgs e)
        {
            viewControl.Name = "ParameterUserControl";
            viewControl.Content = new ParameterUserControl();
        }

        private void btnThamSo_Click(object sender, RoutedEventArgs e)
        {
            if (viewControl.Name != "ParameterUserControl")
            {
                viewControl.Content = new ParameterUserControl();
                viewControl.Name = "ParameterUserControl";
            }
        }

        private void btnThamSo_GotFocus(object sender, RoutedEventArgs e)
        {
            btnThamSo.Background = (Brush)(new BrushConverter()).ConvertFrom("#808080");
            btnLoaiMatHang.Background = (Brush)(new BrushConverter()).ConvertFrom("#C0C0C0");
            btnHangSanXuat.Background = (Brush)(new BrushConverter()).ConvertFrom("#C0C0C0");
            btnNhaCungCap.Background = (Brush)(new BrushConverter()).ConvertFrom("#C0C0C0");
        }

        private void btnLoaiMatHang_Click(object sender, RoutedEventArgs e)
        {
            if (viewControl.Name != "CategoryProductUserControl")
            {
                viewControl.Content = new CategoryProductUserControl();
                viewControl.Name = "CategoryProductUserControl";
            }
        }

        private void btnLoaiMatHang_GotFocus(object sender, RoutedEventArgs e)
        {
            btnThamSo.Background = (Brush)(new BrushConverter()).ConvertFrom("#C0C0C0");
            btnLoaiMatHang.Background = (Brush)(new BrushConverter()).ConvertFrom("#808080");
            btnHangSanXuat.Background = (Brush)(new BrushConverter()).ConvertFrom("#C0C0C0");
            btnNhaCungCap.Background = (Brush)(new BrushConverter()).ConvertFrom("#C0C0C0");
        }

        private void btnHangSanXuat_Click(object sender, RoutedEventArgs e)
        {
            if (viewControl.Name != "ManufactureUserControl")
            {
                viewControl.Content = new ManufactureUserControl();
                viewControl.Name = "ManufactureUserControl";
            }
        }

        private void btnHangSanXuat_GotFocus(object sender, RoutedEventArgs e)
        {
            btnThamSo.Background = (Brush)(new BrushConverter()).ConvertFrom("#C0C0C0");
            btnLoaiMatHang.Background = (Brush)(new BrushConverter()).ConvertFrom("#C0C0C0");
            btnHangSanXuat.Background = (Brush)(new BrushConverter()).ConvertFrom("#808080");
            btnNhaCungCap.Background = (Brush)(new BrushConverter()).ConvertFrom("#C0C0C0");
        }

        private void btnNhaCungCap_Click(object sender, RoutedEventArgs e)
        {
            if (viewControl.Name != "ProviderUserControl")
            {
                viewControl.Content = new ProviderUserControl();
                viewControl.Name = "ProviderUserControl";
            }
        }

        private void btnNhaCungCap_GotFocus(object sender, RoutedEventArgs e)
        {
            btnThamSo.Background = (Brush)(new BrushConverter()).ConvertFrom("#C0C0C0");
            btnLoaiMatHang.Background = (Brush)(new BrushConverter()).ConvertFrom("#C0C0C0");
            btnHangSanXuat.Background = (Brush)(new BrushConverter()).ConvertFrom("#C0C0C0");
            btnNhaCungCap.Background = (Brush)(new BrushConverter()).ConvertFrom("#808080");
        }
    }
}
