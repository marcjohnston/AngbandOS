using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class BrightPinkContractAnimation : Animation
{
    public override char Character => '*';
    public override Colour Colour => Colour.BrightPink;
    public override string Name => "BrightPinkContract";
    public override Colour AlternateColour => Colour.BrightPink;
    public override string Sequence => @"Oo·";
}
