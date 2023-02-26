namespace AngbandOS.Core.Animations;

[Serializable]
internal class YellowQuestionAnimation : Animation
{
    private YellowQuestionAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.Yellow;
    public override string Name => "YellowQuestion";
    public override Colour AlternateColour => Colour.BrightYellow;
    public override string Sequence => @"??????";
}
