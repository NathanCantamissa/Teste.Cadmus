using Domain.Interfaces.Repository;
using Domain.Models;
using Infra.Data.Context;

namespace Infra.Data.Repositories
{
    public class ClienteRepository : BaseRepository<Cliente>, IClienteRepository
    {
        public ClienteRepository(ContextoEntity db) : base(db)
        {
        }
    }
}