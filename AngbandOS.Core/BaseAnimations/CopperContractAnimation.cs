using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class CopperContractAnimation : BaseAnimation
{
    public override char Character => '*';
    public override Colour Colour => Colour.Copper;
    public override string Name => "CopperContract";
    public override Colour AlternateColour => Colour.Copper;
    public override string Sequence => @"Oo·";
}
