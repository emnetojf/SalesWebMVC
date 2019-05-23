using System;
using System.Linq;
using SalesWebMVC.Models;
using SalesWebMVC.Models.Enums;

namespace SalesWebMVC.Data
{
    public class SeedingService
    {
        private SalesWebMVCContext _context;

        public SeedingService(SalesWebMVCContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Departamento.Any() ||
                _context.Vendedor.Any() ||
                _context.Vendas.Any())
            {
                return; // BD já populado
            }

            Departamento depart1 = new Departamento(1, "Computadores");
            Departamento depart2 = new Departamento(2, "Eletrônicos");
            Departamento depart3 = new Departamento(3, "Fashion");
            Departamento depart4 = new Departamento(4, "Livros");

            Vendedor vend1= new Vendedor(1, "Bob", "bob@gmail.com", new DateTime(1998, 4, 21), 1000.0, depart1);
            Vendedor vend2 = new Vendedor(2,"Maria", "maria@gmail.com", new DateTime(1979, 12, 21), 3500.0, depart2);
            Vendedor vend3 = new Vendedor(3, "Alex", "alex@gmail.com", new DateTime(1988, 1, 21), 2200.0, depart1);
            Vendedor vend4 = new Vendedor(4, "Martha", "martha@gmail.com", new DateTime(1993, 11, 21), 3000.0, depart4);
            Vendedor vend5 = new Vendedor(5, "Donald", "donald@gmail.com", new DateTime(2000, 1, 21), 4000.0, depart3);
            Vendedor vend6 = new Vendedor(6, "Alex1", "alex1@gmail.com", new DateTime(1997, 3, 21), 3000.0, depart2);


            Vendas vendas1 = new Vendas(1, new DateTime(2018, 09, 25), 11000.0, VendasStatus.faturado,vend1);
            Vendas vendas2 = new Vendas(2, new DateTime(2018, 09, 4), 7000.0, VendasStatus.faturado,vend5);
            Vendas vendas3 = new Vendas(3, new DateTime(2018, 09, 13), 4000.0, VendasStatus.cancelado,vend4);
            Vendas vendas4 = new Vendas(4, new DateTime(2018, 09, 1), 8000.0, VendasStatus.faturado,vend1);
            Vendas vendas5 = new Vendas(5, new DateTime(2018, 09, 21), 3000.0, VendasStatus.faturado,vend3);
            Vendas vendas6 = new Vendas(6, new DateTime(2018, 09, 15), 2000.0, VendasStatus.faturado,vend1);
            Vendas vendas7 = new Vendas(7, new DateTime(2018, 09, 28), 13000.0, VendasStatus.faturado,vend2);
            Vendas vendas8 = new Vendas(8, new DateTime(2018, 09, 11), 4000.0, VendasStatus.faturado,vend4);
            Vendas vendas9 = new Vendas(9, new DateTime(2018, 09, 14), 11000.0, VendasStatus.pendente,vend6);
            Vendas vendas10 = new Vendas(10, new DateTime(2018, 09, 7), 9000.0, VendasStatus.faturado,vend6);
            Vendas vendas11 = new Vendas(11, new DateTime(2018, 09, 13), 6000.0, VendasStatus.faturado,vend2);
            Vendas vendas12 = new Vendas(12, new DateTime(2018, 09, 25), 7000.0, VendasStatus.pendente,vend3);
            Vendas vendas13 = new Vendas(13, new DateTime(2018, 09, 29), 10000.0, VendasStatus.faturado,vend4);
            Vendas vendas14 = new Vendas(14, new DateTime(2018, 09, 4), 3000.0, VendasStatus.faturado,vend5);
            Vendas vendas15 = new Vendas(15, new DateTime(2018, 09, 12), 4000.0, VendasStatus.faturado,vend1);
            Vendas vendas16 = new Vendas(16, new DateTime(2018, 10, 5), 2000.0, VendasStatus.faturado,vend4);
            Vendas vendas17 = new Vendas(17, new DateTime(2018, 10, 1), 12000.0, VendasStatus.faturado,vend1);
            Vendas vendas18 = new Vendas(18, new DateTime(2018, 10, 24), 6000.0, VendasStatus.faturado,vend3);
            Vendas vendas19 = new Vendas(19, new DateTime(2018, 10, 22), 8000.0, VendasStatus.faturado,vend5);
            Vendas vendas20 = new Vendas(20, new DateTime(2018, 10, 15), 8000.0, VendasStatus.faturado,vend6);
            Vendas vendas21 = new Vendas(21, new DateTime(2018, 10, 17), 9000.0, VendasStatus.faturado,vend2);
            Vendas vendas22 = new Vendas(22, new DateTime(2018, 10, 24), 4000.0, VendasStatus.faturado,vend4);
            Vendas vendas23 = new Vendas(23, new DateTime(2018, 10, 19), 11000.0, VendasStatus.cancelado,vend2);
            Vendas vendas24 = new Vendas(24, new DateTime(2018, 10, 12), 8000.0, VendasStatus.faturado,vend5);
            Vendas vendas25 = new Vendas(25, new DateTime(2018, 10, 31), 7000.0, VendasStatus.faturado,vend3);
            Vendas vendas26 = new Vendas(26, new DateTime(2018, 10, 6), 5000.0, VendasStatus.faturado,vend4);
            Vendas vendas27 = new Vendas(27, new DateTime(2018, 10, 13), 9000.0, VendasStatus.pendente,vend1);
            Vendas vendas28 = new Vendas(28, new DateTime(2018, 10, 7), 4000.0, VendasStatus.faturado,vend3);
            Vendas vendas29 = new Vendas(29, new DateTime(2018, 10, 23), 12000.0, VendasStatus.faturado,vend5);
            Vendas vendas30 = new Vendas(30, new DateTime(2018, 10, 12), 5000.0, VendasStatus.faturado,vend2);

            _context.Departamento.AddRange(depart1, depart2, depart3, depart4);

            _context.Vendedor.AddRange(vend1, vend2, vend3, vend4, vend5, vend6);

            _context.Vendas.AddRange(
                vendas1, vendas2, vendas3, vendas4, vendas5, vendas6, vendas7, vendas8, vendas9, vendas10,
                vendas11, vendas12, vendas13, vendas14, vendas15, vendas16, vendas17, vendas18, vendas19, vendas20,
                vendas21, vendas22, vendas23, vendas24, vendas25, vendas26, vendas27, vendas28, vendas29, vendas30
            );

            _context.SaveChanges();
        }
    }
}
