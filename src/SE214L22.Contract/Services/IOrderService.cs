using SE214L22.Contract.DTOs;
using SE214L22.Contract.Entities;
using SE214L22.Shared.Dtos;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SE214L22.Contract.Services
{
    public interface IOrderService : IBaseService
    {
        void AddNewOrder(OrderForCreationDto input, IList<SelectingProductDto> selectedProducts);
        void DeleleOrder(int orderId);
        T GetOrderById<T>(int orderId);
        IEnumerable<T> GetOrderProducts<T>(int id);
        IEnumerable<OrderForListDto> GetOrders(List<OrderStatus> filter, DateRangeDto dateRange);
        IEnumerable<ProcessingOrderDto> GetProcessingOrders(int limit = 5);
        SelectingProductDto SelectProduct(ProductForOrderCreationDto product);
        void UpdateOrderInfo(OrderForCreationDto input, ObservableCollection<SelectingProductDto> selectedProducts);
        void UpdateOrderStatus(int orderId, OrderStatus status);
    }
}