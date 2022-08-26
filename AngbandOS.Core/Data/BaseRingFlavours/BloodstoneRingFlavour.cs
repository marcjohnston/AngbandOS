using Cthangband.Enumerations;

namespace AngbandOS.Core;

[Serializable]
internal class BloodstoneRingFlavour : BaseRingFlavour
{
    public override char Character => '=';
    public override Colour Colour => Colour.Red;
    public override string Name => "Bloodstone";
}
