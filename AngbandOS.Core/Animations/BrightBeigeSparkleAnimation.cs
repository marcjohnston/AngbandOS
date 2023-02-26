namespace AngbandOS.Core.Animations;

[Serializable]
internal class BrightBeigeSparkleAnimation : Animation
{
    private BrightBeigeSparkleAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.BrightBeige;
    public override string Name => "BrightBeigeSparkle";
    public override Colour AlternateColour => Colour.BrightBeige;
    public override string Sequence => @"·+·x·+·";
}
