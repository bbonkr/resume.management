
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Resume.Entities;

namespace Resume.Data.EntityTypeConfigurations;

public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .IsRequired()
            .HasConversion<string>()
            .HasMaxLength(36)
            .ValueGeneratedOnAdd();
        builder.Property(x => x.UserId)
            .IsRequired()
            .HasConversion<string>()
            .HasComment("Identity server user identifier");
        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(200);
        builder.Property(x => x.Username)
            .IsRequired()
            .HasMaxLength(200);
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

        builder.HasMany(x => x.Sns)
            .WithOne(x => x.User)
            .HasForeignKey(x => x.UserId);

        builder.HasMany(x => x.Links)
            .WithOne(x => x.User)
            .HasForeignKey(x => x.UserId);

        builder.HasMany(x => x.Files)
            .WithOne(x => x.User)
            .HasForeignKey(x => x.UserId);

        builder.HasMany(x => x.Contents)
            .WithOne(x => x.User)
            .HasForeignKey(x => x.UserId);

        builder.HasMany(x => x.Skills)
            .WithOne(x => x.User)
            .HasForeignKey(x => x.UserId);

        builder.HasMany(x => x.SkillGroups)
            .WithOne(x => x.User)
            .HasForeignKey(x => x.UserId);

        builder.HasMany(x => x.Tags)
            .WithOne(x => x.User)
            .HasForeignKey(x => x.UserId);
    }
}