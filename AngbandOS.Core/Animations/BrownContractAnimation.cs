namespace AngbandOS.Core;

[Serializable]
internal class BrownContractAnimation : Animation
{
    public override char Character => '*';
    public override Colour Colour => Colour.Brown;
    public override string Name => "BrownContract";
    public override Colour AlternateColour => Colour.Brown;
    public override string Sequence => @"Oo·";
}
