namespace AngbandOS.Core.RodFlavours;

[Serializable]
internal class AdamantiteRodFlavour : RodFlavour
{
    private AdamantiteRodFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '-';
    public override Colour Colour => Colour.Chartreuse;
    public override string Name => "Adamantite";
}
