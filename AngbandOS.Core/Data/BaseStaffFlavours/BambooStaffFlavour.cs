using AngbandOS.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class BambooStaffFlavour : BaseStaffFlavour
{
    public override char Character => '_';
    public override Colour Colour => Colour.Yellow;
    public override string Name => "Bamboo";
}
