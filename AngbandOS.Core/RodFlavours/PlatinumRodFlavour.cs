namespace AngbandOS.Core.RodFlavours;

[Serializable]
internal class PlatinumRodFlavour : RodFlavour
{
    public override char Character => '-';
    public override Colour Colour => Colour.BrightWhite;
    public override string Name => "Platinum";
}
