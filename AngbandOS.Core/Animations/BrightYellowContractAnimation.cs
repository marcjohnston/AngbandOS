namespace AngbandOS.Core.Animations;

[Serializable]
internal class BrightYellowContractAnimation : Animation
{
    public override char Character => '*';
    public override Colour Colour => Colour.BrightYellow;
    public override string Name => "BrightYellowContract";
    public override Colour AlternateColour => Colour.BrightYellow;
    public override string Sequence => @"Oo·";
}
