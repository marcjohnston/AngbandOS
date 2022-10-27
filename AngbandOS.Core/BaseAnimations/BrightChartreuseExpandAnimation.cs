using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class BrightChartreuseExpandAnimation : BaseAnimation
{
    public override char Character => '*';
    public override Colour Colour => Colour.BrightChartreuse;
    public override string Name => "BrightChartreuseExpand";
    public override Colour AlternateColour => Colour.BrightChartreuse;
    public override string Sequence => @"·oO";
}
