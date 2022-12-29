namespace AngbandOS.Core;

[Serializable]
internal class BrightBrownExpandAnimation : Animation
{
    public override char Character => '*';
    public override Colour Colour => Colour.BrightBrown;
    public override string Name => "BrightBrownExpand";
    public override Colour AlternateColour => Colour.BrightBrown;
    public override string Sequence => @"·oO";
}
