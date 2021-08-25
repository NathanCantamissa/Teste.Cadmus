using Domain.Interfaces.Notification;
using Domain.Interfaces.Service;
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
    }
}