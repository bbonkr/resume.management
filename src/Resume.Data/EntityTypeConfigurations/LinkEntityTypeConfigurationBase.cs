
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Resume.Data.ValueConverters;
using Resume.Entities;

namespace Resume.Data.EntityTypeConfigurations;

public abstract class LinkEntityTypeConfigurationBase<TLinkEntity> : IEntityTypeConfiguration<TLinkEntity>
    where TLinkEntity : Link
{
    protected abstract void ConfigureSpecific(EntityTypeBuilder<TLinkEntity> builder);

    public void Configure(EntityTypeBuilder<TLinkEntity> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .IsRequired()
            .HasConversion<string>()
            .HasMaxLength(36)
            .ValueGeneratedOnAdd();

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
        builder.Property(x => x.IsHidden)
            .IsRequired()
            .HasDefaultValue(false);
        builder.Property(x => x.UserId)
            .IsRequired()
            .HasConversion<string>()
            .HasMaxLength(36);

        ConfigureSpecific(builder);
    }
}