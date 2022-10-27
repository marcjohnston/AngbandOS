using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class BrightYellowSparkleAnimation : BaseAnimation
{
    public override char Character => '*';
    public override Colour Colour => Colour.BrightYellow;
    public override string Name => "BrightYellowSparkle";
    public override Colour AlternateColour => Colour.BrightYellow;
    public override string Sequence => @"·+·x·+·";
}
