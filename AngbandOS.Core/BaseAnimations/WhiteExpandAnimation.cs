using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class WhiteExpandAnimation : BaseAnimation
{
    public override char Character => '*';
    public override string Name => "WhiteExpand";
    public override string Sequence => @"·oO";
    public override Colour Colour => Colour.White;
    public override Colour AlternateColour => Colour.White;
}
