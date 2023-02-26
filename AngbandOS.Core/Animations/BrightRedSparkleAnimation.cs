namespace AngbandOS.Core.Animations;

[Serializable]
internal class BrightRedSparkleAnimation : Animation
{
    private BrightRedSparkleAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.BrightRed;
    public override string Name => "BrightRedSparkle";
    public override Colour AlternateColour => Colour.BrightRed;
    public override string Sequence => @"·+·x·+·";
}
