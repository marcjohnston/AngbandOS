namespace AngbandOS.Core.RingFlavours;

[Serializable]
internal class DiamondRingFlavour : RingFlavour
{
    public override char Character => '=';
    public override Colour Colour => Colour.Diamond;
    public override string Name => "Diamond";
}
