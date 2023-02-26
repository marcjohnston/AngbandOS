namespace AngbandOS.Core.Animations;

[Serializable]
internal class BrightBrownSparkleAnimation : Animation
{
    private BrightBrownSparkleAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.BrightBrown;
    public override string Name => "BrightBrownSparkle";
    public override Colour AlternateColour => Colour.BrightBrown;
    public override string Sequence => @"·+·x·+·";
}
