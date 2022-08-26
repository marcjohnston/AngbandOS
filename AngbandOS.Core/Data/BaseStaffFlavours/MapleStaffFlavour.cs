using AngbandOS.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class MapleStaffFlavour : BaseStaffFlavour
{
    public override char Character => '_';
    public override Colour Colour => Colour.Brown;
    public override string Name => "Maple";
}
