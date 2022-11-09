using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class BambooStaffFlavour : StaffFlavour
{
    public override char Character => '_';
    public override Colour Colour => Colour.Yellow;
    public override string Name => "Bamboo";
}
