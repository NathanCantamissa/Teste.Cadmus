using Infra.CrossCutting.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Service
{
    public interface IClienteService
    {
        Task Cadastrar(CadastroClienteDto dados);
    }
}