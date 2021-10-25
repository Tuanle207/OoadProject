using SE214L22.Contract.DTOs;
using SE214L22.Contract.Entities;
using SE214L22.Shared.AppConsts;
using SE214L22.Shared.Dtos;
using SE214L22.Shared.Pagination;
using System;
using System.Collections.Generic;

namespace SE214L22.Contract.Services
{
    public interface IProductService : IBaseService
    {
        Product AddProduct(ProductForCreationDto product);
        bool DeleteProduct(Product product);
        IEnumerable<HotProductDto> GetHotProducts(DateTime dateTime, TimeType type = TimeType.Month);
        PaginatedList<ProductDisplayDto> GetProductsForDisplayProduct(int page = 1, int limit = 9, ProductFilterDto Filter = null);
        PaginatedList<ProductForOrderCreationDto> GetProductsForOrderCreation(string keyword, int? page, int? limit);
        PaginatedList<ProductForSellDto> GetProductsForSell(string keyword, int? page, int? limit);
        bool HidenProduct(ProductDisplayDto product);
        bool UpdateProduct(ProductDisplayDto product);
    }
}