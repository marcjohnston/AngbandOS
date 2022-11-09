using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class IronwoodStaffFlavour : StaffFlavour
{
    public override char Character => '_';
    public override Colour Colour => Colour.Grey;
    public override string Name => "Ironwood";
}
