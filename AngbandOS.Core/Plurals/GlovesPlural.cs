namespace AngbandOS.Core.Plurals;

[Serializable]
internal class GlovesPlural : Plural
{
    private GlovesPlural(Game game) : base(game) { } // This object is a singleton.

    public override string Key => "Gloves";

    public override string PluralForm => "Gloves";
}
