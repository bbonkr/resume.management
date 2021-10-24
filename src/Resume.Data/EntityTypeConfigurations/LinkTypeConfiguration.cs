using kr.bbon.Data;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Options;
using Resume.Data.Entities;
using System;

namespace Resume.Data.EntityTypeConfigurations
{
    public class LinkTypeConfiguration : EntityTypeConfiguration<Link>
    {
        public LinkTypeConfiguration(IOptionsMonitor<DatabaseOptions> databaseOptionsAccessor) : base(databaseOptionsAccessor)
        {
        }

        public override void ConfigureEntity(EntityTypeBuilder<Link> builder)
        {
            builder.Property(x => x.Title).IsRequired()
                .HasMaxLength(1000)
                ;
            builder.Property(x => x.Href).IsRequired()
                .HasMaxLength(1000)
                ;
            builder.Property(x => x.Icon)
                .IsRequired(false)
                .HasConversion<string>(x => x.ToString(), x => Enum.Parse<LinkIcon>(x))
                ;
            builder.Property(x => x.Target)
                .IsRequired(false)
                .HasConversion<string>(x => x.ToString(), x => Enum.Parse<LinkTarget>(x))
                ;
        }
    }
}
