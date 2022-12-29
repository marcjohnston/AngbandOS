namespace AngbandOS.Core;

[Serializable]
internal class BrightGreyContractAnimation : Animation
{
    public override char Character => '*';
    public override Colour Colour => Colour.BrightGrey;
    public override string Name => "BrightGreyContract";
    public override Colour AlternateColour => Colour.BrightGrey;
    public override string Sequence => @"Oo·";
}
