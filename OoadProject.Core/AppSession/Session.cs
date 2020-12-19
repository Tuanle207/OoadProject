using OoadProject.Data.Entity.AppUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace OoadProject.Core.AppSession
{
    public static class Session
    {
        private static User _currentUser;

        public static User CurrentUser
        {
            get
            {
                if (_currentUser != null)
                    return _currentUser;

                throw new Exception("Người dùng phải đăng nhập trước tiên!");
            }
        }

        public static bool IsLoggedIn()
        {
            return _currentUser != null ? true : false;
        }

        public static void SetSessionUser(User user)
        {
            _currentUser = user;
        }

        public static string HashPassword(string password)
        {
            UnicodeEncoding uEncode = new UnicodeEncoding();
            byte[] bytPassword = uEncode.GetBytes(password);
            SHA512Managed sha = new SHA512Managed();
            byte[] hash = sha.ComputeHash(bytPassword);
            return Convert.ToBase64String(hash);
        }

        public static string GetNewPassword()
        {
            return new Random().Next(1000, 9999).ToString();
        }

        public static bool ComparePassword(string candidatePassword, string userPassword)
        {
            var hashedCandidatePassword = HashPassword(candidatePassword);
            if (hashedCandidatePassword == userPassword)
                return true;
            return false;
        }
    }
}
