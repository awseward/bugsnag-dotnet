﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bugsnag.NET.Request
{
    [JsonObject(MemberSerialization.OptIn)]
    interface IUser
    {
        [JsonProperty("id")]
        object Id { get; }

        [JsonProperty("name")]
        string Name { get; }

        [JsonProperty("email")]
        string Email { get; }
    }
}
