namespace AngbandOS.Core.Animations;

[Serializable]
internal class BrightOrangeSparkleAnimation : Animation
{
    private BrightOrangeSparkleAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.BrightOrange;
    public override string Name => "BrightOrangeSparkle";
    public override Colour AlternateColour => Colour.BrightOrange;
    public override string Sequence => @"·+·x·+·";
}
