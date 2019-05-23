using System.Collections.Generic;
using System.Linq;
using SalesWebMVC.Models;

namespace SalesWebMVC.Services
{
    public class DepartamentoService
    {
        private readonly SalesWebMVCContext _context;

        public DepartamentoService(SalesWebMVCContext context)
        {
            _context = context;
        }

        
        public List<Departamento> FindAll()
        {
            return _context.Departamento.OrderBy(x => x.Nome).ToList();
        }

        /*
        public void Insert(Vendedor vendedor)
        {
            vendedor.Departamento = _context.Departamento.First();
            _context.Add(vendedor);
            _context.SaveChanges();
        }
        */

    }
}
