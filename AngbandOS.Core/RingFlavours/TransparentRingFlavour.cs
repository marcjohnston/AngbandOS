namespace AngbandOS.Core;

[Serializable]
internal class TransparentRingFlavour : RingFlavour
{
    public override char Character => '=';
    public override Colour Colour => Colour.Grey;
    public override string Name => "Transparent";
}
