using Cadastro.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cadastro.Infrastructure.Data.EntityConfig
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {

            builder.Property(m => m.Nome)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(m => m.Produto)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(m => m.Preco)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
