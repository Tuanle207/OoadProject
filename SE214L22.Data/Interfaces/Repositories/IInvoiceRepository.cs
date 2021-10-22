using SE214L22.Data.Entity.AppCustomer;
using SE214L22.Shared.Dtos;
using System;

namespace SE214L22.Data.Interfaces.Repositories
{
    public interface IInvoiceRepository : IBaseRepository<Invoice>
    {
        ReportByDayDto GetReportByDay(DateTime day);
        ReportByMonthDto GetReportByMonth(DateTime selectedMonth);
        int GetRevenueByDay(DateTime day);
        int GetRevenueByMonth(DateTime day);
        int GetSalesByDay(DateTime day);
        int GetSalesByMonth(DateTime day);
    }
}