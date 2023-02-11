using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Resume.Entities;

namespace Resume.Data.EntityTypeConfigurations;

public class ContentGrpoupEntityTypeConfiguration : IEntityTypeConfiguration<ContentGroup>
{
    public void Configure(EntityTypeBuilder<ContentGroup> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .IsRequired()
            .HasConversion<string>()
            .HasMaxLength(36)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Title)
            .IsRequired()
            .HasMaxLength(1000);
        builder.Property(x => x.UserId)
            .IsRequired()
            .HasConversion<string>()
            .HasMaxLength(36);

        builder.HasOne(x => x.User)
            .WithMany(x => x.ContentGroups)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.ToTable("ContentGroups");
    }
}