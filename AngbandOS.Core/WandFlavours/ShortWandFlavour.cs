namespace AngbandOS.Core.WandFlavours;

[Serializable]
internal class ShortWandFlavour : WandFlavour
{
    public override char Character => '-';
    public override Colour Colour => Colour.Orange;
    public override string Name => "Short";
}
