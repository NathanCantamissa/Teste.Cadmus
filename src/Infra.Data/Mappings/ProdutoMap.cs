using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Mappings
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produtos");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Descricao).HasColumnType("varchar(100)").IsRequired();
            builder.Property(x => x.Valor).HasColumnType("decimal").IsRequired();
            builder.Property(x => x.Foto).HasColumnType("varchar(100)").IsRequired();
        }
    }
}