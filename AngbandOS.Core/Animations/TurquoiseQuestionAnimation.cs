namespace AngbandOS.Core;

[Serializable]
internal class TurquoiseQuestionAnimation : Animation
{
    public override char Character => '*';
    public override Colour Colour => Colour.Turquoise;
    public override string Name => "TurquoiseQuestion";
    public override Colour AlternateColour => Colour.BrightTurquoise;
    public override string Sequence => @"??????";
}
