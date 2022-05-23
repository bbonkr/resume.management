using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Resume.Entities;

namespace Resume.Data.EntityTypeConfigurations;

public class UserLinkEntityTypeConfiguration : LinkEntityTypeConfigurationBase<UserLink>
{
    protected override void ConfigureSpecific(EntityTypeBuilder<UserLink> builder)
    {

    }
}