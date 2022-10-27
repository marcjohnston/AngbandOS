using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class BlackContractAnimation : BaseAnimation
{
    public override char Character => '*';
    public override Colour Colour => Colour.Black;
    public override string Name => "BlackContract";
    public override Colour AlternateColour => Colour.Black;
    public override string Sequence => @"Oo·";
}
