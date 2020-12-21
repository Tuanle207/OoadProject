﻿using OoadProject.Core.ViewModels.Home.Dtos;
using OoadProject.Core.ViewModels.Orders.Dtos;
using OoadProject.Core.ViewModels.Products.Dtos;
using OoadProject.Core.ViewModels.Sells.Dtos;
using OoadProject.Data;
using OoadProject.Data.Entity.AppProduct;
using OoadProject.Data.Repository;
using OoadProject.Shared.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OoadProject.Core.Services.AppProduct
{
    public class ProductService : BaseService
    {
        private readonly ProductRepository _productRepository;
        private readonly CategoryRepository _categoryRepository;

        public ProductService()
        {
            _productRepository = new ProductRepository();
            _categoryRepository = new CategoryRepository();
        }

        /// <summary>
        /// Get list of hot products in a period of time
        /// </summary>
        /// <param name="dateTime"></param>
        /// <param name="type">Day or Month or Year?</param>
        /// <returns></returns>
        public IEnumerable<HotProductDto> GetHotProducts(DateTime dateTime, TimeType type = TimeType.Month)
        {
            if (type == TimeType.Month)
            {
                return Mapper.Map<IEnumerable<HotProductDto>>(_productRepository.GetProductsOrderBySales(dateTime));
            }

            return null;
        }

        public PaginatedList<ProductForOrderCreationDto> GetProductsForOrderCreation(int page = 1, int limit = 4)
        {
            var rawProducts = _productRepository.GetProducts(page, limit);

            var productsForReturn = new PaginatedList<ProductForOrderCreationDto>
            (
                Mapper.Map<List<ProductForOrderCreationDto>>(rawProducts.Data),
                rawProducts.TotalRecords,
                rawProducts.CurrentPage,
                rawProducts.PageRecords
            );
            return productsForReturn;
        }

        public PaginatedList<ProductForSellDto> GetProductsForSell(int page = 1, int limit = 4)
        {
            var rawProducts = _productRepository.GetProducts(page, limit);

            var productsForReturn = new PaginatedList<ProductForSellDto>
            (
                Mapper.Map<List<ProductForSellDto>>(rawProducts.Data),
                rawProducts.TotalRecords,
                rawProducts.CurrentPage,
                rawProducts.PageRecords
            );
            return productsForReturn;
        }

        public PaginatedList<ProductDisplayDto> GetProductsForDisplayProduct(int page = 1, int limit = 9)
        {
            var rawProducts = _productRepository.GetProducts(page, limit);

            var productsForReturn = new PaginatedList<ProductDisplayDto>
            (
                Mapper.Map<List<ProductDisplayDto>>(rawProducts.Data),
                rawProducts.TotalRecords,
                rawProducts.CurrentPage,
                rawProducts.PageRecords
            );
            return productsForReturn;
        }

        public Product AddProduct(ProductForCreationDto product)
        {
            var newProduct = Mapper.Map<Product>(product);
            if (newProduct.ReturnRate != null)
                newProduct.PriceOut = (int)Math.Round(newProduct.PriceIn * (1 + (float)newProduct.ReturnRate/100)/1000)*1000;
            else
            {
                var category = _categoryRepository.Get(product.CategoryId);
                newProduct.PriceOut = (int)Math.Round(newProduct.PriceIn * (1 + (float)category.ReturnRate / 100) / 1000) * 1000;
            }    
                

            return _productRepository.Create(newProduct);
        }

        public bool UpdateProduct(ProductDisplayDto product)
        {
            return true;
        }

        public bool DeleteProduct(Product product)
        {
            return _productRepository.Delete(product.Id);
        }
    }
}
