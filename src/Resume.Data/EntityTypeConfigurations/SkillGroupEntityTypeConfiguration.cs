
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Resume.Data.ValueConverters;
using Resume.Entities;

namespace Resume.Data.EntityTypeConfigurations;

public class SkillGroupEntityTypeConfiguration : IEntityTypeConfiguration<SkillGroup>
{
    public void Configure(EntityTypeBuilder<SkillGroup> builder)
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
        builder.Property(x => x.Icon)
            .IsRequired()
            .HasDefaultValue(SkillGroupIcon.Star)
            .HasConversion<SkillGroupIconToStringConverter>();
        builder.Property(x => x.UserId)
            .IsRequired()
            .HasConversion<string>()
            .HasMaxLength(36);

        builder.HasMany(x => x.Skills)
            .WithOne(x => x.Group)
            .HasForeignKey(x => x.SkillGroupId)
            .OnDelete(DeleteBehavior.NoAction);
    }

}