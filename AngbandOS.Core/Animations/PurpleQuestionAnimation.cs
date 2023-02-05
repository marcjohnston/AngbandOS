namespace AngbandOS.Core.Animations;

[Serializable]
internal class PurpleQuestionAnimation : Animation
{
    public override char Character => '*';
    public override Colour Colour => Colour.Purple;
    public override string Name => "PurpleQuestion";
    public override Colour AlternateColour => Colour.BrightPurple;
    public override string Sequence => @"??????";
}
