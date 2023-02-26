namespace AngbandOS.Core.Animations;

[Serializable]
internal class WhiteQuestionAnimation : Animation
{
    private WhiteQuestionAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override string Name => "WhiteQuestion";
    public override Colour AlternateColour => Colour.BrightWhite;
    public override string Sequence => @"??????";
    public override Colour Colour => Colour.White;
}
