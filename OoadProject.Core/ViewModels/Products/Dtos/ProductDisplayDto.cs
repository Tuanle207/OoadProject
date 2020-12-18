﻿using OoadProject.Data.Entity.AppProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OoadProject.Core.ViewModels.Products.Dtos
{
    public class ProductDisplayDto : BaseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CategoryName { get; set; }
        public string ManufacturerName { get; set; }
        public int Number { get; set;  }
        public int PriceIn { get; set; }
        public int PriceOut { get; set; }
        public int WarrantyPeriod { get; set; }
        public float? ReturnRate { get; set; }
        public string Status { get; set; }

        public static string MapEnumToStatus(ProductStatus status)
        {
            switch (status)
            {
                case ProductStatus.Available:
                    return "Có sẵn";
                case ProductStatus.Suspended:
                    return "Ngừng kinh doanh";
                default:
                    return "Không xác định";
            }
        }

    }
}