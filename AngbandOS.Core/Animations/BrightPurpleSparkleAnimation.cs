namespace AngbandOS.Core.Animations;

[Serializable]
internal class BrightPurpleSparkleAnimation : Animation
{
    private BrightPurpleSparkleAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.BrightPurple;
    public override string Name => "BrightPurpleSparkle";
    public override Colour AlternateColour => Colour.BrightPurple;
    public override string Sequence => @"·+·x·+·";
}
