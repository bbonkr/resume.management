using kr.bbon.Data;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Options;
using Resume.Data.Entities;
using System.Linq.Expressions;

namespace Resume.Data.EntityTypeConfigurations
{
    public class AttachmentTypeConfiguration : EntityTypeConfiguration<Attachment>
    {
        public AttachmentTypeConfiguration(IOptionsMonitor<DatabaseOptions> databaseOptionsAccessor) : base(databaseOptionsAccessor)
        {
        }

        public override void ConfigureEntity(EntityTypeBuilder<Attachment> builder)
        {
            builder.Property(x => x.Title).IsRequired()
                .HasMaxLength(1000)
                ;
            builder.Property(x => x.Url).IsRequired()
                .HasMaxLength(1000)
                ;
            builder.Property(x => x.Mimetype).IsRequired()
                .HasMaxLength(100)
                ;

            builder.Property(x => x.Size).IsRequired();
            

            builder.Property(x => x.UserId).IsRequired();
         
            builder.HasOne(x => x.User)
                .WithMany(x => x.Attachments)
                .HasForeignKey(x => x.UserId);
        }
    }
}
