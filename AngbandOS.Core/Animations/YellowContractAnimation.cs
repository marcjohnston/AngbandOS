namespace AngbandOS.Core.Animations;

[Serializable]
internal class YellowContractAnimation : Animation
{
    public override char Character => '*';
    public override Colour Colour => Colour.Yellow;
    public override string Name => "YellowContract";
    public override Colour AlternateColour => Colour.Yellow;
    public override string Sequence => @"Oo·";
}
