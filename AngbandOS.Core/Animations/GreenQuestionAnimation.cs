namespace AngbandOS.Core.Animations;

[Serializable]
internal class GreenQuestionAnimation : Animation
{
    public override char Character => '*';
    public override Colour Colour => Colour.Green;
    public override string Name => "GreenQuestion";
    public override Colour AlternateColour => Colour.BrightGreen;
    public override string Sequence => @"??????";
}
