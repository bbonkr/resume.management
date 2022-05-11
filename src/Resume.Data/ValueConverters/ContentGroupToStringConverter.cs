using System;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Resume.Entities;

namespace Resume.Data.ValueConverters;

public class ContentGroupToStringConverter : ValueConverter<ContentGroup, string>
{
    public ContentGroupToStringConverter()
        : base(
            x => x.ToString(),
            x => (ContentGroup) Enum.Parse(typeof(ContentGroup), x))
    {
    }
}