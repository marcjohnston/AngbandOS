using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class GreySparkleAnimation : BaseAnimation
{
    public override char Character => '*';
    public override Colour Colour => Colour.Grey;
    public override string Name => "GreySparkle";
    public override Colour AlternateColour => Colour.Grey;
    public override string Sequence => @"·+·x·+·";
}
