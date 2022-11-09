using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class BlueQuestionAnimation : Animation
{
    public override char Character => '*';
    public override Colour Colour => Colour.Blue;
    public override string Name => "BlueQuestion";
    public override Colour AlternateColour => Colour.BrightBlue;
    public override string Sequence => @"??????";
}
