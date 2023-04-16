using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;
using Web_C_.Database.Data;

namespace Web_C_.DAL.Configuration
{
    internal class ProductConfiguration : IEntityTypeConfiguration<ProductDto>
    {
        public void Configure(EntityTypeBuilder<ProductDto> builder)
        {
            builder.HasAlternateKey(u => new { u.Price, u.Name, u.Amount });
            builder.Property(u => u.Price).IsRequired();
            builder.Property(u => u.Name).IsRequired();
            builder.Property(u => u.Amount).IsRequired();
        }
    }
}
