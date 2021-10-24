using kr.bbon.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Options;
using Resume.Data.Entities;

namespace Resume.Data.EntityTypeConfigurations
{
    public class HomeTypeConfiguration : EntityTypeConfiguration<Home>
    {
        public HomeTypeConfiguration(IOptionsMonitor<DatabaseOptions> databaseOptionsAccessor) : base(databaseOptionsAccessor)
        {
        }

        public override void ConfigureEntity(EntityTypeBuilder<Home> builder)
        {
            builder.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(1000)
                ;
            builder.Property(x => x.Subtitle)
                .IsRequired(false)
                .HasMaxLength(1000)
                ;
            builder.Property(x => x.Intro)
                .IsRequired(false)
                ;
            builder.Property(x => x.Bio)
                .IsRequired()
                ;
            builder.Property(x => x.UserId)
                .IsRequired()
                ;

            builder.HasOne(x => x.User)
                .WithOne(x => x.Home)
                .HasForeignKey<Home>(x => x.UserId)
                ;
        }
    }

    public class HomeLinkTypeConfiguration : EntityTypeConfiguration<HomeLink>
    {
        public HomeLinkTypeConfiguration(IOptionsMonitor<DatabaseOptions> databaseOptionsAccessor) : base(databaseOptionsAccessor)
        {
        }

        public override void ConfigureEntity(EntityTypeBuilder<HomeLink> builder)
        {
            builder.Property(x => x.HomeId)
                .IsRequired()
                ;
            builder.Property(x => x.LinkId)
                .IsRequired()
                ;

            builder.HasOne(x => x.Home)
                .WithMany(x => x.HomeLinks)
                .HasForeignKey(x => x.HomeId)
                ;

            builder.HasOne(x => x.Link)
                .WithMany()
                .HasForeignKey(x => x.LinkId);
        }
    }
}
