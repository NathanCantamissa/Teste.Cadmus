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
    public class ClientesController : MainController
    {
        private readonly IClienteService _clienteService;

        public ClientesController(INotificador notificador
            , IClienteService clienteService) : base(notificador)
        {
            _clienteService = clienteService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CadastroClienteDto dados)
        {
            _clienteService.Cadastrar(dados);
            return CustomResponse();
        }
    }
}