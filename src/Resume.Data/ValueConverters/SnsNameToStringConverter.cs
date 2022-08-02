using System;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Resume.Entities;

namespace Resume.Data.ValueConverters;

public class SnsNameToStringConverter : ValueConverter<SnsName, string>
{
    public SnsNameToStringConverter()
        : base(
            x => x.ToString(),
            x => Enum.Parse<SnsName>(x))
    {

    }
}