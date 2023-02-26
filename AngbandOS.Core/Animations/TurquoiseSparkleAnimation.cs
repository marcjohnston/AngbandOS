namespace AngbandOS.Core.Animations;

[Serializable]
internal class TurquoiseSparkleAnimation : Animation
{
    private TurquoiseSparkleAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.Turquoise;
    public override string Name => "TurquoiseSparkle";
    public override Colour AlternateColour => Colour.Turquoise;
    public override string Sequence => @"·+·x·+·";
}
