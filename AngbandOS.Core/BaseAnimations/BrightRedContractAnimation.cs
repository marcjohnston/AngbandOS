using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class BrightRedContractAnimation : BaseAnimation
{
    public override char Character => '*';
    public override Colour Colour => Colour.BrightRed;
    public override string Name => "BrightRedContract";
    public override Colour AlternateColour => Colour.BrightRed;
    public override string Sequence => @"Oo·";
}
