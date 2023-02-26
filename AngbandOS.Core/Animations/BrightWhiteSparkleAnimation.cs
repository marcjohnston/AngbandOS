namespace AngbandOS.Core.Animations;

[Serializable]
internal class BrightWhiteSparkleAnimation : Animation
{
    private BrightWhiteSparkleAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.BrightWhite;
    public override string Name => "BrightWhiteSparkle";
    public override Colour AlternateColour => Colour.BrightWhite;
    public override string Sequence => @"·+·x·+·";
}
