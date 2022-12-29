namespace AngbandOS.Core;

[Serializable]
internal class PurpleContractAnimation : Animation
{
    public override char Character => '*';
    public override Colour Colour => Colour.Purple;
    public override string Name => "PurpleContract";
    public override Colour AlternateColour => Colour.Purple;
    public override string Sequence => @"Oo·";
}
