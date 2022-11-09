using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class SilverContractAnimation : Animation
{
    public override char Character => '*';
    public override Colour Colour => Colour.Silver;
    public override string Name => "SilverContract";
    public override Colour AlternateColour => Colour.Silver;
    public override string Sequence => @"Oo·";
}
