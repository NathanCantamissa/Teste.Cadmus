using System.ComponentModel.DataAnnotations;

namespace Infra.CrossCutting.Dto
{
    public class CadastroProdutoDto
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public decimal Valor { get; set; }
    }
}