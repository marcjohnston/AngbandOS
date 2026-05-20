// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
using System.IO.Compression;

namespace AngbandOS.Core;

internal class BinaryGameSerializer : IGameSerializer
{
    private enum TypeEnum
    {
        BooleanFalseValue = 0,
        BooleanTrueValue = 1,
        ByteArray = 2,
        ByteValue = 3,
        CharArray = 4,
        CharValue = 5,
        DateTimeValue = 6,
        DecimalValue = 7,
        DictionaryWithSequentialRetrieval = 8,
        DictionaryWithNonSequentialRetrieval = 9,
        IntegerValue = 10,
        List = 11,
        NullValue = 12,
        ObjectWithState = 13,
        ObjectWithoutState = 14,
        ReferenceToObject = 15,
        StringValue = 16,
        TimeSpanValue = 17
    }
    //List<string> u = new List<string>();
    private static byte[] Serialize(GameStateBag gameStateData)
    {
        List<byte> result = new List<byte>();

        void Add(TypeEnum typeEnum)
        {
            result.Add((byte)typeEnum);
        }

        void AddString(string value)
        {
            byte[] keyBytes = System.Text.Encoding.UTF8.GetBytes(value);
            result.AddRange(BitConverter.GetBytes(keyBytes.Length));
            result.AddRange(keyBytes);
        }

        void AddTypeName(string value)
        {
            AddString(value);
            //if (!u.Contains(value))
            //{
            //    u.Add(value);
            //    Debug.Print(value);
            //}
        }

        switch (gameStateData)
        {
            case BoolValueGameStateBag boolValueGameStateBag:
                if (boolValueGameStateBag.Value)
                {
                    Add(TypeEnum.BooleanTrueValue);
                }
                else
                {
                    Add(TypeEnum.BooleanFalseValue);
                }
                break;
            case ByteArrayGameStateBag byteArrayGameStateBag:
                Add(TypeEnum.ByteArray);
                result.AddRange(BitConverter.GetBytes(byteArrayGameStateBag.Value.Length));
                result.AddRange(byteArrayGameStateBag.Value);
                break;
            case ByteValueGameStateBag byteValueGameStateBag:
                Add(TypeEnum.ByteValue);
                result.Add(byteValueGameStateBag.Value);
                break;
            case CharArrayGameStateBag charArrayGameStateBag:
                Add(TypeEnum.CharArray);
                result.AddRange(BitConverter.GetBytes(charArrayGameStateBag.Value.Length));
                foreach (char c in charArrayGameStateBag.Value)
                {
                    result.AddRange(BitConverter.GetBytes(c));
                }
                break;
            case CharValueGameStateBag charValueGameStateBag:
                Add(TypeEnum.CharValue);
                result.AddRange(BitConverter.GetBytes(charValueGameStateBag.Value));
                break;
            case DateTimeValueGameStateBag dateTimeValueGameStateBag:
                Add(TypeEnum.DateTimeValue);
                result.AddRange(BitConverter.GetBytes(dateTimeValueGameStateBag.Value.Ticks));
                break;
            case DecimalValueGameStateBag decimalValueGameStateBag:
                Add(TypeEnum.DecimalValue);
                int[] bits = decimal.GetBits(decimalValueGameStateBag.Value);
                foreach (int bit in bits)
                {
                    result.AddRange(BitConverter.GetBytes(bit));
                }
                break;
            case DictionaryGameStateBag dictionaryGameStateBag:
                Add(dictionaryGameStateBag.SequentialRetrieval ? TypeEnum.DictionaryWithSequentialRetrieval : TypeEnum.DictionaryWithNonSequentialRetrieval);
                result.AddRange(BitConverter.GetBytes(dictionaryGameStateBag.Values.Count));
                foreach (var keyValuePair in dictionaryGameStateBag.Values)
                {
                    if (!dictionaryGameStateBag.SequentialRetrieval)
                    {
                        AddTypeName(keyValuePair.Key);
                    }
                    result.AddRange(Serialize(keyValuePair.Value));
                }
                break;
            case IntValueGameStateBag intValueGameStateBag:
                Add(TypeEnum.IntegerValue);
                result.AddRange(BitConverter.GetBytes(intValueGameStateBag.Value));
                break;
            case ListGameStateBag listGameStateBag:
                Add(TypeEnum.List);
                result.AddRange(BitConverter.GetBytes(listGameStateBag.Values.Length));
                foreach (var item in listGameStateBag.Values)
                {
                    result.AddRange(Serialize(item));
                }
                break;
            case NullValueGameStateBag:
                Add(TypeEnum.NullValue);
                break;
            case ObjectGameStateBag objectGameStateBag:
                if (objectGameStateBag.Values is null)
                {
                    Add(TypeEnum.ObjectWithoutState);
                }
                else
                {
                    Add(TypeEnum.ObjectWithState);
                    result.AddRange(Serialize(objectGameStateBag.Values));
                }
                result.AddRange(BitConverter.GetBytes(objectGameStateBag.ObjectId));
                AddTypeName(objectGameStateBag.TypeName);
                break;
            case ReferenceGameStateBag referenceGameStateBag:
                Add(TypeEnum.ReferenceToObject);
                result.AddRange(BitConverter.GetBytes(referenceGameStateBag.ObjectId));
                break;
            case StringValueGameStateBag stringValueGameStateBag:
                Add(TypeEnum.StringValue);
                AddString(stringValueGameStateBag.Value);
                break;
            case TimeSpanValueGameStateBag timeSpanValueGameStateBag:
                Add(TypeEnum.TimeSpanValue);
                result.AddRange(BitConverter.GetBytes(timeSpanValueGameStateBag.Value.Ticks));
                break;
            default:
                throw new Exception($"Unsupported game state bag type {gameStateData.GetType()}");
        }
        return result.ToArray();
    }
    public byte[] Serialize(SaveGameData saveGameData)
    {
        byte[] unzippedSerializedData = Serialize(saveGameData.Game);
        byte[] zippedSerializedData = Zip(unzippedSerializedData);
        return zippedSerializedData;
    }
    private static byte[] Zip(byte[] data)
    {
        using MemoryStream output = new MemoryStream();

        using (GZipStream gzip = new GZipStream(output, CompressionLevel.Optimal))
        {
            gzip.Write(data, 0, data.Length);
        }

        return output.ToArray();
    }
    private static byte[] Unzip(byte[] compressedData)
    {
        using MemoryStream input = new MemoryStream(compressedData);
        using GZipStream gzip = new GZipStream(input, CompressionMode.Decompress);
        using MemoryStream output = new MemoryStream();

        gzip.CopyTo(output);

        return output.ToArray();
    }

    private static GameStateBag Deserialize(ref int index, byte[] data)
    {
        string GetString(ref int index)
        {
            int stringLength = BitConverter.ToInt32(data, index);
            index += 4;
            string value = System.Text.Encoding.UTF8.GetString(data, index, stringLength);
            index += stringLength;
            return value;
        }

        byte type = data[index++];
        switch (type)
        {
            case (byte)TypeEnum.BooleanFalseValue:
                return new BoolValueGameStateBag(false);
            case (byte)TypeEnum.BooleanTrueValue:
                return new BoolValueGameStateBag(true);
            case (byte)TypeEnum.ByteArray:
                int byteArrayLength = BitConverter.ToInt32(data, index);
                index += 4;
                byte[] byteArrayValue = new byte[byteArrayLength];
                Array.Copy(data, index, byteArrayValue, 0, byteArrayLength);
                index += byteArrayLength;
                return new ByteArrayGameStateBag(byteArrayValue);
            case (byte)TypeEnum.ByteValue:
                byte byteValue = data[index++];
                return new ByteValueGameStateBag(byteValue);
            case (byte)TypeEnum.CharArray:
                int charArrayLength = BitConverter.ToInt32(data, index);
                index += 4;
                char[] charArrayValue = new char[charArrayLength];
                for (int i = 0; i < charArrayLength; i++)
                {
                    charArrayValue[i] = BitConverter.ToChar(data, index);
                    index += 2;
                }
                return new CharArrayGameStateBag(charArrayValue);
            case (byte)TypeEnum.CharValue:
                char charValue = BitConverter.ToChar(data, index);
                index += 2;
                return new CharValueGameStateBag(charValue);
            case (byte)TypeEnum.DateTimeValue:
                long dateTimeTicks = BitConverter.ToInt64(data, index);
                index += 8;
                return new DateTimeValueGameStateBag(new DateTime(dateTimeTicks));
            case (byte)TypeEnum.DecimalValue:
                int[] decimalBits = new int[4];
                for (int i = 0; i < 4; i++)
                {
                    decimalBits[i] = BitConverter.ToInt32(data, index);
                    index += 4;
                }
                return new DecimalValueGameStateBag(new decimal(decimalBits));
            case (byte)TypeEnum.DictionaryWithNonSequentialRetrieval:
                int dictionaryCount = BitConverter.ToInt32(data, index);
                index += 4;
                Dictionary<string, GameStateBag> dictionaryValue = new Dictionary<string, GameStateBag>();
                for (int i = 0; i < dictionaryCount; i++)
                {
                    string key = GetString(ref index);
                    GameStateBag value = Deserialize(ref index, data);
                    dictionaryValue[key] = value;
                }
                return new DictionaryGameStateBag(dictionaryValue, false);
            case (byte)TypeEnum.DictionaryWithSequentialRetrieval:
                int sequentialDictionaryCount = BitConverter.ToInt32(data, index);
                index += 4;
                Dictionary<string, GameStateBag> sequentialDictionaryValue = new Dictionary<string, GameStateBag>();
                for (int i = 0; i < sequentialDictionaryCount; i++)
                {                    
                    GameStateBag value = Deserialize(ref index, data);
                    sequentialDictionaryValue[i.ToString()] = value;
                }
                return new DictionaryGameStateBag(sequentialDictionaryValue);
            case (byte)TypeEnum.IntegerValue:
                int intValue = BitConverter.ToInt32(data, index);
                index += 4;
                return new IntValueGameStateBag(intValue);
            case (byte)TypeEnum.List:
                int listCount = BitConverter.ToInt32(data, index);
                index += 4;
                GameStateBag[] listValue = new GameStateBag[listCount];
                for (int i = 0; i < listCount; i++)
                {
                    listValue[i] = Deserialize(ref index, data);
                }
                return new ListGameStateBag(listValue);
            case (byte)TypeEnum.NullValue:
                return new NullValueGameStateBag();
            case (byte)TypeEnum.ObjectWithoutState:
                int objectWithoutStateId = BitConverter.ToInt32(data, index);
                index += 4;
                string objectWithoutStateTypeName = GetString(ref index);
                return new ObjectGameStateBag(objectWithoutStateId, objectWithoutStateTypeName, null);
            case (byte)TypeEnum.ObjectWithState:
                GameStateBag objectState = Deserialize(ref index, data);
                int objectWithStateId = BitConverter.ToInt32(data, index);
                index += 4;
                string objectWithStateTypeName = GetString(ref index);
                return new ObjectGameStateBag(objectWithStateId, objectWithStateTypeName, (DictionaryGameStateBag)objectState);
            case (byte)TypeEnum.ReferenceToObject:
                int referenceObjectId = BitConverter.ToInt32(data, index);
                index += 4;
                return new ReferenceGameStateBag(referenceObjectId);
            case (byte)TypeEnum.StringValue:
                int stringLength = BitConverter.ToInt32(data, index);
                index += 4;
                string stringValue = System.Text.Encoding.UTF8.GetString(data, index, stringLength);
                index += stringLength;
                return new StringValueGameStateBag(stringValue);
            case (byte)TypeEnum.TimeSpanValue:
                long timeSpanTicks = BitConverter.ToInt64(data, index);
                index += 8;
                return new TimeSpanValueGameStateBag(new TimeSpan(timeSpanTicks));
            default:
                throw new Exception($"Unsupported game state bag type {type}");
        }
    }
    public SaveGameData Deserialize(byte[] serializedSaveGameData)
    {
        byte[] unzippedSerializedData = Unzip(serializedSaveGameData);

        int index = 0;
        GameStateBag gameStateBag = Deserialize(ref index, unzippedSerializedData);
        return new SaveGameData(gameStateBag);
    }
}
