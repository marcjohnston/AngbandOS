namespace AngbandOS.Core.StaffFlavours;

[Serializable]
internal class HickoryStaffFlavour : StaffFlavour
{
    private HickoryStaffFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '_';
    public override Colour Colour => Colour.Brown;
    public override string Name => "Hickory";
}
