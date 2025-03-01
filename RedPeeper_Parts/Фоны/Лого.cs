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