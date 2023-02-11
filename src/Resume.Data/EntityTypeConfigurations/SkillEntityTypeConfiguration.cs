
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Resume.Entities;

namespace Resume.Data.EntityTypeConfigurations;

public class SkillEntityTypeConfiguration : IEntityTypeConfiguration<Skill>
{
    public void Configure(EntityTypeBuilder<Skill> builder)
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
            .HasConversion<string>()
            .HasMaxLength(36);

        builder.Property(x => x.UserId)
            .IsRequired()
            .HasConversion<string>()
            .HasMaxLength(36);

        builder.ToTable("Skills");
    }
}