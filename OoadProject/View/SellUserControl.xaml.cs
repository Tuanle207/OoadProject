﻿using System;
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
    /// Interaction logic for SellUserControl.xaml
    /// </summary>
    public partial class SellUserControl : UserControl
    {
        public SellUserControl()
        {
            InitializeComponent();
        }

        private void ScrollViewer_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            ScrollViewer scv = (ScrollViewer)sender;
            scv.ScrollToVerticalOffset(scv.VerticalOffset - e.Delta);
            e.Handled = true;
        }

        private void btnThanhToan_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Xác nhận lưu?", "Xác nhận", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            var command = ((Button)sender).Command;

            if (result == MessageBoxResult.OK && command.CanExecute(null))
            {
                command.Execute(true);
            }
            else if (result != MessageBoxResult.OK && command.CanExecute(null))
            {
                command.Execute(false);
            }
        }

        private void btnHuyBo_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Bạn có chắc muốn nhập lại không?", "Xác nhận", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            var command = ((Button)sender).Command;

            if (result == MessageBoxResult.OK && command.CanExecute(null))
            {
                command.Execute(true);
            }
            else if (result != MessageBoxResult.OK && command.CanExecute(null))
            {
                command.Execute(false);
            }
        }
    }
}
