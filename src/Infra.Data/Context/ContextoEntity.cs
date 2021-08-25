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
            base.OnModelCreating(modelBuilder);
        }
    }
}