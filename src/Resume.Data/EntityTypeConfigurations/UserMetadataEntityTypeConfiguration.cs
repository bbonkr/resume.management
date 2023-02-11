
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Resume.Entities;

namespace Resume.Data.EntityTypeConfigurations;

public class UserMetadataEntityTypeConfiguration : IEntityTypeConfiguration<UserMetadata>
{
    public void Configure(EntityTypeBuilder<UserMetadata> builder)
    {
        builder.HasKey(x => x.UserId);

        builder.Property(x => x.UserId)
            .IsRequired()
            .HasConversion<string>()
            .HasMaxLength(36);

        builder.Property(x => x.SiteTitle)
            .IsRequired()
            .HasMaxLength(200);
        builder.Property(x => x.SiteTitleEn)
            .IsRequired(false)
            .HasMaxLength(400);
        builder.Property(x => x.NameEn)
            .IsRequired(false)
            .HasMaxLength(400);
        builder.Property(x => x.Url)
            .IsRequired()
            .HasMaxLength(400);
        builder.Property(x => x.Title)
            .IsRequired()
            .HasMaxLength(200);
        builder.Property(x => x.Subtitle)
            .HasMaxLength(200);
        builder.Property(x => x.Intro);
        builder.Property(x => x.Bio);

        builder.ToTable("UserMetadatas");

    }
}