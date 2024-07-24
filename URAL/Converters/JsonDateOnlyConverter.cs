using System.Globalization;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace URAL.Application.Converters;

public class JsonDateOnlyConverter : JsonConverter<DateOnly>
{
    private const string dateFormat = "yyyy MM dd";

    public override DateOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return DateOnly.ParseExact(reader.GetString()!, dateFormat);
    }

    // This is the serializer
    public override void Write(Utf8JsonWriter writer, DateOnly value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString(dateFormat, CultureInfo.InvariantCulture));
    }
}
