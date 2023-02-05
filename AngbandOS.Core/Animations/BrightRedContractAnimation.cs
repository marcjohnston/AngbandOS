namespace AngbandOS.Core.Animations;

[Serializable]
internal class BrightRedContractAnimation : Animation
{
    public override char Character => '*';
    public override Colour Colour => Colour.BrightRed;
    public override string Name => "BrightRedContract";
    public override Colour AlternateColour => Colour.BrightRed;
    public override string Sequence => @"Oo·";
}
