using System.Text.Json;

namespace AngbandOS.Core.Plurals;
[Serializable]
internal abstract class Plural : IGetKey
{
    protected readonly SaveGame SaveGame;
    protected Plural(SaveGame saveGame)
    {
        SaveGame = saveGame;
    }

    /// <summary>
    /// Returns the entity serialized into a Json string.
    /// </summary>
    /// <returns></returns>
    public string ToJson()
    {
        PluralDefinition definition = new()
        {
            Key = Key,
            PluralForm = PluralForm,
        };
        return JsonSerializer.Serialize<PluralDefinition>(definition);
    }

    /// <summary>
    /// Returns the pluralized version of the key.
    /// the class.
    /// </summary>
    public abstract string PluralForm { get; }

    /// <summary>
    /// Returns the capitalized singular version of the noun.
    /// </summary>
    public virtual string Key { get; }

    public string GetKey => Key;
    public void Bind() { }
}