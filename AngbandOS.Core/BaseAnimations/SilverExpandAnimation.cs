using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class SilverExpandAnimation : BaseAnimation
{
    public override char Character => '*';
    public override Colour Colour => Colour.Silver;
    public override string Name => "SilverExpand";
    public override Colour AlternateColour => Colour.Silver;
    public override string Sequence => @"·oO";
}
