using Microsoft.EntityFrameworkCore;
using SalesWebMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMVC.Services
{
    public class VendasService
    {

        private readonly SalesWebMVCContext _context;

        public VendasService(SalesWebMVCContext context)
        {
            _context = context;
        }

        public async Task<List<Vendas>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
        {
            var result = from objVend in _context.Vendas select objVend;

            if (minDate.HasValue)
            {
                result = result.Where(vendas => vendas.DataVendas >= minDate);
            }

            if (maxDate.HasValue)
            {
                result = result.Where(vendas => vendas.DataVendas <= maxDate);
            }

            return await result
                    .Include(vend => vend.vendedor)
                    .Include(vend => vend.vendedor.Departamento)
                    .OrderByDescending(vend => vend.DataVendas)
                    .ToListAsync();
        }
    }
}
