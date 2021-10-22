using SE214L22.Core.Interfaces.Services;
using SE214L22.Core.Services;
using SE214L22.Data.Repository;
using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace SE214L22.Core.ViewModels.Users
{
    public class UserEmailValidation : ValidationRule
    {
        private readonly IUserService _userService;
        private readonly string EMAIL_PARTTERN = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";

        public UserEmailValidation()
        {
            // TODO: 
            _userService = new UserService(new UserRepository(), new RoleRepository());
        }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                string email = (string)value;
                // Check empty string?
                if (value == null || email.Trim().Length == 0)
                {
                    return new ValidationResult(false, "Vui lòng nhập email");
                }
                // No. character must be equal or greater than 10.
                if (email.Length < 10)
                {
                    return new ValidationResult(false, "Email phải có ít nhất 10 kí tự");
                }
                // Regular expression check email pattern
                if (!Regex.IsMatch(email, EMAIL_PARTTERN))
                {
                    return new ValidationResult(false, "Email chỉ được gồm các kí tự a-z, 0-9, _, -, @, .");
                }

                // Check if this email has been taken by other user.
                if (_userService.EmailHasBeenTaken(email))
                    return new ValidationResult(false, "Email này đã được sử dụng rồi");

            }
            catch (Exception)
            {
                return new ValidationResult(false, "Email không hợp lệ");
            }
            return ValidationResult.ValidResult;
        }
    }
}
