namespace AngbandOS.Core;

[Serializable]
internal class BrightWhiteContractAnimation : Animation
{
    public override char Character => '*';
    public override Colour Colour => Colour.BrightWhite;
    public override string Name => "BrightWhiteContract";
    public override Colour AlternateColour => Colour.BrightWhite;
    public override string Sequence => @"Oo·";
}
