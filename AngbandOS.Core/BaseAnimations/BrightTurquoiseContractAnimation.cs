using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class BrightTurquoiseContractAnimation : BaseAnimation
{
    public override char Character => '*';
    public override Colour Colour => Colour.BrightTurquoise;
    public override string Name => "BrightTurquoiseContract";
    public override Colour AlternateColour => Colour.BrightTurquoise;
    public override string Sequence => @"Oo·";
}
