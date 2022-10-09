using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Resume.Data.ValueConverters;
using Resume.Entities;

namespace Resume.Data.EntityTypeConfigurations;

public class ContentEntityTypeConfiguration : IEntityTypeConfiguration<Content>
{
    public void Configure(EntityTypeBuilder<Content> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .IsRequired()
            .HasConversion<string>()
            .HasMaxLength(36)
            .ValueGeneratedOnAdd();

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

        builder.HasMany(x => x.Tags)
            .WithMany(x => x.Contents)
            .UsingEntity<ContentTag>(
                j => j.HasOne(x => x.Tag)
                    .WithMany(x => x.ContentTags)
                    .HasForeignKey(x => x.TagId),
                j => j.HasOne(x => x.Content)
                    .WithMany(x => x.ContentTags)
                    .HasForeignKey(x => x.ContentId),
                j => j.HasKey(x => new
                {
                    x.ContentId,
                    x.TagId
                }));
    }
}