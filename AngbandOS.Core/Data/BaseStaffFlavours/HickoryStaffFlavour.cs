using Cthangband.Enumerations;

namespace AngbandOS.Core;

[Serializable]
internal class HickoryStaffFlavour : BaseStaffFlavour
{
    public override char Character => '_';
    public override Colour Colour => Colour.Brown;
    public override string Name => "Hickory";
}
