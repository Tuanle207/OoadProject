﻿using OoadProject.Core.AppSession;
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
    public class ReceiptService : BaseService
    {
        private readonly ReceiptRepository _receipRepository;
        private readonly ReceiptProductRepository _receiptProductRepository;
        private readonly ProductRepository _productRepository;
        private readonly OrderRepository _orderRepository;

        public ReceiptService()
        {
            _receipRepository = new ReceiptRepository();
            _receiptProductRepository = new ReceiptProductRepository();
            _productRepository = new ProductRepository();
            _orderRepository = new OrderRepository();
        }

        public void AddNewReceipt(OrderForListDto order, IEnumerable<ProductForReceiptCreation> receiptProducts)
        {
            // Add new receipt
            var total = 0;
            foreach (var item in receiptProducts) total += item.PriceIn;

            var storedReceipt = _receipRepository.Create(new Receipt
            {
                OrderId = order.Id,
                CreationTime = DateTime.Now,
                UserId = Session.CurrentUser.Id,
                Total = total
            });

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
    }
}