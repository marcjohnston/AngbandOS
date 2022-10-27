using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class YellowControlAnimation : BaseAnimation
{
    public override char Character => '*';
    public override Colour Colour => Colour.Yellow;
    public override string Name => "YellowControl";
    public override Colour AlternateColour => Colour.BrightYellow;
    public override string Sequence => @"!!!!";
}
