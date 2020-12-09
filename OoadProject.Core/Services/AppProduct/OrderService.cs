using OoadProject.Core.ViewModels.Home.Dtos;
using OoadProject.Core.ViewModels.Orders.Dtos;
using OoadProject.Data.Entity.AppProduct;
using OoadProject.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OoadProject.Core.Services.AppProduct
{
    public class OrderService : BaseService
    {
        private readonly OrderRepository _orderRepository;

        public OrderService()
        {
            _orderRepository = new OrderRepository();
        }
        /// <summary>
        /// Get processing orders includes all except for completed order (status done)
        /// </summary>
        /// <param name="limit">Limit number or order loaded</param>
        public IEnumerable<ProcessingOrderDto> GetProcessingOrders(int? limit = null)
        {
            var processingOrders = _orderRepository.GetOrders(
                new List<OrderStatus>
                {
                    OrderStatus.WaitForSent,
                    OrderStatus.Sent
                }, limit);

            var dataForReturn = Mapper.Map<IEnumerable<ProcessingOrderDto>>(processingOrders);

            return dataForReturn;
        }

        public SelectingProductDto SelectProduct(ProductForOrderCreationDto product)
        {
            return Mapper.Map<SelectingProductDto>(product);
        }

    }
}
