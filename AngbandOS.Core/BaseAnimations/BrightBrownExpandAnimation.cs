using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class BrightBrownExpandAnimation : BaseAnimation
{
    public override char Character => '*';
    public override Colour Colour => Colour.BrightBrown;
    public override string Name => "BrightBrownExpand";
    public override Colour AlternateColour => Colour.BrightBrown;
    public override string Sequence => @"·oO";
}
