namespace AngbandOS.Core.Animations;

[Serializable]
internal class CopperContractAnimation : Animation
{
    public override char Character => '*';
    public override Colour Colour => Colour.Copper;
    public override string Name => "CopperContract";
    public override Colour AlternateColour => Colour.Copper;
    public override string Sequence => @"Oo·";
}
