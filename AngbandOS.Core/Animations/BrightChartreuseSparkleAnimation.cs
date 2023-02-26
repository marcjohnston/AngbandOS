namespace AngbandOS.Core.Animations;

[Serializable]
internal class BrightChartreuseSparkleAnimation : Animation
{
    private BrightChartreuseSparkleAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.BrightChartreuse;
    public override string Name => "BrightChartreuseSparkle";
    public override Colour AlternateColour => Colour.BrightChartreuse;
    public override string Sequence => @"·+·x·+·";
}
