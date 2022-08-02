using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Resume.Entities;

namespace Resume.Data.EntityTypeConfigurations;

public class UserMediaEntityTypeConfiguration : MediaEntityTypeConfigurationBase<UserMedia>
{
    protected override void ConfigureSpecific(EntityTypeBuilder<UserMedia> builder)
    {
        
    }
}