using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class OrangeQuestionAnimation : Animation
{
    public override char Character => '*';
    public override Colour Colour => Colour.Orange;
    public override string Name => "OrangeQuestion";
    public override Colour AlternateColour => Colour.BrightOrange;
    public override string Sequence => @"??????";
}
