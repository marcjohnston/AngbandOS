using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class BrightChartreuseSparkleAnimation : Animation
{
    public override char Character => '*';
    public override Colour Colour => Colour.BrightChartreuse;
    public override string Name => "BrightChartreuseSparkle";
    public override Colour AlternateColour => Colour.BrightChartreuse;
    public override string Sequence => @"·+·x·+·";
}
