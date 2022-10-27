using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class BrightBeigeSparkleAnimation : BaseAnimation
{
    public override char Character => '*';
    public override Colour Colour => Colour.BrightBeige;
    public override string Name => "BrightBeigeSparkle";
    public override Colour AlternateColour => Colour.BrightBeige;
    public override string Sequence => @"·+·x·+·";
}
