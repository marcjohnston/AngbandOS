namespace AngbandOS.Core;

[Serializable]
internal class BrightBrownContractAnimation : Animation
{
    public override char Character => '*';
    public override Colour Colour => Colour.BrightBrown;
    public override string Name => "BrightBrownContract";
    public override Colour AlternateColour => Colour.BrightBrown;
    public override string Sequence => @"Oo·";
}
