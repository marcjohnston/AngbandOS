using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class BrightChartreuseSwirlAnimation : Animation
{
    public override char Character => '*';
    public override Colour Colour => Colour.BrightChartreuse;
    public override string Name => "BrightChartreuseSwirl";
    public override Colour AlternateColour => Colour.BrightChartreuse;
    public override string Sequence => @"|/-\|/-\|/-\|/-\";
}
