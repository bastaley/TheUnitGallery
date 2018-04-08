using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheUnitGallery.Models
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum OrderStatus
    {
        Open = 1,
        Invoiced = 2,
        Paid = 3,
        Cancelled = 4
    }
}