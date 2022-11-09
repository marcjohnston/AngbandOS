using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class BrightGreenSparkleAnimation : Animation
{
    public override char Character => '*';
    public override Colour Colour => Colour.BrightGreen;
    public override string Name => "BrightGreenSparkle";
    public override Colour AlternateColour => Colour.BrightGreen;
    public override string Sequence => @"·+·x·+·";
}
