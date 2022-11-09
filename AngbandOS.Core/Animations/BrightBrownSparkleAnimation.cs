using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class BrightBrownSparkleAnimation : Animation
{
    public override char Character => '*';
    public override Colour Colour => Colour.BrightBrown;
    public override string Name => "BrightBrownSparkle";
    public override Colour AlternateColour => Colour.BrightBrown;
    public override string Sequence => @"·+·x·+·";
}
