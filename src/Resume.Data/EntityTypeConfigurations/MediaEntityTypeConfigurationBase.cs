using kr.bbon.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Resume.Entities;

namespace Resume.Data.EntityTypeConfigurations;

public abstract class MediaEntityTypeConfigurationBase<TMediaEntity> : EntityTypeConfigurationBase<TMediaEntity>
    where TMediaEntity : Media
{
    protected abstract void ConfigureSpecific(EntityTypeBuilder<TMediaEntity> builder);

    public override void ConfigureEntity(EntityTypeBuilder<TMediaEntity> builder)
    {
        builder.Property(x => x.Uri)
            .IsRequired()
            .HasMaxLength(1000);
        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(1000);
        builder.Property(x => x.ContentType)
            .IsRequired()
            .HasDefaultValue("application/octet-stream")
            .HasMaxLength(100);
        builder.Property(x => x.UserId)
            .IsRequired()
            .HasConversion<string>();
        
        ConfigureSpecific(builder);
    }
}