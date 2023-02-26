namespace AngbandOS.Core.Animations;

[Serializable]
internal class BrightYellowSparkleAnimation : Animation
{
    private BrightYellowSparkleAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.BrightYellow;
    public override string Name => "BrightYellowSparkle";
    public override Colour AlternateColour => Colour.BrightYellow;
    public override string Sequence => @"·+·x·+·";
}
