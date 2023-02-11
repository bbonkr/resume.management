using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Resume.Entities;

namespace Resume.Data.EntityTypeConfigurations;

public class ContentMediaEntityTypeConfiguration : MediaEntityTypeConfigurationBase<ContentMedia>
{
    protected override void ConfigureSpecific(EntityTypeBuilder<ContentMedia> builder)
    {
        builder.Property(x => x.ContentId)
            .IsRequired()
            .HasConversion<string>()
            .HasMaxLength(36);

        builder.ToTable("ContentMedias");
    }
}