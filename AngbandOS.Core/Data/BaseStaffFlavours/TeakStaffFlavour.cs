using AngbandOS.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class TeakStaffFlavour : BaseStaffFlavour
{
    public override char Character => '_';
    public override Colour Colour => Colour.Brown;
    public override string Name => "Teak";
}
