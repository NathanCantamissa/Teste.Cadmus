using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.CrossCutting.Dto
{
    public class PedidoDto
    {
        public int Numero { get; set; }

        public DateTime Data { get; set; }
        public decimal Valor { get; set; }
        public double? Desconto { get; set; }
        public decimal ValorTotal { get; set; }
        public List<ProdutoDto> Produtos { get; set; }
        public ClienteDto Cliente { get; set; }
    }
}