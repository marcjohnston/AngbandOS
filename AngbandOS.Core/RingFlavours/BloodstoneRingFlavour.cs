using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class BloodstoneRingFlavour : RingFlavour
{
    public override char Character => '=';
    public override Colour Colour => Colour.Red;
    public override string Name => "Bloodstone";
}
