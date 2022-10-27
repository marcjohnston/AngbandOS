using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class YellowContractAnimation : BaseAnimation
{
    public override char Character => '*';
    public override Colour Colour => Colour.Yellow;
    public override string Name => "YellowContract";
    public override Colour AlternateColour => Colour.Yellow;
    public override string Sequence => @"Oo·";
}
