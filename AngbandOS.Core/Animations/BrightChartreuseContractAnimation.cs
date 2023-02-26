namespace AngbandOS.Core.Animations;

[Serializable]
internal class BrightChartreuseContractAnimation : Animation
{
    private BrightChartreuseContractAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.BrightChartreuse;
    public override string Name => "BrightChartreuseContract";
    public override Colour AlternateColour => Colour.BrightChartreuse;
    public override string Sequence => @"Oo·";
}
