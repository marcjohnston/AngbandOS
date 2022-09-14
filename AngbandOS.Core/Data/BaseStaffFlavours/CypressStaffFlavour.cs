using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class CypressStaffFlavour : BaseStaffFlavour
{
    public override char Character => '_';
    public override Colour Colour => Colour.Brown;
    public override string Name => "Cypress";
}
