using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class RedContractAnimation : Animation
{
    public override char Character => '*';
    public override Colour Colour => Colour.Red;
    public override string Name => "RedContract";
    public override Colour AlternateColour => Colour.Red;
    public override string Sequence => @"Oo·";
}
