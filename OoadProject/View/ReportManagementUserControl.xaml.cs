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
    /// Interaction logic for ManagementReportUserControl.xaml
    /// </summary>
    public partial class ReportManagementUserControl : UserControl
    {
        public ReportManagementUserControl()
        {
            InitializeComponent();
            viewControl.Content = new ReportByDateUserControl();
        }

        private void btnReportByDay_Click(object sender, RoutedEventArgs e)
        {
            viewControl.Content = new ReportByDateUserControl();
        }

        private void btnReportByMonth_Click(object sender, RoutedEventArgs e)
        {
            viewControl.Content = new ReportByMonthUserControl();
        }
    }
}