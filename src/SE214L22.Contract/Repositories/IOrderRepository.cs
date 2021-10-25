using SE214L22.Contract.Entities;
using SE214L22.Shared.Dtos;
using System.Collections.Generic;

namespace SE214L22.Contract.Repositories
{
    public interface IOrderRepository : IBaseRepository<Order>
    {
        IEnumerable<Order> GetOrders(List<OrderStatus> status, int limit);
        IEnumerable<Order> GetOrdersWithFilter(List<OrderStatus> status, int limit, DateRangeDto dateRange);
        void UpdateOrderStatusById(int orderId, OrderStatus status);
        void UpdateProviderById(int orderId, int providerId);
    }
}