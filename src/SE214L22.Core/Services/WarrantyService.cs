using SE214L22.Contract.DTOs;
using SE214L22.Contract.Entities;
using SE214L22.Contract.Repositories;
using SE214L22.Contract.Services;
using System.Collections.Generic;
using System;

namespace SE214L22.Core.Services
{
    public class WarrantyService : BaseService, IWarrantyService
    {
        private readonly IInvoiceProductRepository _invoiceProductRepository;
        private readonly IWarrantyOrderRepository _warrantyOrderRepository;

        public WarrantyService(IInvoiceProductRepository invoiceProductRepository, IWarrantyOrderRepository warrantyOrderRepository)
        {
            _invoiceProductRepository = invoiceProductRepository;
            _warrantyOrderRepository = warrantyOrderRepository;
        }

        public IEnumerable<ProductForWarrantyDto> GetCustomerProductsForWarranty(string phoneNumber)
        {
            return Mapper.Map<IEnumerable<ProductForWarrantyDto>>(_invoiceProductRepository.GetInvoiceProductsByCustomerPhoneNumber(phoneNumber));
        }

        public WarrantyOrder AddNewWarrantyOrder(ProductForWarrantyDto customerProduct)
        {
            // check if this product has already been add to warranty order? (through InvoiceId, ProductId)
            var noProductsBought = _invoiceProductRepository.GetNumberOfProductByInvoiceId(customerProduct.InvoiceId, customerProduct.Id);

            var noProductsOnWarratyOrders = _warrantyOrderRepository.GetNumberOfWarrantyOrderByInvoiceIdAndProductId(customerProduct.InvoiceId, customerProduct.Id);

            if (noProductsOnWarratyOrders == noProductsBought)
            {
                throw new Exception("Sản phẩm này đang được bảo hành rồi!");
            }

            // now we can actually add it
            var warrantyOrder = Mapper.Map<WarrantyOrder>(customerProduct);
            warrantyOrder.Status = (int)WarrantyOrderStatus.WaitForSent;
            warrantyOrder.CreationTime = DateTime.Now;
            return _warrantyOrderRepository.Create(warrantyOrder);
        }

        public IEnumerable<ProductForListWarrantyDto> GetWarrantyOrders(List<WarrantyOrderStatus> filter)
        {
            return Mapper.Map<IEnumerable<ProductForListWarrantyDto>>(_warrantyOrderRepository.GetAllWithStatusFilter(filter));
        }

        public void UpdateWarrantyOrderStatus(ProductForListWarrantyDto input)
        {
            var warrantyOrder = Mapper.Map<WarrantyOrder>(input);
            _warrantyOrderRepository.Update(warrantyOrder);
        }
    }
}
