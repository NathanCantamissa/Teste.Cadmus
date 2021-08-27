using Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repository
{
    public interface IProdutoRepository : IBaseRepository<Produto>
    {
        Task<List<Produto>> BuscarProdutosPorIds(List<Guid> ids);
    }
}