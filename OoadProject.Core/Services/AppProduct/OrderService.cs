using OoadProject.Core.ViewModels.Home.Dtos;
using OoadProject.Core.ViewModels.Orders.Dtos;
using OoadProject.Data.Entity.AppProduct;
using OoadProject.Data.Repository;
using OoadProject.Shared.Dtos;
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
        private readonly OrderProductRepository _orderProductRepository;

        public OrderService()
        {
            _orderRepository = new OrderRepository();
            _orderProductRepository = new OrderProductRepository();
        }
        /// <summary>
        /// Get processing orders includes all except for completed order (status done)
        /// </summary>
        /// <param name="limit">Limit number or order loaded</param>
        public IEnumerable<ProcessingOrderDto> GetProcessingOrders(int limit = 5)
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

        public void AddNewOrder(OrderForCreationDto input, IList<SelectingProductDto> selectedProducts)
        {
            // save order
            var order = Mapper.Map<Order>(input);
            var storedOrder = _orderRepository.Create(order);

            // save order products
            var orderProducts = Mapper.Map<IList<OrderProduct>>(selectedProducts);
            for (var i = 0; i < orderProducts.Count(); i++)
            {
                orderProducts[i].OrderId = storedOrder.Id;
                _orderProductRepository.Create(orderProducts[i]);
            }

        }

        public IEnumerable<OrderForListDto> GetOrders(List<OrderStatus> filter, DateRangeDto dateRange)
        {
            var orders =_orderRepository.GetOrdersWithFilter(filter, 10, dateRange);
            return Mapper.Map<IEnumerable<OrderForListDto>>(orders);
        }

        public IEnumerable<T> GetOrderProducts<T>(int id)
        {
            var orderProducts = _orderProductRepository.GetOrderProductsByOrderId(id);
            return Mapper.Map<IEnumerable<T>>(orderProducts);
        }

        public void UpdateOrderStatus(int orderId, OrderStatus status)
        {
            _orderRepository.UpdateOrderStatusById(orderId, status);
        }
    }
}
