using Domain.Interfaces.Repository;
using Domain.Models;
using Infra.Data.Context;

namespace Infra.Data.Repositories
{
    public class PedidoRepository : BaseRepository<Pedido>, IPedidoRepository
    {
        public PedidoRepository(ContextoEntity db) : base(db)
        {
        }
    }
}