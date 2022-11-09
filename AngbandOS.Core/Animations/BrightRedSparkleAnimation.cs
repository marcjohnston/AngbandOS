using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class BrightRedSparkleAnimation : Animation
{
    public override char Character => '*';
    public override Colour Colour => Colour.BrightRed;
    public override string Name => "BrightRedSparkle";
    public override Colour AlternateColour => Colour.BrightRed;
    public override string Sequence => @"·+·x·+·";
}
