using System;

namespace Domain.Models
{
    public class Produto : Entity
    {
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public string Foto { get; set; }

        public Pedido Pedido { get; set; }
        public Guid PedidoId { get; set; }

        public Produto()
        {
        }
    }
}