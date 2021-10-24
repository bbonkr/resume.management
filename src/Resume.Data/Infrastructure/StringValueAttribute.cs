using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Resume.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Data
{
    public class StringValueAttribute : Attribute
    {
        public StringValueAttribute(string stringValue)
        {
            StringValue = stringValue;
        }

        public string StringValue { get; }
    }
}
