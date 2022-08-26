using Cthangband.Enumerations;

namespace AngbandOS.Core;

[Serializable]
internal class WeddingRingFlavour : BaseRingFlavour
{
    public override char Character => '=';
    public override Colour Colour => Colour.Gold;
    public override string Name => "Wedding";
}
