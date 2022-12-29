namespace AngbandOS.Core;

[Serializable]
internal class BrightChartreuseExpandAnimation : Animation
{
    public override char Character => '*';
    public override Colour Colour => Colour.BrightChartreuse;
    public override string Name => "BrightChartreuseExpand";
    public override Colour AlternateColour => Colour.BrightChartreuse;
    public override string Sequence => @"·oO";
}
