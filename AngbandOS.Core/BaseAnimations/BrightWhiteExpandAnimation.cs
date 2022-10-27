using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class BrightWhiteExpandAnimation : BaseAnimation
{
    public override char Character => '*';
    public override Colour Colour => Colour.BrightWhite;
    public override string Name => "BrightWhiteExpand";
    public override Colour AlternateColour => Colour.BrightWhite;
    public override string Sequence => @"·oO";
}
