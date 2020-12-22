﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OoadProject.Shared.Dtos
{
    public class ReportByDayDto
    {
        public DateTime ReportDay { get; set; }
        public int TotalRevenue { get; set; }
        public IEnumerable<ProductReportByDayDto> Products { get; set; }
    }
}
