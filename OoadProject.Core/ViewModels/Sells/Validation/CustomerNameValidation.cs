using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace OoadProject.Core.ViewModels.Sells.Validation
{
    public class CustomerNameValidation : ValidationRule
    {
        public CustomerNameValidation()
        {
            
        }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value == null || ((string)value).Trim().Length == 0)
                return new ValidationResult(false, "Vui lòng nhập tên khách hàng");
            return ValidationResult.ValidResult;
        }
    }
}
