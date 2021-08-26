using Domain.Interfaces.Notification;
using Domain.Interfaces.Service;
using Infra.CrossCutting.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : MainController
    {
        private readonly IProdutoService _produtoService;

        public ProdutosController(INotificador notificador,
             IProdutoService produtoService) : base(notificador)
        {
            _produtoService = produtoService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm] CadastroProdutoDto dados, IFormFile foto)
        {
            await _produtoService.Cadastrar(dados, foto);
            return CustomResponse();
        }
    }
}