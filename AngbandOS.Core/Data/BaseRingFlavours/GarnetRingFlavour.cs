using Cthangband.Enumerations;

namespace AngbandOS.Core;

[Serializable]
internal class GarnetRingFlavour : BaseRingFlavour
{
    public override char Character => '=';
    public override Colour Colour => Colour.Red;
    public override string Name => "Garnet";
}
