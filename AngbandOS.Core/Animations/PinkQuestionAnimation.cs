using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class PinkQuestionAnimation : Animation
{
    public override char Character => '*';
    public override Colour Colour => Colour.Pink;
    public override string Name => "PinkQuestion";
    public override Colour AlternateColour => Colour.BrightPink;
    public override string Sequence => @"??????";
}
