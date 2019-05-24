using System;
using SalesWebMVC.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace SalesWebMVC.Models
{
    public class Vendas
    {
        public int Id { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataVendas { get; set; }

        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double ValorVenda { get; set; }
        public VendasStatus StatusVenda { get; set; }
        public Vendedor vendedor { get; set; }

        public Vendas()
        {           
        }

        public Vendas(int id, DateTime dataVendas, double valorVenda, VendasStatus statusVenda, Vendedor vendedor)
        {
            Id = id;
            DataVendas = dataVendas;
            ValorVenda = valorVenda;
            StatusVenda = statusVenda;
            this.vendedor = vendedor;
        }        
    }
}
