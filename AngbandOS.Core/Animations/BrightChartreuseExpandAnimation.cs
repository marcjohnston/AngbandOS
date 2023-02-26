namespace AngbandOS.Core.Animations;

[Serializable]
internal class BrightChartreuseExpandAnimation : Animation
{
    private BrightChartreuseExpandAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.BrightChartreuse;
    public override string Name => "BrightChartreuseExpand";
    public override Colour AlternateColour => Colour.BrightChartreuse;
    public override string Sequence => @"·oO";
}
