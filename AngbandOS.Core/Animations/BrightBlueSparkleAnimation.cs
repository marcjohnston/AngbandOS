namespace AngbandOS.Core.Animations;

[Serializable]
internal class BrightBlueSparkleAnimation : Animation
{
    private BrightBlueSparkleAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.BrightBlue;
    public override string Name => "BrightBlueSparkle";
    public override Colour AlternateColour => Colour.BrightBlue;
    public override string Sequence => @"·+·x·+·";
}
