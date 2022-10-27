using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class GreyExpandAnimation : BaseAnimation
{
    public override char Character => '*';
    public override Colour Colour => Colour.Grey;
    public override string Name => "GreyExpand";
    public override Colour AlternateColour => Colour.Grey;
    public override string Sequence => @"·oO";
}
