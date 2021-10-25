using SE214L22.Contract.DTOs;
using SE214L22.Shared.AppConsts;
using SE214L22.Shared.Dtos;
using System;
using System.Collections.Generic;

namespace SE214L22.Contract.Services
{
    public interface IInvoiceService : IBaseService
    {
        void AddInvoice(InvoiceForCreationDto invoice, List<SelectingProductForSellDto> products);
        ReportByDayDto GetReportByDay(DateTime day);
        ReportByMonthDto GetReportByMonth(DateTime selectedMonth);
        RevenueDto GetRevenue(DateTime dateTime, TimeType type = TimeType.Day);
    }
}