namespace AngbandOS.Core.Animations;

[Serializable]
internal class PinkQuestionAnimation : Animation
{
    private PinkQuestionAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.Pink;
    public override string Name => "PinkQuestion";
    public override Colour AlternateColour => Colour.BrightPink;
    public override string Sequence => @"??????";
}
