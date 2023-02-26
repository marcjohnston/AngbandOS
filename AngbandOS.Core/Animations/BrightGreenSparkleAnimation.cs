namespace AngbandOS.Core.Animations;

[Serializable]
internal class BrightGreenSparkleAnimation : Animation
{
    private BrightGreenSparkleAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.BrightGreen;
    public override string Name => "BrightGreenSparkle";
    public override Colour AlternateColour => Colour.BrightGreen;
    public override string Sequence => @"·+·x·+·";
}
