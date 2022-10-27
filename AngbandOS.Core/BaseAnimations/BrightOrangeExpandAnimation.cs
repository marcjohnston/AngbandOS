using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class BrightOrangeExpandAnimation : BaseAnimation
{
    public override char Character => '*';
    public override Colour Colour => Colour.BrightOrange;
    public override string Name => "BrightOrangeExpand";
    public override Colour AlternateColour => Colour.BrightOrange;
    public override string Sequence => @"·oO";
}
