namespace AngbandOS.Core;

[Serializable]
internal class GenericPlural : Plural
{
    public GenericPlural(Game game, PluralGameConfiguration pluralDefinition) : base(game)
    {
        Key = pluralDefinition.Key;
        PluralForm = pluralDefinition.PluralForm;
    }
    public override string PluralForm { get; }

    /// <summary>
    /// Returns the capitalized singular version of the noun.
    /// </summary>
    public override string Key { get; }
}
