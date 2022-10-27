using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class YellowExpandAnimation : BaseAnimation
{
    public override char Character => '*';
    public override Colour Colour => Colour.Yellow;
    public override string Name => "YellowExpand";
    public override Colour AlternateColour => Colour.Yellow;
    public override string Sequence => @"·oO";
}
