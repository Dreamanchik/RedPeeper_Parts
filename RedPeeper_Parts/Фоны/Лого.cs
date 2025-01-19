using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nautilus.Handlers;
using Newtonsoft.Json;

namespace RedPeeper_Parts
{
    public interface IJsonFile
    {
        [JsonIgnore]
        JsonConverter[] AlwaysIncludedJsonConverters { get; }
        string JsonFilePath { get; }


    };
}