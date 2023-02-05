namespace AngbandOS.Core.RodFlavours;

[Serializable]
internal class CopperPlatedRodFlavour : RodFlavour
{
    public override char Character => '-';
    public override Colour Colour => Colour.Copper;
    public override string Name => "Copper-Plated";
}
