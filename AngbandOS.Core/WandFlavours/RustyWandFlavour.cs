namespace AngbandOS.Core;

[Serializable]
internal class RustyWandFlavour : WandFlavour
{
    public override char Character => '-';
    public override Colour Colour => Colour.BrightOrange;
    public override string Name => "Rusty";
}
