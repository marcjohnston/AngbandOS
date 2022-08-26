using AngbandOS.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class GoldRingFlavour : BaseRingFlavour
{
    public override char Character => '=';
    public override Colour Colour => Colour.Gold;
    public override string Name => "Gold";
}
