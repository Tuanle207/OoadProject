using SE214L22.Core.ViewModels.Warranties.Dtos;
using SE214L22.Data.Entity.AppCustomer;
using System.Collections.Generic;

namespace SE214L22.Core.Interfaces.Services
{
    public interface IWarrantyService : IBaseService
    {
        WarrantyOrder AddNewWarrantyOrder(ProductForWarrantyDto customerProduct);
        IEnumerable<ProductForWarrantyDto> GetCustomerProductsForWarranty(string phoneNumber);
        IEnumerable<ProductForListWarrantyDto> GetWarrantyOrders(List<WarrantyOrderStatus> filter);
        void UpdateWarrantyOrderStatus(ProductForListWarrantyDto input);
    }
}