namespace AngbandOS.Core;

[Serializable]
internal class RedQuestionAnimation : Animation
{
    public override char Character => '*';
    public override Colour Colour => Colour.Red;
    public override string Name => "RedQuestion";
    public override Colour AlternateColour => Colour.BrightRed;
    public override string Sequence => @"??????";
}
