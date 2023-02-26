namespace AngbandOS.Core.Animations;

[Serializable]
internal class GreyQuestionAnimation : Animation
{
    private GreyQuestionAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.Grey;
    public override string Name => "GreyQuestion";
    public override Colour AlternateColour => Colour.BrightGrey;
    public override string Sequence => @"??????";
}
