// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
using System.Diagnostics;
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
        DerivedObjectWithState = 18,
        DerivedObjectWithoutState = 19,
        NonDerivedObjectWithState = 20,
        NonDerivedObjectWithoutState = 21,
        ReferenceToObject = 15,
        StringValue = 16,
        TimeSpanValue = 17
    }
    
    //private static List<string> u = new List<string>();
    private static byte[] Serialize(GameStateBag gameStateData)
    {
        List<byte> result = new List<byte>();

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
                    result.Add((byte)TypeEnum.BooleanTrueValue);
                }
                else
                {
                    result.Add((byte)TypeEnum.BooleanFalseValue);
                }
                break;
            case ByteArrayGameStateBag byteArrayGameStateBag:
                result.Add((byte)TypeEnum.ByteArray);
                result.AddRange(BitConverter.GetBytes(byteArrayGameStateBag.Value.Length));
                result.AddRange(byteArrayGameStateBag.Value);
                break;
            case ByteValueGameStateBag byteValueGameStateBag:
                result.Add((byte)TypeEnum.ByteValue);
                result.Add(byteValueGameStateBag.Value);
                break;
            case CharArrayGameStateBag charArrayGameStateBag:
                result.Add((byte)TypeEnum.CharArray);
                result.AddRange(BitConverter.GetBytes(charArrayGameStateBag.Value.Length));
                foreach (char c in charArrayGameStateBag.Value)
                {
                    result.AddRange(BitConverter.GetBytes(c));
                }
                break;
            case CharValueGameStateBag charValueGameStateBag:
                result.Add((byte)TypeEnum.CharValue);
                result.AddRange(BitConverter.GetBytes(charValueGameStateBag.Value));
                break;
            case DateTimeValueGameStateBag dateTimeValueGameStateBag:
                result.Add((byte)TypeEnum.DateTimeValue);
                result.AddRange(BitConverter.GetBytes(dateTimeValueGameStateBag.Value.Ticks));
                break;
            case DecimalValueGameStateBag decimalValueGameStateBag:
                result.Add((byte)TypeEnum.DecimalValue);
                int[] bits = decimal.GetBits(decimalValueGameStateBag.Value);
                foreach (int bit in bits)
                {
                    result.AddRange(BitConverter.GetBytes(bit));
                }
                break;
            case DictionaryGameStateBag dictionaryGameStateBag:
                result.Add(dictionaryGameStateBag.SequentialRetrieval ? (byte)TypeEnum.DictionaryWithSequentialRetrieval : (byte)TypeEnum.DictionaryWithNonSequentialRetrieval);
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
                result.Add((byte)TypeEnum.IntegerValue);
                result.AddRange(BitConverter.GetBytes(intValueGameStateBag.Value));
                break;
            case ListGameStateBag listGameStateBag:
                result.Add((byte)TypeEnum.List);
                result.AddRange(BitConverter.GetBytes(listGameStateBag.Values.Length));
                foreach (var item in listGameStateBag.Values)
                {
                    result.AddRange(Serialize(item));
                }
                break;
            case NullValueGameStateBag:
                result.Add((byte)TypeEnum.NullValue);
                break;
            case ObjectGameStateBag objectGameStateBag:
                if (objectGameStateBag.Values is null)
                {
                    result.Add((byte)TypeEnum.ObjectWithoutState);
                }
                else
                {
                    result.Add((byte)TypeEnum.ObjectWithState);
                    result.AddRange(Serialize(objectGameStateBag.Values));
                }
                result.AddRange(BitConverter.GetBytes(objectGameStateBag.ObjectId));
                AddTypeName(objectGameStateBag.TypeName);
                break;
            case DerivedObjectGameStateBag derivedObjectGameStateBag:
                if (derivedObjectGameStateBag.Values is null)
                {
                    if (derivedObjectGameStateBag.DerivedId is null)
                    {
                        result.Add((byte)TypeEnum.NonDerivedObjectWithoutState);
                    }
                    else
                    {
                        result.Add((byte)TypeEnum.DerivedObjectWithoutState);
                        result.Add(derivedObjectGameStateBag.DerivedId.Value);
                    }
                }
                else
                {
                    if (derivedObjectGameStateBag.DerivedId is null)
                    {
                        result.Add((byte)TypeEnum.NonDerivedObjectWithState);
                    }
                    else
                    {
                        result.Add((byte)TypeEnum.DerivedObjectWithState);
                        result.Add(derivedObjectGameStateBag.DerivedId.Value);
                    }
                    result.AddRange(Serialize(derivedObjectGameStateBag.Values));
                }
                result.AddRange(BitConverter.GetBytes(derivedObjectGameStateBag.ObjectId));
                break;
            case ReferenceGameStateBag referenceGameStateBag:
                result.Add((byte)TypeEnum.ReferenceToObject);
                result.AddRange(BitConverter.GetBytes(referenceGameStateBag.ObjectId));
                break;
            case StringValueGameStateBag stringValueGameStateBag:
                result.Add((byte)TypeEnum.StringValue);
                AddString(stringValueGameStateBag.Value);
                break;
            case TimeSpanValueGameStateBag timeSpanValueGameStateBag:
                result.Add((byte)TypeEnum.TimeSpanValue);
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
                    int keyLength = BitConverter.ToInt32(data, index);
                    index += 4;
                    string key = System.Text.Encoding.UTF8.GetString(data, index, keyLength);
                    index += keyLength;
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
                int objectId = BitConverter.ToInt32(data, index);
                index += 4;
                int typeNameLength = BitConverter.ToInt32(data, index);
                index += 4;
                string typeName = System.Text.Encoding.UTF8.GetString(data, index, typeNameLength);
                index += typeNameLength;
                return new ObjectGameStateBag(objectId, typeName, null);
            case (byte)TypeEnum.ObjectWithState:
                GameStateBag values = Deserialize(ref index, data);
                int objectId2 = BitConverter.ToInt32(data, index);
                index += 4;
                int typeNameLength2 = BitConverter.ToInt32(data, index);
                index += 4;
                string typeName2 = System.Text.Encoding.UTF8.GetString(data, index, typeNameLength2);
                index += typeNameLength2;
                return new ObjectGameStateBag(objectId2, typeName2, (DictionaryGameStateBag)values);
            case (byte)TypeEnum.DerivedObjectWithoutState:
                byte derivedId = data[index++];
                int derivedObjectId = BitConverter.ToInt32(data, index);
                index += 4;
                return new DerivedObjectGameStateBag(derivedObjectId, derivedId, null);
            case (byte)TypeEnum.DerivedObjectWithState:
                byte derivedWithStateId = data[index++];
                GameStateBag derivedState = Deserialize(ref index, data);
                int derivedObjectId2 = BitConverter.ToInt32(data, index);
                index += 4;
                return new DerivedObjectGameStateBag(derivedObjectId2, derivedWithStateId, (DictionaryGameStateBag)derivedState);
            case (byte)TypeEnum.NonDerivedObjectWithoutState:
                int nonDerivedObjectId = BitConverter.ToInt32(data, index);
                index += 4;
                return new DerivedObjectGameStateBag(nonDerivedObjectId, null, null);
            case (byte)TypeEnum.NonDerivedObjectWithState:
                GameStateBag nonDerivedState = Deserialize(ref index, data);
                int nonDerivedObjectId2 = BitConverter.ToInt32(data, index);
                index += 4;
                return new DerivedObjectGameStateBag(nonDerivedObjectId2, null, (DictionaryGameStateBag)nonDerivedState);
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
