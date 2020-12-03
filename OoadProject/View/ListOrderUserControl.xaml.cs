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
    /// Interaction logic for ListOrderUserControl.xaml
    /// </summary>
    public partial class ListOrderUserControl : UserControl
    {
        public ListOrderUserControl()
        {
            InitializeComponent();
        }

        private void ScrollViewer_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            ScrollViewer scv = (ScrollViewer)sender;
            scv.ScrollToVerticalOffset(scv.VerticalOffset - e.Delta);
            e.Handled = true;
        }

        private void btnAddOrder_Click(object sender, RoutedEventArgs e)
        {
            AddOrderScreen w = new AddOrderScreen();
            w.ShowDialog();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            EditOrderScreen w = new EditOrderScreen();
            w.ShowDialog();
        }
    }
}
