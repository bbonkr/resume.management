
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Resume.Data.ValueConverters;
using Resume.Entities;

namespace Resume.Data.EntityTypeConfigurations;

public class UserSnsEntityTypeConfiguration : IEntityTypeConfiguration<UserSns>
{
    public void Configure(EntityTypeBuilder<UserSns> builder)
    {
        builder.HasKey(x => new { x.UserId, x.ServiceName });

        builder.Property(x => x.UserId)
            .IsRequired()
            .HasConversion<string>()
            .HasMaxLength(36);
        builder.Property(x => x.ServiceName)
            .IsRequired()
            .HasConversion<SnsNameToStringConverter>();
        builder.Property(x => x.Username)
            .IsRequired()
            .HasMaxLength(100);
    }
}