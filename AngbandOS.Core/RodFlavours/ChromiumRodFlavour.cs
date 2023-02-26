namespace AngbandOS.Core.RodFlavours;

[Serializable]
internal class ChromiumRodFlavour : RodFlavour
{
    private ChromiumRodFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '-';
    public override Colour Colour => Colour.BrightWhite;
    public override string Name => "Chromium";
}
