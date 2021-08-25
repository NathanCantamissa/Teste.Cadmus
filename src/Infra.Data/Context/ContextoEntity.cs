using Domain.Models;
using Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Context
{
    public class ContextoEntity : DbContext
    {
        public ContextoEntity(DbContextOptions<ContextoEntity> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProdutoMap());
            modelBuilder.ApplyConfiguration(new ClienteMap());
            modelBuilder.ApplyConfiguration(new PedidoMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}