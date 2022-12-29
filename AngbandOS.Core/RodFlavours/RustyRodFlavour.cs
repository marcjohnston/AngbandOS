namespace AngbandOS.Core;

[Serializable]
internal class RustyRodFlavour : RodFlavour
{
    public override char Character => '-';
    public override Colour Colour => Colour.BrightOrange;
    public override string Name => "Rusty";
}
