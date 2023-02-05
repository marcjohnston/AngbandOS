namespace AngbandOS.Core.WandFlavours;

[Serializable]
internal class ChromiumWandFlavour : WandFlavour
{
    public override char Character => '-';
    public override Colour Colour => Colour.BrightWhite;
    public override string Name => "Chromium";
}
