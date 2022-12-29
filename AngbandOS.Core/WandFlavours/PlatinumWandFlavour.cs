namespace AngbandOS.Core;

[Serializable]
internal class PlatinumWandFlavour : WandFlavour
{
    public override char Character => '-';
    public override Colour Colour => Colour.BrightWhite;
    public override string Name => "Platinum";
}
