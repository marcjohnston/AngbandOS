namespace AngbandOS.Core.Animations;

[Serializable]
internal class BrightChartreuseCloudAnimation : Animation
{
    private BrightChartreuseCloudAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.BrightChartreuse;
    public override string Name => "BrightChartreuseCloud";
    public override Colour AlternateColour => Colour.BrightChartreuse;
    public override string Sequence => @"+*+*+*+";
}
