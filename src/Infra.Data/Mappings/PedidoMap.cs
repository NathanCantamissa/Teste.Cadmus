using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Mappings
{
    public class PedidoMap : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.ToTable("Pedidos");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Numero).HasColumnType("int").IsRequired();
            builder.Property(x => x.Valor).HasColumnType("decimal(100,2)").IsRequired();
            builder.Property(x => x.Data).HasColumnType("datetime").IsRequired();
            builder.Property(x => x.Desconto).HasColumnType("double");
            builder.Property(x => x.ValorTotal).HasColumnType("decimal(100,2)").IsRequired();

            builder.HasOne(x => x.Cliente).WithMany(x => x.Pedidos).HasForeignKey(x => x.ClienteId);
            builder.HasMany(x => x.Produtos).WithOne(x => x.Pedido).HasForeignKey(x => x.PedidoId);
        }
    }
}