namespace AngbandOS.Core.Plurals;

[Serializable]
internal class BootsPlural : Plural
{
    private BootsPlural(Game game) : base(game) { } // This object is a singleton.

    public override string Key => "Boots";

    public override string PluralForm => "Boots";
}
