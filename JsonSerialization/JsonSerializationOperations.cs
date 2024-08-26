using System.Text.Json;
using System.Text.Json.Serialization;

[assembly: CLSCompliant(true)]

namespace JsonSerialization;

public static class JsonSerializationOperations
{
    public static string SerializeObjectToJson(object obj)
    {
        if (obj == null)
        {
            throw new ArgumentNullException(nameof(obj), "argument cannot be null");
        }

        return JsonSerializer.Serialize(obj);
    }

    public static T? DeserializeJsonToObject<T>(string json)
    {
        if (json == null)
        {
            throw new ArgumentNullException(nameof(json), "argument cannot be null");
        }

        return JsonSerializer.Deserialize<T>(json);
    }

    public static string SerializeCompanyObjectToJson(object obj)
    {
        if (obj == null)
        {
            throw new InvalidOperationException("argument cannot be null");
        }

        return JsonSerializer.Serialize(obj);
    }

    public static T? DeserializeCompanyJsonToObject<T>(string json)
    {
        if (json == null)
        {
            throw new InvalidOperationException("argument cannot be null");
        }

        return JsonSerializer.Deserialize<T>(json);
    }

    public static string SerializeDictionary(Company obj)
    {
        if (obj == null)
        {
            throw new InvalidOperationException("argument cannot be null");
        }

        var options = new JsonSerializerOptions
        {
            DictionaryKeyPolicy = JsonNamingPolicy.CamelCase,
        };

        var dictionary = obj.Domains;
        return JsonSerializer.Serialize(dictionary, options);
    }

    public static string SerializeEnum(Company obj)
    {
        if (obj == null)
        {
            throw new InvalidOperationException("argument cannot be null");
        }

        var options = new JsonSerializerOptions
        {
            Converters = { new JsonStringEnumConverter(new LowercaseNamingPolicy()) },
        };

        return JsonSerializer.Serialize(obj, options);
    }
}
