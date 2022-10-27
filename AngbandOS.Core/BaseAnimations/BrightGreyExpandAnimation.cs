using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class BrightGreyExpandAnimation : BaseAnimation
{
    public override char Character => '*';
    public override Colour Colour => Colour.BrightGrey;
    public override string Name => "BrightGreyExpand";
    public override Colour AlternateColour => Colour.BrightGrey;
    public override string Sequence => @"·oO";
}
