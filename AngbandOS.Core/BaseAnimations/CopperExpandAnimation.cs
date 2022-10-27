using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class CopperExpandAnimation : BaseAnimation
{
    public override char Character => '*';
    public override Colour Colour => Colour.Copper;
    public override string Name => "CopperExpand";
    public override Colour AlternateColour => Colour.Copper;
    public override string Sequence => @"·oO";
}
