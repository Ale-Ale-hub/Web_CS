using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Web_C_.DAL.Model;

namespace Web_C_.DAL.Configuration
{
    public class SessionConfiguration : IEntityTypeConfiguration<SessionDto>
    {
        public void Configure(EntityTypeBuilder<SessionDto> builder)
        {
            builder.Property(u => u.Created).IsRequired();
            builder.Property(u => u.LastAccessed).IsRequired();
            builder.HasKey(u => u.DbSessionId);

        }
    }
}
