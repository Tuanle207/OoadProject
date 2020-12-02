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
    /// Interaction logic for HomeScreen.xaml
    /// </summary>
    public partial class HomeScreen : UserControl
    {
        public HomeScreen()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            List<Item> list = new List<Item>();
            string[] a = { "1", "11/11/2020", "Lê Anh Tuấn", "Đã gửi" };
            string[] b = { "2", "19/11/2020", "Nguyễn Xuân Tú", "Đang chờ xử lý" };
            string[] c = { "3", "20/12/2020", "Nguyễn Thanh Tuấn", "Đã xử lý" };
            list.Add(new Item() { stt = 1, date = new DateTime(2020, 11, 11), name = "Lê Anh Tuấn", status = "Đã gửi" }); 
            lvDonDatHang.ItemsSource = list;
        }
    }

    class Item
    {
        public int stt { get; set; }
        public DateTime date { get; set; }
        public string name { get; set; }
        public string status { get; set; }
    }
}
