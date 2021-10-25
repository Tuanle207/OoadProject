using SE214L22.Contract.Entities;
using System;

namespace SE214L22.CoreTests.Helpers
{
    public class DataSample
    {
        public static User GetSampleCurrentUser()
        {
            return new User
            {
                Id = 1,
                Address = "TP. HCM",
                CreationTime = new DateTime(2019, 1, 1),
                Dob = new DateTime(2000, 10, 3),
                Email = "letgo237@gmail.com",
                Name = "Le Anh Tuan",
                PhoneNumber = "01224578226"
            };
        }

        public static Customer GetSampleCustomer()
        {
            return new Customer
            {
                Id = 1,
                Name = "Lê Anh Tuấn",
                PhoneNumber = "01224578226",
                AccumulatedPoint = 0,
                CreationTime = new DateTime(2020, 1, 1),
                CustomerLevelId = 0
            };
        }
    }
}
