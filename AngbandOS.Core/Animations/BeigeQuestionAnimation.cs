namespace AngbandOS.Core.Animations;

[Serializable]
internal class BeigeQuestionAnimation : Animation
{
    private BeigeQuestionAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.Beige;
    public override string Name => "BeigeQuestion";
    public override Colour AlternateColour => Colour.BrightBeige;
    public override string Sequence => @"??????";
}
