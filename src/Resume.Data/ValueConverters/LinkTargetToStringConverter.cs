using System;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Resume.Entities;

namespace Resume.Data.ValueConverters;

public class LinkTargetToStringConverter : ValueConverter<LinkTarget, string>
{
    public LinkTargetToStringConverter()
        : base(
            x => x.ToString(),
            x => Enum.Parse<LinkTarget>(x))
    {
    }
}