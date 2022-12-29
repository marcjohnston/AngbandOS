namespace AngbandOS.Core;

[Serializable]
internal class RubyRingFlavour : RingFlavour
{
    public override char Character => '=';
    public override Colour Colour => Colour.BrightRed;
    public override string Name => "Ruby";
}
