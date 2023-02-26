namespace AngbandOS.Core.StaffFlavours;

[Serializable]
internal class CedarStaffFlavour : StaffFlavour
{
    private CedarStaffFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '_';
    public override Colour Colour => Colour.Brown;
    public override string Name => "Cedar";
}
