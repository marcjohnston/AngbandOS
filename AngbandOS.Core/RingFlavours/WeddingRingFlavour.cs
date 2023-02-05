namespace AngbandOS.Core.RingFlavours;

[Serializable]
internal class WeddingRingFlavour : RingFlavour
{
    public override char Character => '=';
    public override Colour Colour => Colour.Gold;
    public override string Name => "Wedding";
}
