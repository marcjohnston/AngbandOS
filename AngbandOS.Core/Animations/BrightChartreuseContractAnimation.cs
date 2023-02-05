namespace AngbandOS.Core.Animations;

[Serializable]
internal class BrightChartreuseContractAnimation : Animation
{
    public override char Character => '*';
    public override Colour Colour => Colour.BrightChartreuse;
    public override string Name => "BrightChartreuseContract";
    public override Colour AlternateColour => Colour.BrightChartreuse;
    public override string Sequence => @"Oo·";
}
