using AngbandOS.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class MulberryStaffFlavour : BaseStaffFlavour
{
    public override char Character => '_';
    public override Colour Colour => Colour.BrightBrown;
    public override string Name => "Mulberry";
}
