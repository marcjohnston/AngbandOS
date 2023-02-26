namespace AngbandOS.Core.Animations;

[Serializable]
internal class BrightTurquoiseSparkleAnimation : Animation
{
    private BrightTurquoiseSparkleAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.BrightTurquoise;
    public override string Name => "BrightTurquoiseSparkle";
    public override Colour AlternateColour => Colour.BrightTurquoise;
    public override string Sequence => @"·+·x·+·";
}
