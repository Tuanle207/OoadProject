using SE214L22.Contract.DTOs;
using SE214L22.Contract.Entities;
using SE214L22.Contract.Repositories;
using SE214L22.Contract.Services;
using System.Collections.Generic;
using SE214L22.Shared.Dtos;
using System;
using SE214L22.Contract.Util;

namespace SE214L22.Core.Services
{
    public class ReceiptService : BaseService, IReceiptService
    {
        private readonly ISession _session;
        private readonly IReceiptRepository _receipRepository;
        private readonly IReceiptProductRepository _receiptProductRepository;
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;

        public ReceiptService(IReceiptRepository receipRepository, IReceiptProductRepository receiptProductRepository,
            IProductRepository productRepository, IOrderRepository orderRepository, ISession session)
        {
            _receipRepository = receipRepository;
            _receiptProductRepository = receiptProductRepository;
            _productRepository = productRepository;
            _orderRepository = orderRepository;
            _session = session;
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
                UserId = _session.CurrentUser.Id,
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
