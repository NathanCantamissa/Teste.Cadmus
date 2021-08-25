using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public class Cliente : Entity
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Aldeia { get; set; }

        //Relacionamentos do EF
        public List<Pedido> Pedidos { get; set; }

        public Cliente()
        {
        }
    }
}