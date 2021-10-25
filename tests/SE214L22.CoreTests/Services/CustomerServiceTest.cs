using Autofac.Extras.Moq;
using Moq;
using NUnit.Framework;
using SE214L22.Contract.DTOs;
using SE214L22.Contract.Entities;
using SE214L22.Contract.Repositories;
using SE214L22.Core.Services;
using SE214L22.CoreTests.Helpers;
using SE214L22.Shared.Dtos;
using SE214L22.Shared.Pagination;
using System;
using System.Collections.Generic;

namespace SE214L22.CoreTests.Services
{

    [TestFixture]
    public class CustomerServiceTest
    {
        [Test]
        [TestCase(false, false, false)]
        [TestCase(false, false, true)]
        [TestCase(false, true, true)]
        [TestCase(true, true, true)]
        public void GetCustomersForDisplayCustomer_Success_ReturnPagedCustomerDisplayDtoList(bool isPageUndefined, bool isLimitUndefined, bool isFilterUndefined)
        {
            using (var mock = AutoMock.GetLoose())
            {
                var page = 1;
                var limit = 15;
                var filter = new CustomerFilterDto
                {
                    NameCustomerKeyWord = "customer"
                };

                var sampleCustomers = new PaginatedList<Customer>
                (
                    new List<Customer> { DataSample.GetSampleCustomer() },
                    2,
                    1,
                    1
                );

                mock.Mock<ICustomerRepository>()
                    .Setup(x => x.GetCustomers(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<CustomerFilterDto>()))
                    .Returns(sampleCustomers);

                var customerService = mock.Create<CustomerService>();

                if (!isPageUndefined && !isLimitUndefined && !isFilterUndefined)
                {
                    var actual = customerService.GetCustomersForDisplayCustomer(page, limit, filter);
                    Assert.IsInstanceOf<PaginatedList<CustomerDisplayDto>>(actual);
                } else if (!isPageUndefined && !isLimitUndefined && isFilterUndefined)
                {
                    var actual = customerService.GetCustomersForDisplayCustomer(page, limit);
                    Assert.IsInstanceOf<PaginatedList<CustomerDisplayDto>>(actual);
                } else if (!isPageUndefined && isLimitUndefined && isFilterUndefined)
                {
                    var actual = customerService.GetCustomersForDisplayCustomer(page);
                    Assert.IsInstanceOf<PaginatedList<CustomerDisplayDto>>(actual);
                } else
                {
                    var actual = customerService.GetCustomersForDisplayCustomer();
                    Assert.IsInstanceOf<PaginatedList<CustomerDisplayDto>>(actual);
                }
            }
        }

        [Test]
        [TestCase(1)]
        [TestCase(0)]
        [TestCase(-1)]
        public void GetCustomer_Success_ReturnCustomerOrNull(int id)
        {
            using (var mock = AutoMock.GetLoose())
            {
                var customer = id <= 0 ? null : DataSample.GetSampleCustomer();
                mock.Mock<ICustomerRepository>()
                    .Setup(x => x.Get(It.IsAny<int>()))
                    .Returns(customer);

                var customerService = mock.Create<CustomerService>();

                var actual = customerService.GetCustomer(id);

                if (id <= 0)
                {
                    Assert.IsNull(actual);
                }
                else
                {
                    Assert.IsInstanceOf<Customer>(actual);
                }
            }
        }

        [Test]
        public void GetCustomerByPhone_Success_ReturnCustomer()
        {
            using (var mock = AutoMock.GetLoose())
            {
                var customer = DataSample.GetSampleCustomer();
                mock.Mock<ICustomerRepository>()
                    .Setup(x => x.GetCustomByPhoneNumber(It.IsAny<string>()))
                    .Returns(customer);

                var customerService = mock.Create<CustomerService>();

                var actual = customerService.GetCustomerByPhone("01224578226");

                Assert.IsInstanceOf<Customer>(actual);
            }
        }

        [Test]
        public void GetCustomerByPhone_Success_ReturnNull()
        {
            using (var mock = AutoMock.GetLoose())
            {
                Customer customer = null;
                mock.Mock<ICustomerRepository>()
                    .Setup(x => x.GetCustomByPhoneNumber(It.IsAny<string>()))
                    .Returns(customer);

                var customerService = mock.Create<CustomerService>();

                var actual = customerService.GetCustomerByPhone("invalid-or-unavailable-sdt");

                Assert.IsNull(actual);
            }
        }

        [Test]
        public void GetCustomers_Success_ReturnCustomerList()
        {
            using (var mock = AutoMock.GetLoose())
            {
                var customers = new List<Customer>();
                mock.Mock<ICustomerRepository>()
                    .Setup(x => x.GetAllCustomers())
                    .Returns(customers);

                var customerService = mock.Create<CustomerService>();

                var actual = customerService.GetCustomers();

                Assert.IsInstanceOf<IEnumerable<Customer>>(actual);
            }
        }

        [Test]
        public void AddCustomer_Success_ReturnCustomer()
        {
            using (var mock = AutoMock.GetLoose())
            {
                var customerCreation = new CustomerForCreationDto
                {
                    Name = "Lê Anh Tuấn",
                    AccumulatedPoint = 0,
                    CreationTime = DateTime.Now,
                    CustomerLevelId = 1,
                    PhoneNumber = "01224578226"
                };
                var customer = DataSample.GetSampleCustomer();

                mock.Mock<ICustomerRepository>()
                    .Setup(x => x.Create(It.IsAny<Customer>()))
                    .Returns(customer);

                var customerService = mock.Create<CustomerService>();

                var actual = customerService.AddCustomer(customerCreation);

                Assert.IsInstanceOf<Customer>(actual);
            }
        }

        [Test]
        public void AddCustomer_Fail_ReturnNull()
        {
            using (var mock = AutoMock.GetLoose())
            {
                CustomerForCreationDto customerCreation = null;

                mock.Mock<ICustomerRepository>()
                    .Setup(x => x.Create(It.IsAny<Customer>()));

                var customerService = mock.Create<CustomerService>();

                var actual = customerService.AddCustomer(customerCreation);
                
                Assert.IsNull(actual);
            }
        }

        [Test]
        public void HideCustomer_Success_ReturnTrue()
        {
            using (var mock = AutoMock.GetLoose())
            {
                var customer = new CustomerDisplayDto
                {
                    Id = 1,
                    AccumulatedPoint = 0,
                    CreationTime = new DateTime(2021, 1, 1),
                    CustomerLevelId = 1,
                    IsDeleted = false,
                    Name = "Lê Anh Tuấn",
                    PhoneNumber = ""
                };

                mock.Mock<ICustomerRepository>()
                    .Setup(x => x.Update(It.IsAny<Customer>()))
                    .Returns(true);

                var customerService = mock.Create<CustomerService>();

                var actual = customerService.HideCustomer(customer);

                Assert.IsTrue(actual);
            }
        }

        [Test]
        public void HideCustomer_Fail_ReturnFalse()
        {
            using (var mock = AutoMock.GetLoose())
            {
                var customer = new CustomerDisplayDto
                {
                    Id = 1,
                    AccumulatedPoint = 0,
                    CreationTime = new DateTime(2021, 1, 1),
                    CustomerLevelId = 1,
                    IsDeleted = false,
                    Name = "Lê Anh Tuấn",
                    PhoneNumber = ""
                };

                mock.Mock<ICustomerRepository>()
                    .Setup(x => x.Update(It.IsAny<Customer>()))
                    .Returns(false);

                var customerService = mock.Create<CustomerService>();

                var actual = customerService.HideCustomer(customer);

                Assert.IsFalse(actual);
            }
        }

        [Test]
        public void HideCustomer_Fail_ThrowException()
        {
            using (var mock = AutoMock.GetLoose())
            {
                CustomerDisplayDto customer = null;

                mock.Mock<ICustomerRepository>()
                    .Setup(x => x.Update(It.IsAny<Customer>()))
                    .Returns(false);

                var customerService = mock.Create<CustomerService>();

                Assert.Throws<NullReferenceException>(() => customerService.HideCustomer(customer));
            }
        }

        [Test]
        public void DeleteCustomer_Success_ReturnTrue()
        {
            using (var mock = AutoMock.GetLoose())
            {
                var customer = DataSample.GetSampleCustomer();

                mock.Mock<ICustomerRepository>()
                    .Setup(x => x.Delete(It.IsAny<int>()))
                    .Returns(true);

                var customerService = mock.Create<CustomerService>();

                var actual = customerService.DeleteCustomer(customer);

                Assert.IsTrue(actual);
            }
        }

        [Test]
        public void DeleteCustomer_Fail_ReturnFalse()
        {
            using (var mock = AutoMock.GetLoose())
            {
                var customer = DataSample.GetSampleCustomer();

                mock.Mock<ICustomerRepository>()
                    .Setup(x => x.Delete(It.IsAny<int>()))
                    .Returns(false);

                var customerService = mock.Create<CustomerService>();

                var actual = customerService.DeleteCustomer(customer);

                Assert.IsFalse(actual);
            }
        }

        [Test]
        public void DeleteCustomer_Fail_ThrowException()
        {
            using (var mock = AutoMock.GetLoose())
            {
                Customer customer = null;

                mock.Mock<ICustomerRepository>()
                    .Setup(x => x.Delete(It.IsAny<int>()))
                    .Returns(false);

                var customerService = mock.Create<CustomerService>();

                Assert.Throws<NullReferenceException>(() => customerService.DeleteCustomer(customer));
            }
        }
    }
}
