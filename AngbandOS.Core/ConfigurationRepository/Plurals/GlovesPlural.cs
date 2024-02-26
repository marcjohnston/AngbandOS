namespace AngbandOS.Core.Plurals;

[Serializable]
internal class GlovesPlural : Plural
{
    private GlovesPlural(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override string Key => "Gloves";

    public override string PluralForm => "Gloves";
}
