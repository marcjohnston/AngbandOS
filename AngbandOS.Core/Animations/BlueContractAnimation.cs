using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class BlueContractAnimation : Animation
{
    public override char Character => '*';
    public override Colour Colour => Colour.Blue;
    public override string Name => "BlueContract";
    public override Colour AlternateColour => Colour.Blue;
    public override string Sequence => @"Oo·";
}