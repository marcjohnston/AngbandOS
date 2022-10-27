using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class WhiteSparkleAnimation : BaseAnimation
{
    public override char Character => '*';
    public override string Name => "WhiteSparkle";
    public override string Sequence => @"·+·x·+·";
    public override Colour Colour => Colour.White;
    public override Colour AlternateColour => Colour.White;
}
