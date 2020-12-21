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
using System.Windows.Shapes;

namespace OoadProject.View
{
    /// <summary>
    /// Interaction logic for EditProductWindow.xaml
    /// </summary>
    public partial class EditProductWindow : Window
    {
        private bool isLoaded;
        public EditProductWindow()
        {
            isLoaded = true;
            InitializeComponent();
        }

        private void ReTurnRate_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (isLoaded)
            {
                isLoaded = false;
                return;
            }
            tbCheckReturnRateChange.Text = "changed";
        }
    }
}
