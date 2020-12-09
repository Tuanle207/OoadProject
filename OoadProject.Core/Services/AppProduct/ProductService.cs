using OoadProject.Core.ViewModels.Home.Dtos;
using OoadProject.Core.ViewModels.Orders.Dtos;
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

        public ProductService()
        {
            _productRepository = new ProductRepository();
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

        public PaginatedList<Product> GetProductsForOrderCreation(int page = 1, int limit = 10)
        {
            return _productRepository.GetProducts(page, limit);
        }
    }
}
