using kr.bbon.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Resume.Data.ValueConverters;
using Resume.Entities;

namespace Resume.Data.EntityTypeConfigurations;

public class SkillGroupEntityTypeConfiguration : EntityTypeConfigurationBase<SkillGroup>
{
    public override void ConfigureEntity(EntityTypeBuilder<SkillGroup> builder)
    {
        builder.Property(x => x.Title)
            .IsRequired()
            .HasMaxLength(1000);
        builder.Property(x => x.Icon)
            .IsRequired()
            .HasDefaultValue(SkillGroupIcon.Star)
            .HasConversion<SkillGroupIconToStringConverter>();
        builder.Property(x => x.UserId)
            .IsRequired()
            .HasConversion<string>();

        builder.HasMany(x => x.Skills)
            .WithOne(x => x.Group)
            .HasForeignKey(x => x.SkillGroupId);
    }
}