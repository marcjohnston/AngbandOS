using Cthangband.Enumerations;

namespace AngbandOS.Core;

[Serializable]
internal class HawthornStaffFlavour : BaseStaffFlavour
{
    public override char Character => '_';
    public override Colour Colour => Colour.Brown;
    public override string Name => "Hawthorn";
}
