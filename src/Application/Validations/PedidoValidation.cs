using Domain.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validations
{
    public class PedidoValidation : AbstractValidator<Pedido>
    {
        public PedidoValidation()
        {
        }
    }
}