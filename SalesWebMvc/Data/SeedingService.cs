using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMvc.Models;
using SalesWebMvc.Models.Enums;

namespace SalesWebMvc.Data
{
    public class SeedingService
    {
        private SalesWebMvcContext _context;
        
        public SeedingService(SalesWebMvcContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if(_context.Department.Any() ||
                _context.Seller.Any() ||
                _context.SalesRecord.Any())
            {
                // The database has been seeded
                return;
            }

            Department d1 = new Department(1, "Computers");
            Department d2 = new Department(2, "Eletronics");

            Seller s1 = new Seller(1, "Bob Brown", "bob@gmail.com", new DateTime(1998, 4, 21), 4000.00,  d1);
            Seller s2 = new Seller(2, "Maria Green", "maria@gmail.com", new DateTime(1979, 12, 31), 2300.36, d2);

            SalesRecord sr1 = new SalesRecord(1, new DateTime(2018, 09, 25), 11000, SaleStatus.Billed, s2);
            SalesRecord sr2 = new SalesRecord(2, new DateTime(2018, 10, 03), 6540, SaleStatus.Canceled, s2);

            _context.Department.AddRange(d1, d2);
            _context.Seller.AddRange(s1, s2);
            _context.SalesRecord.AddRange(sr1, sr2);

            _context.SaveChanges();
        }
    }
}
