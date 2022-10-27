using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class BrightRedExpandAnimation : BaseAnimation
{
    public override char Character => '*';
    public override Colour Colour => Colour.BrightRed;
    public override string Name => "BrightRedExpand";
    public override Colour AlternateColour => Colour.BrightRed;
    public override string Sequence => @"·oO";
}
