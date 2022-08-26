using AngbandOS.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class RunedStaffFlavour : BaseStaffFlavour
{
    public override char Character => '_';
    public override Colour Colour => Colour.Purple;
    public override string Name => "Runed";
}
