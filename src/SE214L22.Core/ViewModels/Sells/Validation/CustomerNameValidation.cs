using System.Globalization;
using System.Windows.Controls;

namespace SE214L22.Core.ViewModels.Sells
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
