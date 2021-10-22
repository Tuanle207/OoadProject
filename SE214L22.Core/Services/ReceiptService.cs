using SE214L22.Core.AppSession;
using SE214L22.Core.Interfaces.Services;
using SE214L22.Core.ViewModels.Orders.Dtos;
using SE214L22.Data.Entity.AppProduct;
using SE214L22.Data.Interfaces.Repositories;
using SE214L22.Data.Repository;
using SE214L22.Shared.Dtos;
using System;
using System.Collections.Generic;

namespace SE214L22.Core.Services
{
    public class ReceiptService : BaseService, IReceiptService
    {
        private readonly IReceiptRepository _receipRepository;
        private readonly IReceiptProductRepository _receiptProductRepository;
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;

        public ReceiptService(IReceiptRepository receipRepository, IReceiptProductRepository receiptProductRepository, 
            IProductRepository productRepository, IOrderRepository orderRepository)
        {
            _receipRepository = receipRepository;
            _receiptProductRepository = receiptProductRepository;
            _productRepository = productRepository;
            _orderRepository = orderRepository;
        }

        public void AddNewReceipt(OrderForListDto order, IEnumerable<ProductForReceiptCreation> receiptProducts)
        {
            // Add new receipt
            var total = 0;
            foreach (var item in receiptProducts) total += item.PriceIn;

            var receipt = new Receipt
            {
                OrderId = order.Id,
                CreationTime = DateTime.Now.Date,
                UserId = Session.CurrentUser.Id,
                Total = total
            };

            var storedReceipt = _receipRepository.Create(receipt);

            // Add Receipt product and update product's information (priceIn, priceOut, Number)
            foreach (var item in receiptProducts)
            {
                // 1. Add Receipt product
                var receiptProduct = Mapper.Map<ReceiptProduct>(item);
                receiptProduct.ReceiptId = storedReceipt.Id;
                _receiptProductRepository.Create(receiptProduct);

                // 2. Update product's information (priceIn, priceOut, Number)
                _productRepository.UpdateSaleProperty(item.Id, item.Number, item.PriceIn);
            }

            // Update corresponding order status to done
            _orderRepository.UpdateOrderStatusById(order.Id, OrderStatus.Done);
        }

        public IEnumerable<ProductForReceiptCreation> GetReceiptProducts(int id)
        {
            var receipt = _receiptProductRepository.GetAllByReceiptId(id);
            return Mapper.Map<IEnumerable<ProductForReceiptCreation>>(receipt);
        }

        public IEnumerable<ReceiptForListDto> GetAllReceipts(DateRangeDto dateRange)
        {
            var receipt = _receipRepository.GetAll(dateRange);
            return Mapper.Map<IEnumerable<ReceiptForListDto>>(receipt);
        }
    }
}
