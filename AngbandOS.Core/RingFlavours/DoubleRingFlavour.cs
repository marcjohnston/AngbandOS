namespace AngbandOS.Core.RingFlavours;

[Serializable]
internal class DoubleRingFlavour : RingFlavour
{
    public override char Character => '=';
    public override Colour Colour => Colour.Grey;
    public override string Name => "Double";
}
