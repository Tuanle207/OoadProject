using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OoadProject.Shared.Dtos
{
    public class ReportByMonthDto
    {
        public DateTime MonthReport { get; set; }
        public int TotalRevenue { get; set; }
        public int TotalProfit { get; set; }
        public IEnumerable<ItemReportByMonthDto> DayStatistics;
    }
}
