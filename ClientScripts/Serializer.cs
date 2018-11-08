using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace ClientScripts
{
    public static class Serializer
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            //DefaultValueHandling = DefaultValueHandling.Ignore,
            Converters = { new StringEnumConverter() },
            ContractResolver = new LowercaseContractResolver(),
            //NullValueHandling = NullValueHandling.Ignore,
            Formatting = Formatting.Indented,
            ReferenceLoopHandling = ReferenceLoopHandling.Serialize
        };
        
        public static string ToString(object o)
        {
            return JsonConvert.SerializeObject(o, Settings);
        }

        public static T ToObject<T>(string str)
        {
            return JsonConvert.DeserializeObject<T>(str, Settings);
        }
    }

    public sealed class LowercaseContractResolver : DefaultContractResolver
    {
        protected override string ResolvePropertyName(string propertyName)
        {
            return propertyName.ToLower();
        }
    }
}
