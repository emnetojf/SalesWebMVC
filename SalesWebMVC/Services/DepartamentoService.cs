using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMVC.Models;
using Microsoft.EntityFrameworkCore; // async

namespace SalesWebMVC.Services
{
    public class DepartamentoService
    {
        private readonly SalesWebMVCContext _context;

        public DepartamentoService(SalesWebMVCContext context)
        {
            _context = context;
        }

        /*
        // sync
        public List<Departamento> FindAll()
        {
            return _context.Departamento.OrderBy(x => x.Nome).ToList();
        }
        */

        // Async
        public async Task<List<Departamento>> FindAllAsync()
        {
            return await _context.Departamento.OrderBy(x => x.Nome).ToListAsync();
        }
    }
}
