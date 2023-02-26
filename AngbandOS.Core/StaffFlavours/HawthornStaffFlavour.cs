namespace AngbandOS.Core.StaffFlavours;

[Serializable]
internal class HawthornStaffFlavour : StaffFlavour
{
    private HawthornStaffFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '_';
    public override Colour Colour => Colour.Brown;
    public override string Name => "Hawthorn";
}
