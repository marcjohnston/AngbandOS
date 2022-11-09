using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class MapleStaffFlavour : StaffFlavour
{
    public override char Character => '_';
    public override Colour Colour => Colour.Brown;
    public override string Name => "Maple";
}
