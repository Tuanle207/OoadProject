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
    /// Interaction logic for ManagementOrderUserControl.xaml
    /// </summary>
    public partial class ManagementOrderUserControl : UserControl
    {
        public ManagementOrderUserControl()
        {
            InitializeComponent();
        }

        private void btnDatHang_GotFocus(object sender, RoutedEventArgs e)
        {
            btnDatHang.Background = (Brush)(new BrushConverter()).ConvertFrom("#808080");
            btnNhapHang.Background = (Brush)(new BrushConverter()).ConvertFrom("#C0C0C0");
            btnDSNhapHang.Background = (Brush)(new BrushConverter()).ConvertFrom("#C0C0C0");
        }

        private void btnNhapHang_GotFocus(object sender, RoutedEventArgs e)
        {
            btnDatHang.Background = (Brush)(new BrushConverter()).ConvertFrom("#C0C0C0");
            btnNhapHang.Background = (Brush)(new BrushConverter()).ConvertFrom("#808080");
            btnDSNhapHang.Background = (Brush)(new BrushConverter()).ConvertFrom("#C0C0C0");
        }

        private void btnDSNhapHang_GotFocus(object sender, RoutedEventArgs e)
        {
            btnDatHang.Background = (Brush)(new BrushConverter()).ConvertFrom("#C0C0C0");
            btnNhapHang.Background = (Brush)(new BrushConverter()).ConvertFrom("#C0C0C0");
            btnDSNhapHang.Background = (Brush)(new BrushConverter()).ConvertFrom("#808080");
        }

        private void btnDatHang_Click(object sender, RoutedEventArgs e)
        {
            if (viewControl.Name != "ListOrderUserControl")
            {
                viewControl.Content = new ListOrderUserControl();
                viewControl.Name = "ListOrderUserControl";
            }
        }

        private void uscListOrder_Loaded(object sender, RoutedEventArgs e)
        {
            viewControl.Name = "ListOrderUserControl";
            viewControl.Content = new ListOrderUserControl();            
        }

        private void btnNhapHang_Click(object sender, RoutedEventArgs e)
        {
            if (viewControl.Name != "ImportItemsUserControl")
            {
                viewControl.Content = new ImportItemsUserControl();
                viewControl.Name = "ImportItemsUserControl";
            }
        }

        private void btnDSNhapHang_Click(object sender, RoutedEventArgs e)
        {
            if (viewControl.Name != "ListImportedItemUserControl")
            {
                viewControl.Content = new ListImportedItemUserControl();
                viewControl.Name = "ListImportedItemUserControl";
            }
        }
    }
}
