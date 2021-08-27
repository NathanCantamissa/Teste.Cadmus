using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.CrossCutting.Dto
{
    public class ClienteDto
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Aldeia { get; set; }

        //Relacionamentos do EF
        public List<PedidoDto> Pedidos { get; set; }
    }
}