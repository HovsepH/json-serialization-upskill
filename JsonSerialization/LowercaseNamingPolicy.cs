using System.Text.Json;

namespace JsonSerialization;

public class LowercaseNamingPolicy : JsonNamingPolicy
{
    public override string ConvertName(string name)
    {
        return CamelCase.ConvertName(name);
    }
}
