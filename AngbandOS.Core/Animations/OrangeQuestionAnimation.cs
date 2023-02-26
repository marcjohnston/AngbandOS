namespace AngbandOS.Core.Animations;

[Serializable]
internal class OrangeQuestionAnimation : Animation
{
    private OrangeQuestionAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.Orange;
    public override string Name => "OrangeQuestion";
    public override Colour AlternateColour => Colour.BrightOrange;
    public override string Sequence => @"??????";
}
