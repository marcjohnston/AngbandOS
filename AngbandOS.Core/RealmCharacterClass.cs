// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

[Serializable]
internal class RealmCharacterClass : IGetKey, IToJson
{
    protected readonly Game Game;
    public RealmCharacterClass(Game game, RealmCharacterClassGameConfiguration realmCharacterClassGameConfiguration)
    {
        Game = game;
        CharacterClassBindingKey = realmCharacterClassGameConfiguration.CharacterClassBindingKey;
        RealmBindingKey = realmCharacterClassGameConfiguration.RealmBindingKey;
        CharacterClassTitle = realmCharacterClassGameConfiguration.CharacterClassTitle;
        DeityBindingKey = realmCharacterClassGameConfiguration.DeityBindingKey;
    }

    /// <summary>
    /// Returns the entity serialized into a Json string.
    /// </summary>
    /// <returns></returns>
    public string ToJson()
    {
        RealmCharacterClassGameConfiguration definition = new RealmCharacterClassGameConfiguration()
        {
            RealmBindingKey = RealmBindingKey,
            CharacterClassBindingKey = CharacterClassBindingKey,
            CharacterClassTitle = CharacterClassTitle,
            DeityBindingKey = DeityBindingKey,
        };
        return JsonSerializer.Serialize(definition, Game.GetJsonSerializerOptions());
    }

    public string GetKey => $"{RealmBindingKey}-{CharacterClassBindingKey}";

    public void Bind()
    {
        CharacterClass = Game.SingletonRepository.Get<BaseCharacterClass>(CharacterClassBindingKey);
        Realm = Game.SingletonRepository.Get<Realm>(RealmBindingKey);
        Deity = Game.SingletonRepository.GetNullable<God>(DeityBindingKey);
    }

    public static string GetCompositeKey(Realm t1, BaseCharacterClass t2) => $"{t1.GetKey}-{t2.GetKey}";
    public God? Deity { get; private set; }

    public BaseCharacterClass CharacterClass { get; private set; }
    public Realm Realm { get; private set; }
    protected virtual string CharacterClassBindingKey { get; }
    protected virtual string RealmBindingKey { get; }
    public virtual string? CharacterClassTitle { get; }
    public virtual string? DeityBindingKey { get; } = null;
}
