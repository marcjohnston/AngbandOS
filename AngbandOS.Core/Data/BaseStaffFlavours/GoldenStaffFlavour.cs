using AngbandOS.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class GoldenStaffFlavour : BaseStaffFlavour
{
    public override char Character => '_';
    public override Colour Colour => Colour.Gold;
    public override string Name => "Golden";
}
