using System;
using SalesWebMVC.Models.Enums;

namespace SalesWebMVC.Models
{
    public class Vendas
    {
        public int Id { get; set; }
        public DateTime DataVendas { get; set; }
        public double ValorVenda { get; set; }
        public VendasStatus StatusVenda { get; set; }
        public int MyProperty { get; set; }
        public Vendedor vendedor { get; set; }

        public Vendas()
        {           
        }

        public Vendas(int id, DateTime dataVendas, double valorVenda, VendasStatus statusVenda, int myProperty, Vendedor vendedor)
        {
            Id = id;
            DataVendas = dataVendas;
            ValorVenda = valorVenda;
            StatusVenda = statusVenda;
            MyProperty = myProperty;
            this.vendedor = vendedor;
        }
    }
}
