namespace AngbandOS.Core;

[Serializable]
internal class BrightOrangeContractAnimation : Animation
{
    public override char Character => '*';
    public override Colour Colour => Colour.BrightOrange;
    public override string Name => "BrightOrangeContract";
    public override Colour AlternateColour => Colour.BrightOrange;
    public override string Sequence => @"Oo·";
}
