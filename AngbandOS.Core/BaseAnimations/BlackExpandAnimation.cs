using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class BlackExpandAnimation : BaseAnimation
{
    public override char Character => '*';
    public override Colour Colour => Colour.Black;
    public override string Name => "BlackExpand";
    public override Colour AlternateColour => Colour.Black;
    public override string Sequence => @"·oO";
}
