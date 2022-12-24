using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Data;
using SalesWebMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Services
{
    public class SalesRecordService
    {
        private SalesWebMvcContext _context;

        public SalesRecordService(SalesWebMvcContext context)
        {
            _context = context;
        }

        public async Task<List<SalesRecord>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
        {
            var sales = from sale in _context.SalesRecord select sale;

            if (minDate.HasValue)
            {
                sales = sales.Where(sale => sale.Date >= minDate);
            }

            if (maxDate.HasValue)
            {
                sales = sales.Where(sale => sale.Date <= maxDate);
            }

            return await
                sales
                .Include(sale => sale.Seller)
                .Include(sale => sale.Seller.Department)
                .OrderByDescending(sale => sale.Date)
                .ToListAsync();
        }
    }
}
