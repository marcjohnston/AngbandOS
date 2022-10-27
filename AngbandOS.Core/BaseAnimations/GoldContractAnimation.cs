using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class GoldContractAnimation : BaseAnimation
{
    public override char Character => '*';
    public override Colour Colour => Colour.Gold;
    public override string Name => "GoldContract";
    public override Colour AlternateColour => Colour.Gold;
    public override string Sequence => @"Oo·";
}
