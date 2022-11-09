using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class GreyQuestionAnimation : Animation
{
    public override char Character => '*';
    public override Colour Colour => Colour.Grey;
    public override string Name => "GreyQuestion";
    public override Colour AlternateColour => Colour.BrightGrey;
    public override string Sequence => @"??????";
}
