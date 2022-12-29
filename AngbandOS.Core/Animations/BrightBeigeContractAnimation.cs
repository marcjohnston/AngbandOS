namespace AngbandOS.Core;

[Serializable]
internal class BrightBeigeContractAnimation : Animation
{
    public override char Character => '*';
    public override Colour Colour => Colour.BrightBeige;
    public override string Name => "BrightBeigeContract";
    public override Colour AlternateColour => Colour.BrightBeige;
    public override string Sequence => @"Oo·";
}
