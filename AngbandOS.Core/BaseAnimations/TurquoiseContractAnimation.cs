using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class TurquoiseContractAnimation : BaseAnimation
{
    public override char Character => '*';
    public override Colour Colour => Colour.Turquoise;
    public override string Name => "TurquoiseContract";
    public override Colour AlternateColour => Colour.Turquoise;
    public override string Sequence => @"Oo·";
}
