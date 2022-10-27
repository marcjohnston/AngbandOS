using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class DiamondContractAnimation : BaseAnimation
{
    public override char Character => '*';
    public override Colour Colour => Colour.Diamond;
    public override string Name => "DiamondContract";
    public override Colour AlternateColour => Colour.Diamond;
    public override string Sequence => @"Oo·";
}
