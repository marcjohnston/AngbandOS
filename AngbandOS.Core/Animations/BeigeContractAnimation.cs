using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class BeigeContractAnimation : Animation
{
    public override char Character => '*';
    public override Colour Colour => Colour.Beige;
    public override string Name => "BeigeContract";
    public override Colour AlternateColour => Colour.Beige;
    public override string Sequence => @"Oo·";
}
