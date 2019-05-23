using SalesWebMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMVC.Services
{
    public class VendedoresService
    {
        private readonly SalesWebMVCContext _context;

        public VendedoresService(SalesWebMVCContext context)
        {
            _context = context;
        }

        public List<Vendedor> FindAll()
        {
            return _context.Vendedor.ToList();
        }

        public void Insert(Vendedor vendedor)
        {
            _context.Add(vendedor);
            _context.SaveChanges();
        }

        public Vendedor FindById (int id)
        {
            return _context.Vendedor.FirstOrDefault(vend => vend.Id == id);
        }

        public void Remove(int id)
        {
            var vendedor = _context.Vendedor.Find(id);
            _context.Remove(vendedor);
            _context.SaveChanges();
        }
    }
}
