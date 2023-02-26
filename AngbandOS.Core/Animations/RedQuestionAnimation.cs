namespace AngbandOS.Core.Animations;

[Serializable]
internal class RedQuestionAnimation : Animation
{
    private RedQuestionAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.Red;
    public override string Name => "RedQuestion";
    public override Colour AlternateColour => Colour.BrightRed;
    public override string Sequence => @"??????";
}
