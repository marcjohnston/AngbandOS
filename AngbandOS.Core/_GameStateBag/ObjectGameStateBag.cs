// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
using System.Text;

namespace AngbandOS.Core;
internal class ObjectGameStateBag : GameStateBag
{
    public int ObjectId { get; }
    public Dictionary<string, GameStateBag> Values { get; }
    private TGameStateBag GetGameStateBag<TGameStateBag>(string key) where TGameStateBag : GameStateBag
    {
        if (Values.TryGetValue(key, out var gameStateBag) && gameStateBag is TGameStateBag typedGameStateBag)
        {
            return typedGameStateBag;
        }
        throw new InvalidOperationException($"The key '{key}' does not belong to the type {typeof(TGameStateBag).Name}.");
    }
    public bool GetBool(string key) => GetGameStateBag<BoolValueGameStateBag>(key).Value;

    public int GetInt(string key) => GetGameStateBag<IntValueGameStateBag>(key).Value;

    public string GetString(string key) => GetGameStateBag<StringValueGameStateBag>(key).Value;

    public DateTime GetDateTime(string key) => GetGameStateBag<DateTimeValueGameStateBag>(key).Value;

    public byte GetByte(string key) => GetGameStateBag<ByteValueGameStateBag>(key).Value;

    public char GetChar(string key) => GetGameStateBag<CharValueGameStateBag>(key).Value;

    public decimal GetDecimal(string key) => GetGameStateBag<DecimalValueGameStateBag>(key).Value;

    public char[] GetCharArray(string key) => GetGameStateBag<CharArrayGameStateBag>(key).Value.ToCharArray();

    public byte[] GetByteArray(string key) => Encoding.UTF8.GetBytes(GetGameStateBag<ByteArrayGameStateBag>(key).Value);

    public TimeSpan GetTimeSpan(string key) => GetGameStateBag<TimeSpanValueGameStateBag>(key).Value;

    public ColorEnum GetColorEnum(string key) => GetGameStateBag<ColorEnumValueGameStateBag>(key).Value;

    public ObjectGameStateBag(int objectId, Dictionary<string, GameStateBag> value)
    {
        ObjectId = objectId;
        Values = value;
    }
    public override string ToString()
    {
        return $"Object#{ObjectId}";
    }
}