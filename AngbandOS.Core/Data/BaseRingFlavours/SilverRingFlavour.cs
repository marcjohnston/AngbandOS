using AngbandOS.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class SilverRingFlavour : BaseRingFlavour
{
    public override char Character => '=';
    public override Colour Colour => Colour.Silver;
    public override string Name => "Silver";
}
