using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class DiamondSparkleAnimation : BaseAnimation
{
    public override char Character => '*';
    public override Colour Colour => Colour.Diamond;
    public override string Name => "DiamondSparkle";
    public override Colour AlternateColour => Colour.Diamond;
    public override string Sequence => @"·+·x·+·";
}
