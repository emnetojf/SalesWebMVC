using System;
using System.Collections.Generic;
using System.Linq;


namespace SalesWebMVC.Models
{
    public class Vendedor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime DataNasc { get; set; }
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
