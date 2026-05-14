// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
using System.Text.Json.Serialization;

namespace AngbandOS.Core;

internal interface IGameSerializer
{
    /// <summary>
    /// Serializes the entity into a GameStateBag to be saved.
    /// </summary>
    /// <param name="saveGameState">The current save game state, which can be used to create game state bags for properties of the entity.</param>
    /// <returns>A GameStateBag representing the serialized state of the entity.</returns>
    string Serialize(SaveGameData saveGameData);
    SaveGameData Deserialize(string serializedSaveGameData);
}

internal class JsonGameSerializer : IGameSerializer
{
    public string Serialize(SaveGameData saveGameData)
    {
        var options = new JsonSerializerOptions
        {
            WriteIndented = false
        };

        options.Converters.Add(new GameStateBagConverter());
        return JsonSerializer.Serialize(saveGameData, options);
    }
    public SaveGameData Deserialize(string serializedSaveGameData)
    {
        var options = new JsonSerializerOptions();
        options.Converters.Add(new GameStateBagConverter());
        SaveGameData? saveGameData = JsonSerializer.Deserialize<SaveGameData>(serializedSaveGameData, options);
        if (saveGameData is null)
        {
            throw new Exception("Failed to deserialize game data.");
        }
        return saveGameData;
    }
}

internal class BinaryGameSerializer : IGameSerializer
{
    /// <summary>
    /// Packs a one or more boolean values into bytes in a bit-wise manner.
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public byte[] PackBits(bool a, params bool[] b)
    {
        int totalBits = 1 + b.Length;
        byte[] result = new byte[(totalBits + 7) / 8];

        if (a)
        {
            result[0] |= 1;
        }

        for (int i = 0; i < b.Length; i++)
        {
            if (b[i])
            {
                int bitIndex = i + 1; // because 'a' is bit 0
                result[bitIndex / 8] |= (byte)(1 << (bitIndex % 8));
            }
        }

        return result;
    }

    /// <summary>
    /// Concatenates a byte and one or more byte arrays into a single byte array.  This is often used for serializations that need to inject a byte discriminator.
    /// </summary>
    /// <param name="a"></param>
    /// <param name="bytes"></param>
    /// <returns></returns>
    public byte[] Concatenate(byte a, params byte[][] bytes)
    {
        List<byte> result = new List<byte>();
        result.Add(a);
        foreach (var byteArray in bytes)
        {
            result.AddRange(byteArray);
        }
        return result.ToArray();
    }

    /// <summary>
    /// Concatenates one or more byte arrays into a single byte array.
    /// </summary>
    /// <param name="bytes"></param>
    /// <returns></returns>
    public byte[] Concatenate(params byte[][] bytes)
    {
        List<byte> result = new List<byte>();
        foreach (var byteArray in bytes)
        {
            result.AddRange(byteArray);
        }
        return result.ToArray();
    }
    public byte[] Concatenate(byte[] a, params byte[][] bytes)
    {
        List<byte> result = new List<byte>();
        result.AddRange(a);
        foreach (var byteArray in bytes)
        {
            result.AddRange(byteArray);
        }
        return result.ToArray();
    }

    public byte[] Pack(bool value)
    {
        return new byte[] { value ? (byte)1 : (byte)0 };
    }
    public byte[] Pack(byte value)
    {
        return new byte[] { value };
    }
    public byte[] Pack(char value)
    {
        return BitConverter.GetBytes(value);
    }

    //public bool ObjectIsReferenced(int objectId)
    //{
    //    return ObjectReferenceCountDictionary.ContainsKey(objectId);
    //}

    ///// <summary>
    ///// Returns the object ID for a reference to an existing object, if the object already exists.  If a reference is issued, the reference count for the object is also incremented. 
    ///// </summary>
    ///// <param name="value"></param>
    ///// <param name="id"></param>
    ///// <returns></returns>
    //private bool TryGetReferenceId(object value, out int id)
    //{
    //    if (ObjectToIdDictionary.TryGetValue(value, out id))
    //    {
    //        ObjectReferenceCountDictionary[id] = true;
    //        return true;
    //    }
    //    return false;
    //}

    /// <summary>
    /// Pack an object game state bag which are either references or complete objects.
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    //public byte[] Pack(IGameSerialize value)
    //{
    //    if (TryGetReferenceId(value, out int existingId))
    //    {
    //        // This is a reference.
    //        return Concatenate((byte)11, Pack(existingId));
    //    }

    //    // We need to register this object to the dictionary before we serialize the object to prevent recursion.
    //    int objectId = RegisterObject(value);

    //    DictionaryGameStateBag? gameStateBag = (DictionaryGameStateBag?)value.Serialize(this);

    //    return Concatenate(
    //        (byte)1,
    //        Pack(objectId),
    //        Pack(value.GetType().Name),
    //        Pack(gameStateBag?.Values)
    //    );
    //}

    //public byte[] Pack(GameStateBag gameStateBag)
    //{
    //    string serializedGameStateBag = gameStateBag.Serialize();
    //    return Pack(serializedGameStateBag);
    //}

    ///// <summary>
    ///// Packs an unknown number of byte arrays by packing the length of the array first.
    ///// </summary>
    ///// <param name="data"></param>
    ///// <returns></returns>
    //public byte[] PackList(byte[][] data)
    //{
    //    return Concatenate(Pack(data.Length), data.Select(_bytes => Concatenate(Pack(_bytes.Length), _bytes)).ToArray());
    //}

    //public byte[] Pack(Dictionary<string, GameStateBag>? gameStateBag)
    //{
    //    if (gameStateBag is null)
    //    {
    //        return Pack((byte)0);
    //    }

    //    return Concatenate(Pack((byte)1), Pack(gameStateBag.Count), gameStateBag.SelectMany(_keyValuePair => Concatenate(Pack(_keyValuePair.Key), Pack(_keyValuePair.Value.Serialize()))).ToArray());
    //}

    public byte[] Pack(decimal value)
    {
        int[] bits = decimal.GetBits(value);
        List<byte> bytes = new List<byte>();
        foreach (int bit in bits)
        {
            bytes.AddRange(BitConverter.GetBytes(bit));
        }
        return bytes.ToArray();
    }
    public byte[] Pack(int value)
    {
        return BitConverter.GetBytes(value);
    }
    public byte[] Pack(string value)
    {
        return Concatenate(Pack(value.Length), Convert.FromBase64String(value));
    }

    public string Serialize(SaveGameData saveGameData)
    {
        throw new NotImplementedException();
    }
    public SaveGameData Deserialize(string serializedSaveGameData)
    {
        throw new NotImplementedException();
    }
}

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