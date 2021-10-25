using SE214L22.Contract.DTOs;
using SE214L22.Contract.Entities;
using System.Collections.Generic;

namespace SE214L22.Contract.Services
{
    public interface IWarrantyService : IBaseService
    {
        WarrantyOrder AddNewWarrantyOrder(ProductForWarrantyDto customerProduct);
        IEnumerable<ProductForWarrantyDto> GetCustomerProductsForWarranty(string phoneNumber);
        IEnumerable<ProductForListWarrantyDto> GetWarrantyOrders(List<WarrantyOrderStatus> filter);
        void UpdateWarrantyOrderStatus(ProductForListWarrantyDto input);
    }
}