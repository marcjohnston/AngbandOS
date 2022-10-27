using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class BrightPurpleSparkleAnimation : BaseAnimation
{
    public override char Character => '*';
    public override Colour Colour => Colour.BrightPurple;
    public override string Name => "BrightPurpleSparkle";
    public override Colour AlternateColour => Colour.BrightPurple;
    public override string Sequence => @"·+·x·+·";
}
