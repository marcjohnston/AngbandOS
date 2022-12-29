namespace AngbandOS.Core;

[Serializable]
internal class WhiteContractAnimation : Animation
{
    public override char Character => '*';
    public override string Name => "WhiteContract";
    public override string Sequence => @"Oo·";
    public override Colour Colour => Colour.White;
    public override Colour AlternateColour => Colour.White;
}
