using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class WhiteContractAnimation : BaseAnimation
{
    public override char Character => '*';
    public override string Name => "WhiteContract";
    public override string Sequence => @"Oo·";
    public override Colour Colour => Colour.White;
    public override Colour AlternateColour => Colour.White;
}
