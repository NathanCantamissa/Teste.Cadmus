using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public class Produto : Entity
    {
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public string Foto { get; set; }
        public List<Pedido> Pedidos { get; set; }

        public Produto()
        {
        }
    }
}