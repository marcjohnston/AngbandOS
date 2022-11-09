using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class GoldenStaffFlavour : StaffFlavour
{
    public override char Character => '_';
    public override Colour Colour => Colour.Gold;
    public override string Name => "Golden";
}
