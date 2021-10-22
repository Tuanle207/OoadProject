using SE214L22.Data.Entity.AppProduct;
using SE214L22.Data.Entity;
using SE214L22.Shared.Dtos;
using SE214L22.Shared.Pagination;
using System;
using System.Collections.Generic;

namespace SE214L22.Data.Interfaces.Repositories
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        string GetProductPhotoById(int id);
        PaginatedList<Product> GetProducts(int page, int limit, ProductFilterDto Filter = null);
        PaginatedList<Product> GetProductsForImport(string keyword, int page, int limit, bool filterEmpty = false);
        IEnumerable<ProductAggregateDto> GetProductsOrderBySales(DateTime day, int limit = 10);
        void UpdateNumberById(int id, int selectedNumber);
        void UpdateSaleProperty(int id, int number, int priceIn);
    }
}