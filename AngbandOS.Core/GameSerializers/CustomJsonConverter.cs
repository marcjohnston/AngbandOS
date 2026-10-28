// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
using System.Text.Json.Serialization;

namespace AngbandOS.Core;

/// <summary>
/// JSON converter for <see cref="GameStateBag"/> polymorphic serialization.
/// </summary>
/// <remarks>
/// This converter encodes the concrete <see cref="GameStateBag"/> type in the JSON payload using
/// the <c>$type</c> property and stores the actual payload in the <c>Value</c> property (or other
/// properties for complex types such as objects or references). The converter supports all
/// concrete <see cref="GameStateBag"/> implementations used by the game state serializer.
/// </remarks>
internal class CustomJsonConverter : JsonConverter<GameStateBag>
{
    const string TypePropertyName = "$type";
    const string ValuePropertyName = "Value";

    /// <summary>
    /// Reads a <see cref="GameStateBag"/> instance from JSON.
    /// </summary>
    /// <param name="reader">The <see cref="Utf8JsonReader"/> positioned at the start of the value to read.</param>
    /// <param name="typeToConvert">The target type to convert to (always <see cref="GameStateBag"/>).</param>
    /// <param name="options">Serializer options that may affect nested deserialization.</param>
    /// <returns>The deserialized <see cref="GameStateBag"/> concrete instance.</returns>
    /// <exception cref="Exception">Thrown when the encoded <c>$type</c> is unknown.</exception>
    public override GameStateBag Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using JsonDocument doc = JsonDocument.ParseValue(ref reader);

        string type = doc.RootElement.GetProperty("$type").GetString()!;

        return type switch
        {
            nameof(BoolValueGameStateBag) => new BoolValueGameStateBag(doc.RootElement.GetProperty(ValuePropertyName).GetBoolean()),
            nameof(ByteArrayGameStateBag) => new ByteArrayGameStateBag(Convert.FromBase64String(doc.RootElement.GetProperty(ValuePropertyName).GetString()!)),
            nameof(ByteValueGameStateBag) => new ByteValueGameStateBag(doc.RootElement.GetProperty(ValuePropertyName).GetByte()),
            nameof(CharArrayGameStateBag) => new CharArrayGameStateBag(doc.RootElement.GetProperty(ValuePropertyName).GetString()!.ToCharArray()),
            nameof(CharValueGameStateBag) => new CharValueGameStateBag(doc.RootElement.GetProperty(ValuePropertyName).GetString()![0]),
            nameof(DateTimeValueGameStateBag) => new DateTimeValueGameStateBag(doc.RootElement.GetProperty(ValuePropertyName).GetDateTime()),
            nameof(DecimalValueGameStateBag) => new DecimalValueGameStateBag(doc.RootElement.GetProperty(ValuePropertyName).GetDecimal()),
            nameof(DictionaryGameStateBag) => new DictionaryGameStateBag(JsonSerializer.Deserialize<Dictionary<string, GameStateBag>>(doc.RootElement.GetProperty(ValuePropertyName).GetRawText(), options)!),
            nameof(IntValueGameStateBag) => new IntValueGameStateBag(doc.RootElement.GetProperty(ValuePropertyName).GetInt32()),
            nameof(ListGameStateBag) => new ListGameStateBag(JsonSerializer.Deserialize<GameStateBag[]>(doc.RootElement.GetProperty(ValuePropertyName).GetRawText(), options)!),
            nameof(NullValueGameStateBag) => new NullValueGameStateBag(),
            nameof(ObjectGameStateBag) => new ObjectGameStateBag(doc.RootElement.GetProperty("ObjectId").GetInt32(), doc.RootElement.GetProperty("TypeName").GetString()!, JsonSerializer.Deserialize<DictionaryGameStateBag>(doc.RootElement.GetProperty(ValuePropertyName).GetRawText(), options)!),
            nameof(ReferenceGameStateBag) => new ReferenceGameStateBag(doc.RootElement.GetProperty("ObjectId").GetInt32()),
            nameof(StringValueGameStateBag) => new StringValueGameStateBag(doc.RootElement.GetProperty(ValuePropertyName).GetString()!),
            nameof(TimeSpanValueGameStateBag) => new TimeSpanValueGameStateBag(TimeSpan.Parse(doc.RootElement.GetProperty(ValuePropertyName).GetString()!)),
            _ => throw new Exception($"Unknown type {type}")
        };
    }

    /// <summary>
    /// Writes the provided <see cref="GameStateBag"/> instance to JSON.
    /// </summary>
    /// <param name="writer">The <see cref="Utf8JsonWriter"/> to which JSON will be written.</param>
    /// <param name="value">The <see cref="GameStateBag"/> instance to serialize.</param>
    /// <param name="options">Serializer options that may affect nested serialization.</param>
    /// <exception cref="Exception">Thrown when <paramref name="value"/> is of an unknown <see cref="GameStateBag"/> subtype.</exception>
    public override void Write(Utf8JsonWriter writer, GameStateBag value, JsonSerializerOptions options)
    {
        writer.WriteStartObject();

        switch (value)
        {
            case BoolValueGameStateBag boolValue:
                writer.WriteString(TypePropertyName, nameof(BoolValueGameStateBag));
                writer.WriteBoolean(ValuePropertyName, boolValue.Value);
                break;

            case ByteArrayGameStateBag byteArrayValue:
                writer.WriteString(TypePropertyName, nameof(ByteArrayGameStateBag));
                writer.WriteString(ValuePropertyName, Convert.ToBase64String(byteArrayValue.Value));
                break;

            case ByteValueGameStateBag byteValue:
                writer.WriteString(TypePropertyName, nameof(ByteValueGameStateBag));
                writer.WriteNumber(ValuePropertyName, byteValue.Value);
                break;

            case CharArrayGameStateBag charArrayValue:
                writer.WriteString(TypePropertyName, nameof(CharArrayGameStateBag));
                writer.WriteString(ValuePropertyName, charArrayValue.Value);
                break;

            case CharValueGameStateBag charValue:
                writer.WriteString(TypePropertyName, nameof(CharValueGameStateBag));
                writer.WriteString(ValuePropertyName, charValue.Value.ToString());
                break;

            case DateTimeValueGameStateBag dateTimeValue:
                writer.WriteString(TypePropertyName, nameof(DateTimeValueGameStateBag));
                writer.WriteString(ValuePropertyName, dateTimeValue.Value);
                break;

            case DecimalValueGameStateBag decimalValue:
                writer.WriteString(TypePropertyName, nameof(DecimalValueGameStateBag));
                writer.WriteNumber(ValuePropertyName, decimalValue.Value);
                break;

            case DictionaryGameStateBag dictionaryValue:
                writer.WriteString(TypePropertyName, nameof(DictionaryGameStateBag));
                writer.WritePropertyName(ValuePropertyName);
                JsonSerializer.Serialize(writer, dictionaryValue.Values, options);
                break;

            case IntValueGameStateBag intValue:
                writer.WriteString(TypePropertyName, nameof(IntValueGameStateBag));
                writer.WriteNumber(ValuePropertyName, intValue.Value);
                break;

            case ListGameStateBag listValue:
                writer.WriteString(TypePropertyName, nameof(ListGameStateBag));
                writer.WritePropertyName(ValuePropertyName);
                JsonSerializer.Serialize(writer, listValue.Values, options);
                break;

            case NullValueGameStateBag:
                writer.WriteString(TypePropertyName, nameof(NullValueGameStateBag));
                break;

            case ObjectGameStateBag objectValue:
                writer.WriteString(TypePropertyName, nameof(ObjectGameStateBag));
                writer.WriteNumber("ObjectId", objectValue.ObjectId);
                writer.WriteString("TypeName", objectValue.TypeName);
                writer.WritePropertyName(ValuePropertyName);
                JsonSerializer.Serialize(writer, objectValue.Values, options);
                break;

            case ReferenceGameStateBag referenceValue:
                writer.WriteString(TypePropertyName, nameof(ReferenceGameStateBag));
                writer.WriteNumber("ObjectId", referenceValue.ObjectId);
                break;

            case StringValueGameStateBag stringValue:
                writer.WriteString(TypePropertyName, nameof(StringValueGameStateBag));
                writer.WriteString(ValuePropertyName, stringValue.Value);
                break;

            case TimeSpanValueGameStateBag timeSpanValue:
                writer.WriteString(TypePropertyName, nameof(TimeSpanValueGameStateBag));
                writer.WriteString(ValuePropertyName, timeSpanValue.Value.ToString());
                break;

            default:
                throw new Exception($"Unknown type {value.GetType()}");
        }

        writer.WriteEndObject();
    }
}