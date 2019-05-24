using SalesWebMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SalesWebMVC.Services.Exceptions;
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

        /*
        //sync
        public List<Vendedor> FindAll()
        {
            return _context.Vendedor.ToList();
        }
        */
        //Async

        public async Task<List<Vendedor>> FindAllAsync()
        {
            return await _context.Vendedor.ToListAsync();
        }


        /* sync
        public void Insert(Vendedor vendedor)
        {
            _context.Add(vendedor);
            _context.SaveChanges();
        }
        */

        // sync
        public async Task InsertAsync(Vendedor vendedor)
        {
            _context.Add(vendedor);
            await _context.SaveChangesAsync();
        }

        /* sync
        public Vendedor FindById(int id)
        {
            return _context.Vendedor.Include(depart => depart.Departamento).FirstOrDefault(vend => vend.Id == id);
        }
        */

        // Async
        public async Task<Vendedor> FindByIdAsync(int id)
        {
            return await _context.Vendedor.Include(depart => depart.Departamento).FirstOrDefaultAsync(vend => vend.Id == id);
        }

        /* Sync
        public void Remove(int id)
        {
            var vendedor = _context.Vendedor.Find(id);
            _context.Remove(vendedor);
            _context.SaveChanges();
        }
        */

        // Async
        public async Task RemoveAsync(int id)
        {
            try
            {
                var vendedor = await _context.Vendedor.FindAsync(id);
                _context.Remove(vendedor);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                throw new IntegrityException(e.Message); 
            }
        }

        /* Sync
        public void Update(Vendedor vendedor)
        {
            if (!_context.Vendedor.Any(vend => vend.Id == vendedor.Id))
            {
                throw new NotFoundException("Id não existe!");
            }

            try
            {
                _context.Update(vendedor);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
        */

        //Async
        public async Task UpdateAsync(Vendedor vendedor)
        {
            bool hasAny = await _context.Vendedor.AnyAsync(vend => vend.Id == vendedor.Id);

            if (!hasAny)
            {
                throw new NotFoundException("Id não existe!");
            }

            try
            {
                _context.Update(vendedor);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }



    }
}
