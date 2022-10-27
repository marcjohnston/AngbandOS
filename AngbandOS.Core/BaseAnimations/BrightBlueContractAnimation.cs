using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class BrightBlueContractAnimation : BaseAnimation
{
    public override char Character => '*';
    public override Colour Colour => Colour.BrightBlue;
    public override string Name => "BrightBlueContract";
    public override Colour AlternateColour => Colour.BrightBlue;
    public override string Sequence => @"Oo·";
}
