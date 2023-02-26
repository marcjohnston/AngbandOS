namespace AngbandOS.Core.Animations;

[Serializable]
internal class YellowControlAnimation : Animation
{
    private YellowControlAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.Yellow;
    public override string Name => "YellowControl";
    public override Colour AlternateColour => Colour.BrightYellow;
    public override string Sequence => @"!!!!";
}
