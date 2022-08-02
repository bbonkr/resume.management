using System;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Resume.Entities;

namespace Resume.Data.ValueConverters;

public class SkillGroupIconToStringConverter : ValueConverter<SkillGroupIcon, string>
{
    public SkillGroupIconToStringConverter()
        : base(
            x => x.ToString(),
            x => Enum.Parse<SkillGroupIcon>(x))
    {
    }
}