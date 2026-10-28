namespace AngbandOS.Core;

internal sealed class Plural : IGetKey, IToJson, ISaveGameState
{
    private Game Game { get; }
    public Plural(Game game, PluralGameConfiguration gameConfiguration)
    {
        Game = game;
        Key = gameConfiguration.GetKey;
        PluralForm = gameConfiguration.PluralForm;
    }
    public GameStateBag? SaveGame(SaveGameState saveGameState) => null;

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
    public void RestoreGame(RestoreGameState restoreGameState) { }
    public void InitializationComplete() { }
}