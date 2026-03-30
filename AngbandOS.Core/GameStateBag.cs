// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
using System.Collections;
using System.Reflection;
using System.Runtime.CompilerServices;
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
            nameof(NullValueGameStateBag) => new NullValueGameStateBag(),
            nameof(DateTimeValueGameStateBag) => new DateTimeValueGameStateBag(doc.RootElement.GetProperty(ValuePropertyName).GetDateTime()),
            nameof(TimeSpanValueGameStateBag) => new TimeSpanValueGameStateBag(TimeSpan.Parse(doc.RootElement.GetProperty(ValuePropertyName).GetString()!)),
            nameof(StringValueGameStateBag) => new StringValueGameStateBag(doc.RootElement.GetProperty(ValuePropertyName).GetString()!),
            nameof(DecimalValueGameStateBag) => new DecimalValueGameStateBag(doc.RootElement.GetProperty(ValuePropertyName).GetDecimal()),
            nameof(IntValueGameStateBag) => new IntValueGameStateBag(doc.RootElement.GetProperty(ValuePropertyName).GetInt32()),
            nameof(BoolValueGameStateBag) => new BoolValueGameStateBag(doc.RootElement.GetProperty(ValuePropertyName).GetBoolean()),
            nameof(CharValueGameStateBag) => new CharValueGameStateBag(doc.RootElement.GetProperty(ValuePropertyName).GetString()![0]),
            nameof(ByteValueGameStateBag) => new ByteValueGameStateBag(doc.RootElement.GetProperty(ValuePropertyName).GetByte()),
            nameof(ColorEnumValueGameStateBag) => new ColorEnumValueGameStateBag((ColorEnum)Enum.Parse(typeof(ColorEnum), doc.RootElement.GetProperty(ValuePropertyName).GetString()!)),
            nameof(ReferenceGameStateBag) => new ReferenceGameStateBag(doc.RootElement.GetProperty("ObjectId").GetInt32()),
            nameof(DictionaryGameStateBag) => new DictionaryGameStateBag(JsonSerializer.Deserialize<Dictionary<string, GameStateBag>>(doc.RootElement.GetProperty(ValuePropertyName).GetRawText(), options)!),
            nameof(ObjectGameStateBag) => new ObjectGameStateBag(doc.RootElement.GetProperty("ObjectId").GetInt32(), doc.RootElement.GetProperty("DataType").GetString()!, JsonSerializer.Deserialize<GameStateBag>(doc.RootElement.GetProperty("GameStateBag").GetRawText(), options)!),
            nameof(TupleGameStateBag) => new TupleGameStateBag(doc.RootElement.GetProperty("DataType").GetString()!, JsonSerializer.Deserialize<GameStateBag[]>(doc.RootElement.GetProperty("Values").GetRawText(), options)!),
            nameof(ListGameStateBag) => new ListGameStateBag(JsonSerializer.Deserialize<GameStateBag[]>(doc.RootElement.GetProperty("Values").GetRawText(), options)!),
            _ => throw new Exception($"Unknown type {type}")
        };
    }

    public override void Write(Utf8JsonWriter writer, GameStateBag value, JsonSerializerOptions options)
    {
        writer.WriteStartObject();

        switch (value)
        {
            case NullValueGameStateBag:
                writer.WriteString(TypePropertyName, nameof(NullValueGameStateBag));
                break;

            case DateTimeValueGameStateBag dateTimeValue:
                writer.WriteString(TypePropertyName, nameof(DateTimeValueGameStateBag));
                writer.WriteString(ValuePropertyName, dateTimeValue.Value);
                break;

            case TimeSpanValueGameStateBag timeSpanValue:
                writer.WriteString(TypePropertyName, nameof(TimeSpanValueGameStateBag));
                writer.WriteString(ValuePropertyName, timeSpanValue.Value.ToString());
                break;

            case StringValueGameStateBag stringValue:
                writer.WriteString(TypePropertyName, nameof(StringValueGameStateBag));
                writer.WriteString(ValuePropertyName, stringValue.Value);
                break;

            case DecimalValueGameStateBag decimalValue:
                writer.WriteString(TypePropertyName, nameof(DecimalValueGameStateBag));
                writer.WriteNumber(ValuePropertyName, decimalValue.Value);
                break;

            case IntValueGameStateBag intValue:
                writer.WriteString(TypePropertyName, nameof(IntValueGameStateBag));
                writer.WriteNumber(ValuePropertyName, intValue.Value);
                break;

            case BoolValueGameStateBag boolValue:
                writer.WriteString(TypePropertyName, nameof(BoolValueGameStateBag));
                writer.WriteBoolean(ValuePropertyName, boolValue.Value);
                break;

            case CharValueGameStateBag charValue:
                writer.WriteString(TypePropertyName, nameof(CharValueGameStateBag));
                writer.WriteString(ValuePropertyName, charValue.Value.ToString());
                break;

            case ByteValueGameStateBag byteValue:
                writer.WriteString(TypePropertyName, nameof(ByteValueGameStateBag));
                writer.WriteNumber(ValuePropertyName, byteValue.Value);
                break;

            case ColorEnumValueGameStateBag colorEnumValue:
                writer.WriteString(TypePropertyName, nameof(ColorEnumValueGameStateBag));
                writer.WriteString(ValuePropertyName, colorEnumValue.Value.ToString());
                break;

            case ReferenceGameStateBag referenceValue:
                writer.WriteString(TypePropertyName, nameof(ReferenceGameStateBag));
                writer.WriteNumber("ObjectId", referenceValue.ObjectId);
                break;

            case DictionaryGameStateBag dictionaryValue:
                writer.WriteString(TypePropertyName, nameof(DictionaryGameStateBag));
                writer.WritePropertyName(ValuePropertyName);
                JsonSerializer.Serialize(writer, dictionaryValue.Value, options);
                break;

            case ObjectGameStateBag objectValue:
                writer.WriteString(TypePropertyName, nameof(ObjectGameStateBag));
                writer.WriteNumber("ObjectId", objectValue.ObjectId);
                writer.WriteString("DataType", objectValue.DataType);
                writer.WritePropertyName("GameStateBag");
                JsonSerializer.Serialize(writer, objectValue.GameStateBag, options);
                break;

            case TupleGameStateBag tupleValue:
                writer.WriteString(TypePropertyName, nameof(TupleGameStateBag));
                writer.WriteString("DataType", tupleValue.DataType);
                writer.WritePropertyName("Values");
                JsonSerializer.Serialize(writer, tupleValue.Values, options);
                break;

            case ListGameStateBag listValue:
                writer.WriteString(TypePropertyName, nameof(ListGameStateBag));
                writer.WritePropertyName("Values");
                JsonSerializer.Serialize(writer, listValue.Values, options);
                break;

            default:
                throw new Exception($"Unknown type {value.GetType()}");
        }

        writer.WriteEndObject();
    }
}

//[JsonPolymorphic(TypeDiscriminatorPropertyName = "$type")]
//[JsonDerivedType(typeof(IntValueGameStateBag), "int")]
//[JsonDerivedType(typeof(StringValueGameStateBag), "string")]
//[JsonDerivedType(typeof(DictionaryGameStateBag), "dict")]
//[JsonDerivedType(typeof(ObjectGameStateBag), "object")]
//[JsonDerivedType(typeof(ListGameStateBag), "list")]
//[JsonDerivedType(typeof(TupleGameStateBag), "tuple")]
internal class GameStateBag
{
    public void Deserialize(object entity)
    {
        //IEnumerable<FieldInfo> serializableFields = entity.GetType().GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance).Where(p => !System.Attribute.IsDefined(p, typeof(NonSerializedAttribute)));

        //foreach (FieldInfo fieldInfo in serializableFields)
        //{
        //    if (DataDictionary.TryGetValue(fieldInfo.Name, out object? value))
        //    {
        //        fieldInfo.SetValue(entity, value);
        //    }
        //    else
        //    {
        //        throw new Exception("Invalid game state.");
        //    }
        //}
    }
}

internal class NullValueGameStateBag : GameStateBag
{
    public NullValueGameStateBag() { }
    public override string ToString()
    {
        return "null";
    }
}

internal class DateTimeValueGameStateBag : GameStateBag
{
    public DateTime Value { get; }
    public DateTimeValueGameStateBag(DateTime value)
    {
        Value = value;
    }
    public override string ToString()
    {
        return $"{Value}";
    }
}

internal class TimeSpanValueGameStateBag : GameStateBag
{
    public TimeSpan Value { get; }
    public TimeSpanValueGameStateBag(TimeSpan value)
    {
        Value = value;
    }
}

internal class StringValueGameStateBag : GameStateBag
{
    public string Value { get; }
    public StringValueGameStateBag(string value)
    {
        Value = value;
    }
    public override string ToString()
    {
        return $"{Value}";
    }
}

internal class DecimalValueGameStateBag : GameStateBag
{
    public decimal Value { get; }
    public DecimalValueGameStateBag(decimal value)
    {
        Value = value;
    }
    public override string ToString()
    {
        return $"{Value}";
    }
}

internal class IntValueGameStateBag : GameStateBag
{
    public int Value { get; }
    public IntValueGameStateBag(int value)
    {
        Value = value;
    }
    public override string ToString()
    {
        return $"{Value}";
    }
}

internal class BoolValueGameStateBag : GameStateBag
{
    public bool Value { get; }
    public BoolValueGameStateBag(bool value)
    {
        Value = value;
    }

    public override string ToString()
    {
        return $"{Value}";
    }
}

internal class CharValueGameStateBag : GameStateBag
{
    public char Value { get; }
    public CharValueGameStateBag(char value)
    {
        Value = value;
    }
}

internal class ByteValueGameStateBag : GameStateBag
{
    public byte Value { get; }
    public  ByteValueGameStateBag(byte value)
    {
        Value = value;
    }
}

internal class ColorEnumValueGameStateBag : GameStateBag
{
    public ColorEnum Value { get; }
    public ColorEnumValueGameStateBag(ColorEnum value)
    {
        Value = value;
    }
    public override string ToString()
    {
        return $"{Value}";
    }
}

internal class ReferenceGameStateBag : GameStateBag
{
    public int ObjectId { get; }
    public ReferenceGameStateBag(int objectId)
    {
        ObjectId = objectId;
    }
    public override string ToString()
    {
        return $"=>{ObjectId}";
    }
}

internal class DictionaryGameStateBag : GameStateBag
{
    public Dictionary<string, GameStateBag> Value { get; }
    public DictionaryGameStateBag(Dictionary<string, GameStateBag> value)
    {
        Value = value;
    }
}

internal class ObjectGameStateBag : GameStateBag
{
    public int ObjectId { get; }
    public string DataType { get; }
    public GameStateBag GameStateBag { get; }
    public ObjectGameStateBag(int objectId, string dataTypeName, GameStateBag value)
    {
        ObjectId = objectId;
        DataType = dataTypeName;
        GameStateBag = value;
    }
    public override string ToString()
    {
        return $"{DataType} Object#{ObjectId}";
    }
}

internal class TupleGameStateBag : GameStateBag
{
    public string DataType { get; }
    public GameStateBag[] Values {get;}
    public TupleGameStateBag(string dataType, GameStateBag[] values)
    {
        DataType = dataType;
        Values = values;
    }
}

internal class ListGameStateBag : GameStateBag
{
    public GameStateBag[] Values { get; }
    public ListGameStateBag(GameStateBag[] values)
    {
        Values = values;
    }
}