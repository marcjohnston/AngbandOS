using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class GoldPlatedRodFlavour : RodFlavour
{
    public override char Character => '-';
    public override Colour Colour => Colour.Gold;
    public override string Name => "Gold-Plated";
}