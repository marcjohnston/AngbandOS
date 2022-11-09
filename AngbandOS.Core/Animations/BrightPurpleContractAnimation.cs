using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class BrightPurpleContractAnimation : Animation
{
    public override char Character => '*';
    public override Colour Colour => Colour.BrightPurple;
    public override string Name => "BrightPurpleContract";
    public override Colour AlternateColour => Colour.BrightPurple;
    public override string Sequence => @"Oo·";
}
