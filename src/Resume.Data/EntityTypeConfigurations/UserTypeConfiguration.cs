using kr.bbon.Data;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Options;
using Resume.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Data.EntityTypeConfigurations
{
    public class UserTypeConfiguration : EntityTypeConfiguration<User>
    {
        public UserTypeConfiguration(IOptionsMonitor<DatabaseOptions> databaseOptionsAccessor) : base(databaseOptionsAccessor)
        {
        }

        public override void ConfigureEntity(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.UserName)
                .IsRequired()
                .HasMaxLength(100)
                ;
        }
    }
}
