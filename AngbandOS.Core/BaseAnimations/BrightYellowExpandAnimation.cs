using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class BrightYellowExpandAnimation : BaseAnimation
{
    public override char Character => '*';
    public override Colour Colour => Colour.BrightYellow;
    public override string Name => "BrightYellowExpand";
    public override Colour AlternateColour => Colour.BrightYellow;
    public override string Sequence => @"·oO";
}
