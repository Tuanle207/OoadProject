using SE214L22.Contract.Entities;
using System;
using System.Globalization;
using System.Windows.Data;

namespace SE214L22.Core.ViewModels.Orders
{
    public class OrderStatusConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object paramater, CultureInfo culture)
        {
            try
            {
                if (value == null)
                    return "Không xác định";
                var status = (OrderStatus)value;
                switch (status)
                {
                    case OrderStatus.WaitForSent:
                        return "Đang chờ gửi";
                    case OrderStatus.Sent:
                        return "Đã gửi";
                    case OrderStatus.Done:
                        return "Đã hoàn thành";
                    default:
                        return "Không xác định";
                }
            }
            catch (Exception)
            {
                return "Không xác định";
            }
        }


        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException("OrderStatusConverter can only be used for one way conversion.");
        }
    }
}
