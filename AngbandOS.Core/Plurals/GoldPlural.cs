namespace AngbandOS.Core.Plurals;

[Serializable]
internal class GoldPlural : Plural
{
    private GoldPlural(Game game) : base(game) { } // This object is a singleton.

    public override string Key => "Gold";

    public override string PluralForm => "Gold";
}
