using System;
using System.Collections.Generic;
using System.Linq;

namespace OoadProject.Shared.Pagination
{
    public class PaginatedList<T> : List<T> where T: class
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageRecords { get; set; }
        public int TotalRecords { get; set; }

        public PaginatedList(List<T> items, int totalRecords, int pageNumer, int pageSize)
        {
            TotalRecords = totalRecords;
            PageRecords = pageSize;
            CurrentPage = pageNumer;
            TotalPages = (int)Math.Ceiling(totalRecords / (double)pageSize);

            this.AddRange(items);
        }

        public static PaginatedList<T> Create(IQueryable<T> query, int pageNumber, int pageSize)
        {
            var count = query.Count();
            var items = query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return new PaginatedList<T>(items, count, pageNumber, pageSize);
        }
    }
}
