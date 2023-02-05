namespace AngbandOS.Core.Animations;

[Serializable]
internal class ChartreuseQuestionAnimation : Animation
{
    public override char Character => '*';
    public override Colour Colour => Colour.Chartreuse;
    public override string Name => "ChartreuseQuestion";
    public override Colour AlternateColour => Colour.BrightChartreuse;
    public override string Sequence => @"??????";
}
