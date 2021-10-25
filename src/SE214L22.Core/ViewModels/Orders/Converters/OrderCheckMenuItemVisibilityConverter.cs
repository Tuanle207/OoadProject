﻿using SE214L22.Contract.DTOs;
using System;
using System.Globalization;
using System.Windows.Data;

namespace SE214L22.Core.ViewModels.Orders
{
    public class OrderCheckMenuItemVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object paramater, CultureInfo culture)
        {
            try
            {
                if (value == null)
                    return "Hidden";
                var order = (OrderForListDto)value;
                var status = (int)paramater;
                if (order.Status == status)
                    return "Visible";
                else
                    return "Hidden";
            }
            catch (Exception)
            {
                return "Hidden";
            }
        }


        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException("CheckMenuItemVisibilityConverter can only be used for one way conversion.");
        }
    }
}