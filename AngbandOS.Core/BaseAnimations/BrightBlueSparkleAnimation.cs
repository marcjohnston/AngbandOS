using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class BrightBlueSparkleAnimation : BaseAnimation
{
    public override char Character => '*';
    public override Colour Colour => Colour.BrightBlue;
    public override string Name => "BrightBlueSparkle";
    public override Colour AlternateColour => Colour.BrightBlue;
    public override string Sequence => @"·+·x·+·";
}
