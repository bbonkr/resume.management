using System;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Resume.Entities;

namespace Resume.Data.ValueConverters;

public class LinkIconToStringConverter : ValueConverter<LinkIcon, string>
{
    public LinkIconToStringConverter()
        : base(
            x => x.ToString(),
            x => Enum.Parse<LinkIcon>(x))
    {
    }
}

