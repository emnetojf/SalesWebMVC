using System;
using System.Collections.Generic;
using System.Linq;


namespace SalesWebMVC.Models
{
    public class Departamento
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public ICollection<Vendedor> Vendedors { get; set; } = new List<Vendedor>();

        public Departamento()
        {
        }
        public Departamento(int id, string nome)
        {
            Id = id;
            Nome = nome;           
        }

        public void AdicionaVendas(Vendedor vendedor)
        {
            Vendedors.Add(vendedor);
        }

        public double TotalVendas(DateTime dtInicial, DateTime dtFinal)
        {
            return Vendedors.Sum(Vendedor => Vendedor.TotalVendas(dtInicial, dtFinal));
        }
    }
}
