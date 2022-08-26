using AngbandOS.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class IronwoodStaffFlavour : BaseStaffFlavour
{
    public override char Character => '_';
    public override Colour Colour => Colour.Grey;
    public override string Name => "Ironwood";
}
