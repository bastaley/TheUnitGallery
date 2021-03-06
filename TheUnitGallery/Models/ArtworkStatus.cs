﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheUnitGallery.Models
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ArtworkStatus
    {
        Preperation = 1,
        ForSale = 2,
        Reserved = 3,
        Sold = 4
    }
}