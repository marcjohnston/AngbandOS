using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class GreenQuestionAnimation : BaseAnimation
{
    public override char Character => '*';
    public override Colour Colour => Colour.Green;
    public override string Name => "GreenQuestion";
    public override Colour AlternateColour => Colour.BrightGreen;
    public override string Sequence => @"??????";
}
