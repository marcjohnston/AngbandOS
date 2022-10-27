using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class BrightBlueExpandAnimation : BaseAnimation
{
    public override char Character => '*';
    public override Colour Colour => Colour.BrightBlue;
    public override string Name => "BrightBlueExpand";
    public override Colour AlternateColour => Colour.BrightBlue;
    public override string Sequence => @"·oO";
}
