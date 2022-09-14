using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class SpruceStaffFlavour : BaseStaffFlavour
{
    public override char Character => '_';
    public override Colour Colour => Colour.BrightBrown;
    public override string Name => "Spruce";
}
