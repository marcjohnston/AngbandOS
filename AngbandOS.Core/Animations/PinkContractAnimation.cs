namespace AngbandOS.Core;

[Serializable]
internal class PinkContractAnimation : Animation
{
    public override char Character => '*';
    public override Colour Colour => Colour.Pink;
    public override string Name => "PinkContract";
    public override Colour AlternateColour => Colour.Pink;
    public override string Sequence => @"Oo·";
}
