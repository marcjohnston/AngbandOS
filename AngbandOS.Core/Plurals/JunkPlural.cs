namespace AngbandOS.Core.Plurals;

[Serializable]
internal class JunkPlural : Plural
{
    private JunkPlural(Game game) : base(game) { } // This object is a singleton.

    public override string Key => "Junk";

    public override string PluralForm => "Junk";
}
