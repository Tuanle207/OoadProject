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
    /// Interaction logic for ItemManagerScreen.xaml
    /// </summary>
    public partial class ProductUserControl : UserControl
    {
        public ProductUserControl()
        {
            InitializeComponent();
        }

        private void ScrollViewer_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            ScrollViewer scv = (ScrollViewer)sender;
            scv.ScrollToVerticalOffset(scv.VerticalOffset - e.Delta);
            e.Handled = true;
        }
    }

    class MockItem
    {
        public int id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string model { get; set; }
        public int count { get; set; }
        public int costImport { get; set; }
        public int cost { get; set; }
        public double ratio { get; set; }
        public int timeExpire { get; set; }
        public string status { get; set; }
    }
}
