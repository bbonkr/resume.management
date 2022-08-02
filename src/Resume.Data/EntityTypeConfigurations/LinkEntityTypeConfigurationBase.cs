using kr.bbon.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Resume.Data.ValueConverters;
using Resume.Entities;

namespace Resume.Data.EntityTypeConfigurations;

public abstract class LinkEntityTypeConfigurationBase<TLinkEntity> : EntityTypeConfigurationBase<TLinkEntity> 
    where TLinkEntity : Link
{
    protected abstract void ConfigureSpecific(EntityTypeBuilder<TLinkEntity> builder);
    
    public override void ConfigureEntity(EntityTypeBuilder<TLinkEntity> builder)
    {
        builder.Property(x => x.Href)
            .IsRequired()
            .HasMaxLength(1000);
        builder.Property(x => x.Icon)
            .IsRequired()
            .HasDefaultValue(LinkIcon.None)
            .HasConversion<LinkIconToStringConverter>();
        builder.Property(x => x.Target)
            .IsRequired()
            .HasDefaultValue(LinkTarget.Self)
            .HasConversion<LinkTargetToStringConverter>();
        builder.Property(x => x.Title)
            .IsRequired()
            .HasMaxLength(1000);
        builder.Property(x => x.Enabled)
            .IsRequired()
            .HasDefaultValue(true);
        builder.Property(x => x.UserId)
            .IsRequired()
            .HasConversion<string>();
        
        ConfigureSpecific(builder);
    }
}