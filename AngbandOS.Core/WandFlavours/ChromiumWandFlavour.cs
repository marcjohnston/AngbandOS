namespace AngbandOS.Core.WandFlavours;

[Serializable]
internal class ChromiumWandFlavour : WandFlavour
{
    private ChromiumWandFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '-';
    public override Colour Colour => Colour.BrightWhite;
    public override string Name => "Chromium";
}
