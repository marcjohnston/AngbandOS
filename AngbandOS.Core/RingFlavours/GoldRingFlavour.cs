using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class GoldRingFlavour : RingFlavour
{
    public override char Character => '=';
    public override Colour Colour => Colour.Gold;
    public override string Name => "Gold";
}
