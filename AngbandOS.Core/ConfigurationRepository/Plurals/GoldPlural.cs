namespace AngbandOS.Core.Plurals;

[Serializable]
internal class GoldPlural : Plural
{
    private GoldPlural(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override string Key => "Gold";

    public override string PluralForm => "Gold";
}
