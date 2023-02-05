namespace AngbandOS.Core.RodFlavours;

[Serializable]
internal class ChromiumRodFlavour : RodFlavour
{
    public override char Character => '-';
    public override Colour Colour => Colour.BrightWhite;
    public override string Name => "Chromium";
}
