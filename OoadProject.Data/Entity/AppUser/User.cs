using System;

namespace OoadProject.Data.Entity.AppUser
{
    public class User : AppEntity
    {
        public string Name { get; set; }
        public int RoleId { get; set; }
        public DateTime Dob { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public DateTime CreationTime { get; set; }

        public Role Role { get; set; }
    }
}
