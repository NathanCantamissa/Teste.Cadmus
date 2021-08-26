using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.CrossCutting.Dto
{
    public class CadastroPedidoDto
    {
        public decimal Valor { get; set; }
        public double? Desconto { get; set; }
        public List<Guid> ProdutoId { get; set; }
        public Guid ClienteId { get; set; }
    }
}