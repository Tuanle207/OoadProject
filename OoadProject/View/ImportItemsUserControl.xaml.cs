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
    /// Interaction logic for ImportItemsUserControl.xaml
    /// </summary>
    public partial class ImportItemsUserControl : UserControl
    {
        public ImportItemsUserControl()
        {
            InitializeComponent();
        }

        private void ScrollViewer_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            ScrollViewer scv = (ScrollViewer)sender;
            scv.ScrollToVerticalOffset(scv.VerticalOffset - e.Delta);
            e.Handled = true;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            EditOrderWindow w = new EditOrderWindow();
            w.ShowDialog();
        }

        private void btnAddReceipt_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Xác nhận nhập hàng mới?", "Xác nhận", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            var command = ((Button)sender).Command;

            if (result == MessageBoxResult.OK && command.CanExecute(null))
            {
                command.Execute(true);
                MessageBox.Show("Nhập hàng thành công!");
            }
        }
    }
}
