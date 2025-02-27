namespace AngbandOS.Core;

[Serializable]
internal class GenericPlural : Plural
{
    public GenericPlural(Game game, PluralGameConfiguration pluralGameConfiguration) : base(game)
    {
        Key = pluralGameConfiguration.Key ?? pluralGameConfiguration.GetType().Name;
        PluralForm = pluralGameConfiguration.PluralForm;
    }
    public override string PluralForm { get; }

    /// <summary>
    /// Returns the capitalized singular version of the noun.
    /// </summary>
    public override string Key { get; }
}
