namespace AngbandOS.Core.Animations;

[Serializable]
internal class BlueQuestionAnimation : Animation
{
    private BlueQuestionAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.Blue;
    public override string Name => "BlueQuestion";
    public override Colour AlternateColour => Colour.BrightBlue;
    public override string Sequence => @"??????";
}
