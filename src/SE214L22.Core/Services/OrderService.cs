using SE214L22.Contract.DTOs;
using SE214L22.Contract.Entities;
using SE214L22.Contract.Repositories;
using SE214L22.Contract.Services;
using System.Collections.Generic;
using SE214L22.Shared.Dtos;
using System.Collections.ObjectModel;
using System.Linq;

namespace SE214L22.Core.Services
{
    public class OrderService : BaseService, IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderProductRepository _orderProductRepository;

        public OrderService(IOrderProductRepository orderProductRepository, IOrderRepository orderRepository)
        {
            _orderProductRepository = orderProductRepository;
            _orderRepository = orderRepository;
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
            var orders = _orderRepository.GetOrdersWithFilter(filter, 10, dateRange);
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

        public T GetOrderById<T>(int orderId)
        {
            var order = _orderRepository.Get(orderId);
            return Mapper.Map<T>(order);
        }

        public void UpdateOrderInfo(OrderForCreationDto input, ObservableCollection<SelectingProductDto> selectedProducts)
        {
            // save order
            _orderRepository.UpdateProviderById(input.Id, input.ProviderId);

            // delete all old order's products
            _orderProductRepository.DeleteAllByOrderId(input.Id);

            // save all new order's products
            var orderProducts = Mapper.Map<IList<OrderProduct>>(selectedProducts);
            for (var i = 0; i < orderProducts.Count(); i++)
            {
                orderProducts[i].OrderId = input.Id;
                _orderProductRepository.Create(orderProducts[i]);
            }
        }

        public void DeleleOrder(int orderId)
        {
            _orderRepository.Delete(orderId);
        }
    }
}
