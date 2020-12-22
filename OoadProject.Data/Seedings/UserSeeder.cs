using OoadProject.Data.Entity.AppUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace OoadProject.Data.Seedings
{
    public class UserSeeder 
    {
        public static void Seed(AppDbContext context)
        {
            var quanTriVienRole = context.Roles.Add(new Role
            {
                Name = "Quản trị viên"
            });
            var thuKhoRole = context.Roles.Add(new Role
            {
                Name = "Thủ kho"
            });
            var nhanVienBanHangRole = context.Roles.Add(new Role
            {
                Name = "Nhân viên bán hàng"
            });
            context.SaveChanges();

            var quantrivienUser = context.Users.Add(new User
            {
                Id = 1,
                Name = "Lê Anh Tuấn",
                Email = "letgo237@gmail.com",
                Password = HashPassword("test1234"),
                Address = "Thành phố Hồ Chí Minh",
                RoleId = quanTriVienRole.Id,
                CreationTime = DateTime.Now,
                IsDeleted = false,
                Dob = new DateTime(2000, 1, 1),
                PhoneNumber = "0369636841"
            });
            var nhanVien1User = context.Users.Add(new User
            {
                Id = 2,
                Name = "Nguyễn Xuân Tú",
                Email = "nguyenxuantu@gmail.com",
                Password = HashPassword("test1234"),
                Address = "Thành phố Hồ Chí Minh",
                RoleId = thuKhoRole.Id,
                CreationTime = DateTime.Now,
                IsDeleted = false,
                Dob = new DateTime(2000, 1, 1),
                PhoneNumber = "0378678408"
            });
            var nhanVien2User = context.Users.Add(new User
            {
                Id = 3,
                Name = "Nguyễn Thanh Tuấn",
                Email = "nguyenthanhtuan@gmail.com",
                Password = HashPassword("test1234"),
                Address = "Thành phố Hồ Chí Minh",
                RoleId = nhanVienBanHangRole.Id,
                CreationTime = DateTime.Now,
                IsDeleted = false,
                Dob = new DateTime(2000, 1, 1),
                PhoneNumber = "04378432980"
            });
            var nhanVien3User = context.Users.Add(new User
            {
                Id = 4,
                Name = "Lê Xuân Tùng",
                Email = "lexuantung@gmail.com",
                Password = HashPassword("test1234"),
                Address = "Thành phố Hồ Chí Minh",
                RoleId = nhanVienBanHangRole.Id,
                CreationTime = DateTime.Now,
                IsDeleted = false,
                Dob = new DateTime(2000, 1, 1),
                PhoneNumber = "01224578220"
            });
            context.SaveChanges();
        }

        private static string HashPassword(string password)
        {
            UnicodeEncoding uEncode = new UnicodeEncoding();
            byte[] bytPassword = uEncode.GetBytes(password);
            SHA512Managed sha = new SHA512Managed();
            byte[] hash = sha.ComputeHash(bytPassword);
            return Convert.ToBase64String(hash);
        }
    }
}
