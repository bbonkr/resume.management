using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Resume.Entities;

namespace Resume.Data.EntityTypeConfigurations;

public class ContentLinkEntityTypeConfiguration : LinkEntityTypeConfigurationBase<ContentLink>
{
    protected override void ConfigureSpecific(EntityTypeBuilder<ContentLink> builder)
    {
        builder.Property(x => x.ContentId)
            .IsRequired()
            .HasConversion<string>()
            .HasMaxLength(36);
    }
}