using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class YellowQuestionAnimation : Animation
{
    public override char Character => '*';
    public override Colour Colour => Colour.Yellow;
    public override string Name => "YellowQuestion";
    public override Colour AlternateColour => Colour.BrightYellow;
    public override string Sequence => @"??????";
}
