using AngbandOS.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class BalsaStaffFlavour : BaseStaffFlavour
{
    public override char Character => '_';
    public override Colour Colour => Colour.Beige;
    public override string Name => "Balsa";
}
