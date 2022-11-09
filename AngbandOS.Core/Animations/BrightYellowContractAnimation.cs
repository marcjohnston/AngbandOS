using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class BrightYellowContractAnimation : Animation
{
    public override char Character => '*';
    public override Colour Colour => Colour.BrightYellow;
    public override string Name => "BrightYellowContract";
    public override Colour AlternateColour => Colour.BrightYellow;
    public override string Sequence => @"Oo·";
}
