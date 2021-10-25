using SE214L22.Contract.Entities;
using System.Collections.Generic;

namespace SE214L22.Contract.Repositories
{
    public interface IOrderProductRepository : IBaseRepository<OrderProduct>
    {
        void DeleteAllByOrderId(int orderId);
        IEnumerable<OrderProduct> GetOrderProductsByOrderId(int orderId);
    }
}