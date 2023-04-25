namespace AngbandOS.Core.Flavours;

[Serializable]
internal class CypressStaffFlavour : StaffFlavour
{
    private CypressStaffFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '_';
    public override Colour Colour => Colour.Brown;
    public override string Name => "Cypress";
}
