using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class PinkExpandAnimation : BaseAnimation
{
    public override char Character => '*';
    public override Colour Colour => Colour.Pink;
    public override string Name => "PinkExpand";
    public override Colour AlternateColour => Colour.Pink;
    public override string Sequence => @"·oO";
}
