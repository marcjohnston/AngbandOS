// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
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
