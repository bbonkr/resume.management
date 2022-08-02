using kr.bbon.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Resume.Entities;

namespace Resume.Data.EntityTypeConfigurations;

public class SkillEntityTypeConfiguration : EntityTypeConfigurationBase<Skill>
{
    public override void ConfigureEntity(EntityTypeBuilder<Skill> builder)
    {
        builder.Property(x => x.Title)
            .IsRequired()
            .HasMaxLength(1000);
        
        builder.Property(x => x.Description)
            .IsRequired(false)
            .HasMaxLength(4000);
        
        builder.Property(x => x.Score)
            .IsRequired()
            .HasDefaultValue(0);
        
        builder.Property(x => x.ScoreMax)
            .IsRequired()
            .HasDefaultValue(100);
        
        builder.Property(x => x.SkillGroupId)
            .IsRequired()
            .HasConversion<string>();
        
        builder.Property(x => x.UserId)
            .IsRequired()
            .HasConversion<string>();
    }
}