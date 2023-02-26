namespace AngbandOS.Core.Animations;

[Serializable]
internal class ChartreuseQuestionAnimation : Animation
{
    private ChartreuseQuestionAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.Chartreuse;
    public override string Name => "ChartreuseQuestion";
    public override Colour AlternateColour => Colour.BrightChartreuse;
    public override string Sequence => @"??????";
}
