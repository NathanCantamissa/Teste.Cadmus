using Domain.Models;
using Infra.CrossCutting.Dto;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Service
{
    public interface IProdutoService
    {
        Task Cadastrar(CadastroProdutoDto dados, IFormFile foto);

        Task<List<ProdutoDto>> BuscarProdutosPorId(List<Guid> ids);
    }
}