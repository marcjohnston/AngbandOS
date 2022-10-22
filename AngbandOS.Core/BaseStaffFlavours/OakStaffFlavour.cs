using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class OakStaffFlavour : BaseStaffFlavour
{
    public override char Character => '_';
    public override Colour Colour => Colour.Brown;
    public override string Name => "Oak";
}
