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
    public class PedidosController : MainController
    {
        private readonly IPedidoService _pedidoService;

        public PedidosController(INotificador notificador,
            IPedidoService pedidoService) : base(notificador)
        {
            _pedidoService = pedidoService;
        }

        [HttpPost]
        public async Task<IActionResult> Post()
        {
            return CustomResponse();
        }
    }
}