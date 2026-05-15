// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AngbandOS.Core;

internal class BinaryGameSerializer : IGameSerializer
{
    public byte[] Serialize(GameStateBag gameStateData)
    {
        List<byte> result = new List<byte>();
        switch (gameStateData)
        {
            case BoolValueGameStateBag boolValueGameStateBag:
                result.Add(0);
                result.Add(boolValueGameStateBag.Value ? (byte)1 : (byte)0);
                break;
            case ByteArrayGameStateBag byteArrayGameStateBag:
                result.Add(1);
                result.AddRange(BitConverter.GetBytes(byteArrayGameStateBag.Value.Length));
                result.AddRange(byteArrayGameStateBag.Value);
                break;
            case ByteValueGameStateBag byteValueGameStateBag:
                result.Add(2);
                result.Add(byteValueGameStateBag.Value);
                break;
            case CharArrayGameStateBag charArrayGameStateBag:
                result.Add(3);
                result.AddRange(BitConverter.GetBytes(charArrayGameStateBag.Value.Length));
                foreach (char c in charArrayGameStateBag.Value)
                {
                    result.AddRange(BitConverter.GetBytes(c));
                }
                break;
            case CharValueGameStateBag charValueGameStateBag:
                result.Add(4);
                result.AddRange(BitConverter.GetBytes(charValueGameStateBag.Value));
                break;
            case DateTimeValueGameStateBag dateTimeValueGameStateBag:
                result.Add(5);
                result.AddRange(BitConverter.GetBytes(dateTimeValueGameStateBag.Value.Ticks));
                break;
            case DecimalValueGameStateBag decimalValueGameStateBag:
                result.Add(6);
                int[] bits = decimal.GetBits(decimalValueGameStateBag.Value);
                foreach (int bit in bits)
                {
                    result.AddRange(BitConverter.GetBytes(bit));
                }
                break;
            case DictionaryGameStateBag dictionaryGameStateBag:
                result.Add(7);
                result.AddRange(BitConverter.GetBytes(dictionaryGameStateBag.Values.Count));
                foreach (var keyValuePair in dictionaryGameStateBag.Values)
                {
                    byte[] keyBytes = System.Text.Encoding.UTF8.GetBytes(keyValuePair.Key);
                    result.AddRange(BitConverter.GetBytes(keyBytes.Length));
                    result.AddRange(keyBytes);
                    result.AddRange(Serialize(keyValuePair.Value));
                }
                break;
            case IntValueGameStateBag intValueGameStateBag:
                result.Add(8);
                result.AddRange(BitConverter.GetBytes(intValueGameStateBag.Value));
                break;
            case ListGameStateBag listGameStateBag:
                result.Add(9);
                result.AddRange(BitConverter.GetBytes(listGameStateBag.Values.Length));
                foreach (var item in listGameStateBag.Values)
                {
                    result.AddRange(Serialize(item));
                }
                break;
            case NullValueGameStateBag:
                result.Add(10);
                break;
            case ObjectGameStateBag objectGameStateBag:
                result.Add(11);
                result.AddRange(BitConverter.GetBytes(objectGameStateBag.ObjectId));
                byte[] typeNameBytes = System.Text.Encoding.UTF8.GetBytes(objectGameStateBag.TypeName);
                result.AddRange(BitConverter.GetBytes(typeNameBytes.Length));
                result.AddRange(typeNameBytes);
                if (objectGameStateBag.Values is null)
                {
                    result.Add(0);
                }
                else
                {
                    result.Add(1);
                    result.AddRange(Serialize(objectGameStateBag.Values));
                }
                break;
            case ReferenceGameStateBag referenceGameStateBag:
                result.Add(12);
                result.AddRange(BitConverter.GetBytes(referenceGameStateBag.ObjectId));
                break;
            case StringValueGameStateBag stringValueGameStateBag:
                result.Add(13);
                byte[] stringBytes = System.Text.Encoding.UTF8.GetBytes(stringValueGameStateBag.Value);
                result.AddRange(BitConverter.GetBytes(stringBytes.Length));
                result.AddRange(stringBytes);
                break;
            case TimeSpanValueGameStateBag timeSpanValueGameStateBag:
                result.Add(14);
                result.AddRange(BitConverter.GetBytes(timeSpanValueGameStateBag.Value.Ticks));
                break;
            default:
                throw new Exception($"Unsupported game state bag type {gameStateData.GetType()}");
        }
        return result.ToArray();
    }
    public byte[] Serialize(SaveGameData saveGameData)
    {
        return Serialize(saveGameData.Game);
    }

    private GameStateBag Deserialize(ref int index, byte[] data)
    {
        byte type = data[index++];
        switch (type)
        {
            case 0:
                bool boolValue = data[index++] == 1;
                return new BoolValueGameStateBag(boolValue);
            case 1:
                int byteArrayLength = BitConverter.ToInt32(data, index);
                index += 4;
                byte[] byteArrayValue = new byte[byteArrayLength];
                Array.Copy(data, index, byteArrayValue, 0, byteArrayLength);
                index += byteArrayLength;
                return new ByteArrayGameStateBag(byteArrayValue);
            case 2:
                byte byteValue = data[index++];
                return new ByteValueGameStateBag(byteValue);
            case 3:
                int charArrayLength = BitConverter.ToInt32(data, index);
                index += 4;
                char[] charArrayValue = new char[charArrayLength];
                for (int i = 0; i < charArrayLength; i++)
                {
                    charArrayValue[i] = BitConverter.ToChar(data, index);
                    index += 2;
                }
                return new CharArrayGameStateBag(charArrayValue);
            case 4:
                char charValue = BitConverter.ToChar(data, index);
                index += 2;
                return new CharValueGameStateBag(charValue);
            case 5:
                long dateTimeTicks = BitConverter.ToInt64(data, index);
                index += 8;
                return new DateTimeValueGameStateBag(new DateTime(dateTimeTicks));
            case 6:
                int[] decimalBits = new int[4];
                for (int i = 0; i < 4; i++)
                {
                    decimalBits[i] = BitConverter.ToInt32(data, index);
                    index += 4;
                }
                return new DecimalValueGameStateBag(new decimal(decimalBits));
            case 7:
                int dictionaryCount = BitConverter.ToInt32(data, index);
                index += 4;
                Dictionary<string, GameStateBag> dictionaryValue = new Dictionary<string, GameStateBag>();
                for (int i = 0; i < dictionaryCount; i++)
                {
                    int keyLength = BitConverter.ToInt32(data, index);
                    index += 4;
                    string key = System.Text.Encoding.UTF8.GetString(data, index, keyLength);
                    index += keyLength;
                    GameStateBag value = Deserialize(ref index, data);
                    dictionaryValue[key] = value;
                }
                return new DictionaryGameStateBag(dictionaryValue);
            case 8:
                int intValue = BitConverter.ToInt32(data, index);
                index += 4;
                return new IntValueGameStateBag(intValue);
            case 9:
                int listCount = BitConverter.ToInt32(data, index);
                index += 4;
                GameStateBag[] listValue = new GameStateBag[listCount];
                for (int i = 0; i < listCount; i++)
                {
                    listValue[i] = Deserialize(ref index, data);
                }
                return new ListGameStateBag(listValue);
            case 10:
                return new NullValueGameStateBag();
            case 11:
                int objectId = BitConverter.ToInt32(data, index);
                index += 4;
                int typeNameLength = BitConverter.ToInt32(data, index);
                index += 4;
                string typeName = System.Text.Encoding.UTF8.GetString(data, index, typeNameLength);
                index += typeNameLength;
                if (data[index++] == 0)
                {
                    return new ObjectGameStateBag(objectId, typeName, null);
                }
                else
                {
                    GameStateBag values = Deserialize(ref index, data);
                    return new ObjectGameStateBag(objectId, typeName, (DictionaryGameStateBag)values);
                }
            case 12:
                int referenceObjectId = BitConverter.ToInt32(data, index);
                index += 4;
                return new ReferenceGameStateBag(referenceObjectId);
            case 13:
                int stringLength = BitConverter.ToInt32(data, index);
                index += 4;
                string stringValue = System.Text.Encoding.UTF8.GetString(data, index, stringLength);
                index += stringLength;
                return new StringValueGameStateBag(stringValue);
            case 14:
                long timeSpanTicks = BitConverter.ToInt64(data, index);
                index += 8;
                return new TimeSpanValueGameStateBag(new TimeSpan(timeSpanTicks));
            default:
                throw new Exception($"Unsupported game state bag type {type}");
        }
    }
    public SaveGameData Deserialize(byte[] serializedSaveGameData)
    {
        int index = 0;
        GameStateBag gameStateBag = Deserialize(ref index, serializedSaveGameData);
        return new SaveGameData(gameStateBag, false);
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