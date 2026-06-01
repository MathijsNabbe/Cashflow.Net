using System.Text.Json;
using System.Text.Json.Serialization;

namespace CashflowNet.Shared.Serialization;

public static class CashflowJsonSerializerOptions
{
    public static JsonSerializerOptions Options { get; } = Create();

    public static JsonSerializerOptions Create()
    {
        var options = new JsonSerializerOptions(JsonSerializerDefaults.Web);
        ApplyTo(options);
        return options;
    }

    public static void ApplyTo(JsonSerializerOptions options)
    {
        options.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;

        if (options.Converters.All(converter => converter is not JsonStringEnumConverter))
            options.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
    }
}
