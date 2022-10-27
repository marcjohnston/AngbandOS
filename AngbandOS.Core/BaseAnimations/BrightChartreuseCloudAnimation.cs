using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class BrightChartreuseCloudAnimation : BaseAnimation
{
    public override char Character => '*';
    public override Colour Colour => Colour.BrightChartreuse;
    public override string Name => "BrightChartreuseCloud";
    public override Colour AlternateColour => Colour.BrightChartreuse;
    public override string Sequence => @"+*+*+*+";
}
