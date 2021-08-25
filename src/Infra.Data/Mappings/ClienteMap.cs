using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.Mappings
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Clientes");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome).HasColumnType("varchar(100)").IsRequired();

            builder.Property(x => x.Email).HasColumnType("varchar(100)").IsRequired();
            builder.HasIndex(u => u.Email).IsUnique();

            builder.Property(x => x.Aldeia).HasColumnType("varchar(100)").IsRequired();
        }
    }
}