namespace AngbandOS.Core.WandFlavours;

[Serializable]
internal class RustyWandFlavour : WandFlavour
{
    public override char Character => '-';
    public override Colour Colour => Colour.BrightOrange;
    public override string Name => "Rusty";
}
