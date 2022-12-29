namespace AngbandOS.Core;

[Serializable]
internal class BrightGreenExpandAnimation : Animation
{
    public override char Character => '*';
    public override Colour Colour => Colour.BrightGreen;
    public override string Name => "BrightGreenExpand";
    public override Colour AlternateColour => Colour.BrightGreen;
    public override string Sequence => @"·oO";
}
