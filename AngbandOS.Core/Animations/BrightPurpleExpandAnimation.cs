using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class BrightPurpleExpandAnimation : Animation
{
    public override char Character => '*';
    public override Colour Colour => Colour.BrightPurple;
    public override string Name => "BrightPurpleExpand";
    public override Colour AlternateColour => Colour.BrightPurple;
    public override string Sequence => @"·oO";
}
