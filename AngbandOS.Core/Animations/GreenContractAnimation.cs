namespace AngbandOS.Core;

[Serializable]
internal class GreenContractAnimation : Animation
{
    public override char Character => '*';
    public override Colour Colour => Colour.Green;
    public override string Name => "GreenContract";
    public override Colour AlternateColour => Colour.Green;
    public override string Sequence => @"Oo·";
}
