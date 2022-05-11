using kr.bbon.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Resume.Data.ValueConverters;
using Resume.Entities;

namespace Resume.Data.EntityTypeConfigurations;

public class ContentEntityTypeConfiguration : EntityTypeConfigurationBase<Content>
{
    public override void ConfigureEntity(EntityTypeBuilder<Content> builder)
    {
        builder.Property(x => x.Title)
            .IsRequired()
            .HasMaxLength(400);
        builder.Property(x => x.Subtitle)
            .IsRequired(false)
            .HasMaxLength(400);
        builder.Property(x => x.Period)
            .IsRequired(false)
            .HasMaxLength(100);
        builder.Property(x => x.State)
            .IsRequired(false)
            .HasMaxLength(100);
        builder.Property(x => x.Description)
            .IsRequired(false);
        builder.Property(x => x.Group)
            .IsRequired()
            .HasMaxLength(100)
            .HasConversion<ContentGroupToStringConverter>();
        builder.Property(x => x.Enabled)
            .IsRequired()
            .HasDefaultValue(true);

        builder.HasMany(x => x.Files)
            .WithOne(x => x.Content)
            .HasForeignKey(x => x.ContentId);

        builder.HasMany(x => x.Links)
            .WithOne(x => x.Content)
            .HasForeignKey(x => x.ContentId);
    }
}