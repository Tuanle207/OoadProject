using Autofac.Extras.Moq;
using Moq;
using NUnit.Framework;
using SE214L22.Contract.DTOs;
using SE214L22.Contract.Entities;
using SE214L22.Contract.Repositories;
using SE214L22.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE214L22.CoreTests.Services
{
    [TestFixture]
    public class WarrantyServiceTests
    {
        #region GetCustomerProductsForWarranty Test
        [Test]
        public void GetCustomerProductsForWarranty_PhoneNumberIsValid_ReturnListProducts()
        {
            using (var mock = AutoMock.GetLoose())
            {
                var phoneNumber = "01224578226";
                var sampleProductsForWarranty = new List<InvoiceProduct>();

                mock.Mock<IInvoiceProductRepository>()
                    .Setup(x => x.GetInvoiceProductsByCustomerPhoneNumber(It.IsAny<string>()))
                    .Returns(sampleProductsForWarranty);
                var warrantyService = mock.Create<WarrantyService>();

                var actual = warrantyService.GetCustomerProductsForWarranty(phoneNumber);

                Assert.IsInstanceOf<IEnumerable<ProductForWarrantyDto>>(actual);

            }
        }
        [Test]
        public void GetCustomerProductsForWarranty_PhoneNumberIsInvalid_ReturnListProducts()
        {
            using (var mock = AutoMock.GetLoose())
            {
                var phoneNumber = "invalid-phone-number";
                var sampleProductsForWarranty = new List<InvoiceProduct>();

                mock.Mock<IInvoiceProductRepository>()
                    .Setup(x => x.GetInvoiceProductsByCustomerPhoneNumber(It.IsAny<string>()))
                    .Returns(sampleProductsForWarranty);
                var warrantySerivice = mock.Create<WarrantyService>();

                var actual = warrantySerivice.GetCustomerProductsForWarranty(phoneNumber);

                Assert.IsInstanceOf<IEnumerable<ProductForWarrantyDto>>(actual);

            }
        }

        #endregion

        #region AddNewWarrantyOrder
        [Test]
        public void AddNewWarrantyOrder_WarrantyProductIsNull_ThrowsException()
        {
            using (var mock = AutoMock.GetLoose())
            {
                ProductForWarrantyDto warrantyProduct = null;

                mock.Mock<IInvoiceProductRepository>()
                   .Setup(x => x.GetNumberOfProductByInvoiceId(It.IsAny<int>(), It.IsAny<int>()))
                   .Returns(It.IsAny<int>());

                mock.Mock<IWarrantyOrderRepository>()
                    .Setup(x => x.GetNumberOfWarrantyOrderByInvoiceIdAndProductId(It.IsAny<int>(), It.IsAny<int>()))
                    .Returns(It.IsAny<int>());

                mock.Mock<IWarrantyOrderRepository>()
                    .Setup(x => x.Create(It.IsAny<WarrantyOrder>()))
                    .Returns(It.IsAny<WarrantyOrder>());

                var warrantyService = mock.Create<WarrantyService>();

                Assert.Throws<NullReferenceException>(() => warrantyService.AddNewWarrantyOrder(warrantyProduct));
            }
        }

        [Test]
        [TestCase(1, "Product 1", "Manufracturer 1", 1, "Le Anh Tuan", 1, 1)]
        public void AddNewWarrantyOrder_WarrantyProductIsValid_ReturnsWarrantyProduct(int id, string name, 
            string manufacturerName, int warrantyTimeRemaining, string customerName, int customerId, int invoiceId)
        {
            using (var mock = AutoMock.GetLoose())
            {
                var warrantyProduct = new ProductForWarrantyDto
                {
                    Id = id,
                    Name = name,
                    ManufacturerName = manufacturerName,
                    WarrantyTimeRemaining = warrantyTimeRemaining,
                    CustomerName = customerName,
                    CustomerId =  customerId,
                    InvoiceId = invoiceId,
                    InvoiceTime = new DateTime(2021,1,1)
                };

                var sampleWarrantyOrder = new WarrantyOrder
                {
                    Id = 1,
                    CreationTime = DateTime.Now,
                    CustomerId = 1,
                    InvoiceId = 1,
                    ProductId = 1,
                    Status = (int)WarrantyOrderStatus.WaitForSent
                };

                mock.Mock<IInvoiceProductRepository>()
                   .Setup(x => x.GetNumberOfProductByInvoiceId(It.IsAny<int>(), It.IsAny<int>()))
                   .Returns(1);

                mock.Mock<IWarrantyOrderRepository>()
                    .Setup(x => x.GetNumberOfWarrantyOrderByInvoiceIdAndProductId(It.IsAny<int>(), It.IsAny<int>()))
                    .Returns(2);

                mock.Mock<IWarrantyOrderRepository>()
                    .Setup(x => x.Create(It.IsAny<WarrantyOrder>()))
                    .Returns(sampleWarrantyOrder);

                var warrantyService = mock.Create<WarrantyService>();

                var actual = warrantyService.AddNewWarrantyOrder(warrantyProduct);
                Assert.IsInstanceOf<WarrantyOrder>(actual);
            }
        }

        [Test]
        [TestCase(-1, "Product 1", "Manufracturer 1", 1, "Le Anh Tuan", 1, 1)]
        [TestCase(0, "Product 1", "Manufracturer 1", 1, "Le Anh Tuan", 1, 1)]
        [TestCase(1, null, "Manufracturer 1", 1, "Le Anh Tuan", 1, 1)]
        [TestCase(1, "", "Manufracturer 1", 1, "Le Anh Tuan", 1, 1)]
        [TestCase(1, "Product 1", null, 1, "Le Anh Tuan", 1, 1)]
        [TestCase(1, "Product 1", "", 1, "Le Anh Tuan", 1, 1)]
        [TestCase(1, "Product 1", "Manufracturer 1", -1, "Le Anh Tuan", 1, 1)]
        [TestCase(1, "Product 1", "Manufracturer 1", 0, "Le Anh Tuan", 1, 1)]
        [TestCase(1, "Product 1", "Manufracturer 1", 1, null, 1, 1)]
        [TestCase(1, "Product 1", "Manufracturer 1", 1, "", 1, 1)]
        [TestCase(1, "Product 1", "Manufracturer 1", 1, "Le Anh Tuan", -1, 1)]
        [TestCase(1, "Product 1", "Manufracturer 1", 1, "Le Anh Tuan", 0, 1)]
        [TestCase(1, "Product 1", "Manufracturer 1", 1, "Le Anh Tuan", 1, -1)]
        [TestCase(1, "Product 1", "Manufracturer 1", 1, "Le Anh Tuan", 1, 0)]
        public void AddNewWarrantyOrder_WarrantyProductIsInvalid_ThrowsException(int id, string name,
            string manufacturerName, int warrantyTimeRemaining, string customerName, int customerId, int invoiceId)
        {
            using (var mock = AutoMock.GetLoose())
            {
                var warrantyProduct = new ProductForWarrantyDto
                {
                    Id = id,
                    Name = name,
                    ManufacturerName = manufacturerName,
                    WarrantyTimeRemaining = warrantyTimeRemaining,
                    CustomerName = customerName,
                    CustomerId = customerId,
                    InvoiceId = invoiceId,
                    InvoiceTime = new DateTime(2021, 1, 1)
                };

                var sampleWarrantyOrder = new WarrantyOrder
                {
                    Id = 1,
                    CreationTime = DateTime.Now,
                    CustomerId = 1,
                    InvoiceId = 1,
                    ProductId = 1,
                    Status = (int)WarrantyOrderStatus.WaitForSent
                };

                mock.Mock<IInvoiceProductRepository>()
                   .Setup(x => x.GetNumberOfProductByInvoiceId(It.IsAny<int>(), It.IsAny<int>()))
                   .Returns(1);

                mock.Mock<IWarrantyOrderRepository>()
                    .Setup(x => x.GetNumberOfWarrantyOrderByInvoiceIdAndProductId(It.IsAny<int>(), It.IsAny<int>()))
                    .Returns(2);

                mock.Mock<IWarrantyOrderRepository>()
                    .Setup(x => x.Create(It.IsAny<WarrantyOrder>()))
                    .Returns(sampleWarrantyOrder);

                var warrantyService = mock.Create<WarrantyService>();

                Assert.Throws<Exception>(() => warrantyService.AddNewWarrantyOrder(warrantyProduct));
            }
        }

        #endregion

        #region GetWarrantyOrders Test
        [Test]
        public void GetWarrantyOrders_FilterIsNull_ThrowsException()
        {
            using (var mock = AutoMock.GetLoose())
            {
                List<WarrantyOrderStatus> filter = null;
                var sampleWarrantyOrders = new List<WarrantyOrder>();

                mock.Mock<IWarrantyOrderRepository>()
                    .Setup(x => x.GetAllWithStatusFilter(filter))
                    .Returns(sampleWarrantyOrders);
                var warrantyService = mock.Create<WarrantyService>();

            }
        }

        [Test]
        public void GetWarrantyOrders_FilterIsValid_ThrowsException()
        {
            using (var mock = AutoMock.GetLoose())
            {
                List<WarrantyOrderStatus> filter = new List<WarrantyOrderStatus>();
                var sampleWarrantyOrders = new List<WarrantyOrder>();

                mock.Mock<IWarrantyOrderRepository>()
                    .Setup(x => x.GetAllWithStatusFilter(filter))
                    .Returns(sampleWarrantyOrders);
                var warrantyService = mock.Create<WarrantyService>();

                var actual = warrantyService.GetWarrantyOrders(filter);

                Assert.IsInstanceOf<IEnumerable<ProductForListWarrantyDto>>(actual);

            }
        }
        #endregion

        #region UpdateWarrantyOrderStatus
        
        [Test]
        public void UpdateWarrantyOrderStatus_ProductForListWarrantyIsNull_ThrowsException()
        {
            using (var mock = AutoMock.GetLoose())
            {
                ProductForListWarrantyDto productForListWarranty = null;

                mock.Mock<IWarrantyOrderRepository>()
                    .Setup(x => x.Update(It.IsAny<WarrantyOrder>()));

                var warrantyService = mock.Create<WarrantyService>();

                Assert.Throws<Exception>(() => warrantyService.UpdateWarrantyOrderStatus(productForListWarranty));
            }
        }

        [Test]
        [TestCase(1, 1, "Customer 1", "01224578226", 1, "Product 1", 1)]
        [TestCase(1, 1, "Customer 1", "01224578226", 1, "Product 1", 0)]
        public void UpdateWarrantyOrderStatus_ProductForListWarrantyIsValid_DoesNotThrowException(int id, int customerId,
            string customerName, string phoneNumber, int productId, string productName, int warrantyStatus)
        {
            using (var mock = AutoMock.GetLoose())
            {
                var productForListWarranty = new ProductForListWarrantyDto
                {
                    Id = id,
                    CustomerId = customerId,
                    CustomerName = customerName,
                    PhoneNumber = phoneNumber,
                    ProductId = productId.ToString(),
                    ProductName = productName,
                    WarrantyStatus = warrantyStatus
                };

                mock.Mock<IWarrantyOrderRepository>()
                    .Setup(x => x.Update(It.IsAny<WarrantyOrder>()));

                var warrantyService = mock.Create<WarrantyService>();

                Assert.DoesNotThrow(() => warrantyService.UpdateWarrantyOrderStatus(productForListWarranty));
            }
        }

        [Test]
        [TestCase(-1, 1, "Customer 1", "01224578226", 1, "Product 1", 1)]
        [TestCase(0, 1, "Customer 1", "01224578226", 1, "Product 1", 1)]
        [TestCase(1, -1, "Customer 1", "01224578226", 1, "Product 1", 1)]
        [TestCase(1, 0, null, "01224578226", 1, "Product 1", 1)]
        [TestCase(1, 1, "", "01224578226", 1, "Product 1", 1)]
        [TestCase(1, 1, null, "01224578226", 1, "Product 1", 1)]
        [TestCase(1, 1, "Customer 1", null, 1, "Product 1", 1)]
        [TestCase(1, 1, "Customer 1", "", 1, "Product 1", 1)]
        [TestCase(1, 1, "Customer 1", "01224578226", -1, "Product 1", 1)]
        [TestCase(1, 1, "Customer 1", "01224578226", 0, "Product 1", 1)]
        [TestCase(1, 1, "Customer 1", "01224578226", 1, null, 1)]
        [TestCase(1, 1, "Customer 1", "01224578226", 1, "", 1)]
        [TestCase(1, 1, "Customer 1", "01224578226", 1, "Product 1", -1)]
        public void UpdateWarrantyOrderStatus_ProductForListWarrantyIsInvalid_ThrowsException(int id, int customerId,
            string customerName, string phoneNumber, int productId, string productName, int warrantyStatus)
        {
            using (var mock = AutoMock.GetLoose())
            {
                var productForListWarranty = new ProductForListWarrantyDto
                {
                    Id = id,
                    CustomerId = customerId,
                    CustomerName = customerName,
                    PhoneNumber = phoneNumber,
                    ProductId = productId.ToString(),
                    ProductName = productName,
                    WarrantyStatus = warrantyStatus,
                    CreationTime = new DateTime(2021, 1, 1)
                };

                mock.Mock<IWarrantyOrderRepository>()
                    .Setup(x => x.Update(It.IsAny<WarrantyOrder>()));

                var warrantyService = mock.Create<WarrantyService>();

                Assert.Throws<Exception>(() => warrantyService.UpdateWarrantyOrderStatus(productForListWarranty));
            }
        }

        #endregion
    }
}
