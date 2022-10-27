using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class ChartreuseControlAnimation : BaseAnimation
{
    public override char Character => '*';
    public override Colour Colour => Colour.Chartreuse;
    public override string Name => "ChartreuseControl";
    public override Colour AlternateColour => Colour.BrightChartreuse;
    public override string Sequence => @"!!!!";
}
