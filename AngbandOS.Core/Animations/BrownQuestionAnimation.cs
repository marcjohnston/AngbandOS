namespace AngbandOS.Core.Animations;

[Serializable]
internal class BrownQuestionAnimation : Animation
{
    private BrownQuestionAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.Brown;
    public override string Name => "BrownQuestion";
    public override Colour AlternateColour => Colour.BrightBrown;
    public override string Sequence => @"??????";
}
