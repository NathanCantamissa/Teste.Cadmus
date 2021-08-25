using Domain.Interfaces.Repository;
using Domain.Models;
using Infra.Data.Context;

namespace Infra.Data.Repositories
{
    public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(ContextoEntity db) : base(db)
        {
        }
    }
}