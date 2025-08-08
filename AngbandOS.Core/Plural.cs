namespace AngbandOS.Core;

[Serializable]
internal sealed class Plural : IGetKey, IToJson
{
    private readonly Game Game;
    public Plural(Game game, PluralGameConfiguration pluralGameConfiguration)
    {
        Game = game;
        Key = pluralGameConfiguration.Key ?? pluralGameConfiguration.GetType().Name;
        PluralForm = pluralGameConfiguration.PluralForm;
    }

    /// <summary>
    /// Returns the entity serialized into a Json string.
    /// </summary>
    /// <returns></returns>
    public string ToJson()
    {
        PluralGameConfiguration definition = new()
        {
            Key = Key,
            PluralForm = PluralForm,
        };
        return JsonSerializer.Serialize(definition, Game.GetJsonSerializerOptions());
    }

    /// <summary>
    /// Returns the pluralized version of the key.
    /// the class.
    /// </summary>
    public string PluralForm { get; }

    /// <summary>
    /// Returns the capitalized singular version of the noun.
    /// </summary>
    public string Key { get; }

    public string GetKey => Key;
    public void Bind() { }
}