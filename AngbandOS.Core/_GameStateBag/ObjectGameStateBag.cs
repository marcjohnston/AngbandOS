// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;
internal class ObjectGameStateBag : GameStateBag
{
    public int ObjectId { get; }
    public Dictionary<string, GameStateBag> Value { get; }
    private TGameStateBag GetGameStateBag<TGameStateBag>(string key) where TGameStateBag : GameStateBag
    {
        if (Value.TryGetValue(key, out var gameStateBag) && gameStateBag is TGameStateBag typedGameStateBag)
        {
            return typedGameStateBag;
        }
        throw new InvalidOperationException($"Key '{key}' is missing or not of type {typeof(TGameStateBag).Name}.");
    }
    public bool GetBool(string key) => GetGameStateBag<BoolValueGameStateBag>(key).Value;

    public int GetInt(string key) => GetGameStateBag<IntValueGameStateBag>(key).Value;

    public string GetString(string key) => GetGameStateBag<StringValueGameStateBag>(key).Value;
    public ObjectGameStateBag(int objectId, Dictionary<string, GameStateBag> value)
    {
        ObjectId = objectId;
        Value = value;
    }
    public override string ToString()
    {
        return $"Object#{ObjectId}";
    }
}