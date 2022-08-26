using AngbandOS.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class MahoganyStaffFlavour : BaseStaffFlavour
{
    public override char Character => '_';
    public override Colour Colour => Colour.Brown;
    public override string Name => "Mahogany";
}
