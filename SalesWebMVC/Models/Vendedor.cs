using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;


namespace SalesWebMVC.Models
{
    public class Vendedor
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Data Nasc")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataNasc { get; set; }

        [Display(Name = "Salário Base")]
        [DisplayFormat(DataFormatString = "{0:F2}" )]
        public double SalarioBase { get; set; }
        public Departamento Departamento { get; set; }
        public int DepartamentoId { get; set; }
        public ICollection<Vendas> Vendas { get; set; } = new List<Vendas>();

        public Vendedor()
        {
        }


        public Vendedor(int id, string nome, string email, DateTime dataNasc, double salarioBase, Departamento departamento)
        {
            Id = id;
            Nome = nome;
            Email = email;
            DataNasc = dataNasc;
            SalarioBase = salarioBase;
            this.Departamento = departamento;
        }

        public void AdicionaVendedor(Vendas vendas)
        {
            Vendas.Add(vendas);
        }

        public void RemoveVendedor(Vendas vendas)
        {
            Vendas.Remove(vendas);
        }
        public double TotalVendas(DateTime dtInicial, DateTime dtFinal)
        {
            return Vendas.Where(Vendas => Vendas.DataVendas >= dtInicial && Vendas.DataVendas <= dtInicial).Sum(Vendas => Vendas.ValorVenda);
        }

    }
}
