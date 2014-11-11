using System;

namespace WhiteLabel.Data
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ExcludeFromAzureTableAttribute : Attribute
    {
    }
}
