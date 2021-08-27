using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Domain.Models
{
    public class Pedido : Entity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Numero { get; set; }

        public DateTime Data { get; set; }
        public decimal Valor { get; set; }
        public double? Desconto { get; set; }
        public decimal ValorTotal { get; set; }

        //Relacionamentos do EF
        public List<Produto> Produtos { get; set; }

        public Guid ProdutoId { get; set; }

        public Cliente Cliente { get; set; }
        public Guid ClienteId { get; set; }

        public void PopularPropriedades()
        {
            Data = DateTime.Now;
            Valor = Produtos.Sum(x => x.Valor);
            ValorTotal = Desconto != null ? Valor * Convert.ToDecimal(Desconto) : Valor;
        }

        public Pedido()
        {
        }
    }
}