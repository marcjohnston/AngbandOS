// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
using System.Text;
using System.Text.Json.Serialization;

namespace AngbandOS.Core;
    
internal class GameStateBagConverter : JsonConverter<GameStateBag>
{
    const string TypePropertyName = "$type";
    const string ValuePropertyName = "Value";

    public override GameStateBag Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using JsonDocument doc = JsonDocument.ParseValue(ref reader);

        string type = doc.RootElement.GetProperty("$type").GetString()!;

        return type switch
        {
            nameof(BoolValueGameStateBag) => new BoolValueGameStateBag(doc.RootElement.GetProperty(ValuePropertyName).GetBoolean()),
            nameof(ByteArrayGameStateBag) => new ByteArrayGameStateBag(Encoding.UTF8.GetBytes(doc.RootElement.GetProperty(ValuePropertyName).GetString()!)),
            nameof(ByteValueGameStateBag) => new ByteValueGameStateBag(doc.RootElement.GetProperty(ValuePropertyName).GetByte()),
            nameof(CharArrayGameStateBag) => new CharArrayGameStateBag(doc.RootElement.GetProperty(ValuePropertyName).GetString()!.ToCharArray()),
            nameof(CharValueGameStateBag) => new CharValueGameStateBag(doc.RootElement.GetProperty(ValuePropertyName).GetString()![0]),
            //nameof(EnumValueGameStateBag) => new EnumValueGameStateBag((ColorEnum)Enum.Parse(typeof(ColorEnum), doc.RootElement.GetProperty(ValuePropertyName).GetString()!)),
            nameof(DateTimeValueGameStateBag) => new DateTimeValueGameStateBag(doc.RootElement.GetProperty(ValuePropertyName).GetDateTime()),
            nameof(DecimalValueGameStateBag) => new DecimalValueGameStateBag(doc.RootElement.GetProperty(ValuePropertyName).GetDecimal()),
            nameof(DictionaryGameStateBag) => new DictionaryGameStateBag(JsonSerializer.Deserialize<Dictionary<string, GameStateBag>>(doc.RootElement.GetProperty(ValuePropertyName).GetRawText(), options)!),
            nameof(IntValueGameStateBag) => new IntValueGameStateBag(doc.RootElement.GetProperty(ValuePropertyName).GetInt32()),
            nameof(ListGameStateBag) => new ListGameStateBag(JsonSerializer.Deserialize<GameStateBag[]>(doc.RootElement.GetProperty("Values").GetRawText(), options)!),
            nameof(NullValueGameStateBag) => new NullValueGameStateBag(),
            nameof(ObjectGameStateBag) => new ObjectGameStateBag(doc.RootElement.GetProperty("ObjectId").GetInt32(), doc.RootElement.GetProperty("TypeName").GetString()!, JsonSerializer.Deserialize<Dictionary<string, GameStateBag>>(doc.RootElement.GetProperty("Values").GetRawText(), options)!),
            nameof(QueueOfStringGameStateBag) => new QueueOfStringGameStateBag(JsonSerializer.Deserialize<string[]>(doc.RootElement.GetProperty("Values").GetRawText(), options)!),
            nameof(ReferenceGameStateBag) => new ReferenceGameStateBag(doc.RootElement.GetProperty("ObjectId").GetInt32()),
            nameof(StringValueGameStateBag) => new StringValueGameStateBag(doc.RootElement.GetProperty(ValuePropertyName).GetString()!),
            nameof(TimeSpanValueGameStateBag) => new TimeSpanValueGameStateBag(TimeSpan.Parse(doc.RootElement.GetProperty(ValuePropertyName).GetString()!)),
            nameof(TupleGameStateBag) => new TupleGameStateBag(doc.RootElement.GetProperty("DataType").GetString()!, JsonSerializer.Deserialize<GameStateBag[]>(doc.RootElement.GetProperty("Values").GetRawText(), options)!),
            _ => throw new Exception($"Unknown type {type}")
        };
    }

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
                writer.WriteString(ValuePropertyName, byteArrayValue.Value);
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

            //case EnumValueGameStateBag enumValue:
            //    writer.WriteString(TypePropertyName, nameof(EnumValueGameStateBag));
            //    writer.WriteString(ValuePropertyName, enumValue.Value.ToString());
            //    break;

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
                writer.WritePropertyName("Values");
                JsonSerializer.Serialize(writer, listValue.Values, options);
                break;

            case NullValueGameStateBag:
                writer.WriteString(TypePropertyName, nameof(NullValueGameStateBag));
                break;

            case ObjectGameStateBag objectValue:
                writer.WriteString(TypePropertyName, nameof(ObjectGameStateBag));
                writer.WriteNumber("ObjectId", objectValue.ObjectId);
                writer.WriteString("TypeName", objectValue.TypeName);
                writer.WritePropertyName("Values");
                JsonSerializer.Serialize(writer, objectValue.Values, options);
                break;

            case QueueOfStringGameStateBag queueOfStringValue:
                writer.WriteString(TypePropertyName, nameof(QueueOfStringGameStateBag));
                writer.WritePropertyName("Values");
                JsonSerializer.Serialize(writer, queueOfStringValue.Values, options);
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

            case TupleGameStateBag tupleValue:
                writer.WriteString(TypePropertyName, nameof(TupleGameStateBag));
                writer.WriteString("DataType", tupleValue.DataType);
                writer.WritePropertyName("Values");
                JsonSerializer.Serialize(writer, tupleValue.Values, options);
                break;

            default:
                throw new Exception($"Unknown type {value.GetType()}");
        }

        writer.WriteEndObject();
    }
}