using kr.bbon.Data;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Resume.Entities;

namespace Resume.Data.EntityTypeConfigurations;

public class TagEntityTypeConfiguration : EntityTypeConfigurationBase<Tag>
{
    public override void ConfigureEntity(EntityTypeBuilder<Tag> builder)
    {
        builder.Property(x => x.Title)
            .IsRequired()
            .HasMaxLength(1000);
        builder.Property(x => x.UserId)
            .IsRequired()
            .HasConversion<string>();
    }
}