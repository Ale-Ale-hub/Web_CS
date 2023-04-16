using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;
using Web_C_.Database.Data;

namespace Web_C_.DAL.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<UserDto>
    {
        public void Configure(EntityTypeBuilder<UserDto> builder)
        {

            builder.HasAlternateKey(u => new { u.Email, u.Phone });
            builder.Property(u => u.Phone).HasMaxLength(12).IsRequired();
            builder.Property(u => u.Name).HasMaxLength(20).IsRequired();
            builder.Property(u => u.Password).IsRequired();
            builder.Property(u => u.Salt).IsRequired();
            builder.Property(u => u.Email).HasMaxLength(40).IsRequired();

        }
    }
}
