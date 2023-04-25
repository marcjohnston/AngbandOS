namespace AngbandOS.Core.Flavours;

[Serializable]
internal class RedwoodStaffFlavour : StaffFlavour
{
    private RedwoodStaffFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '_';
    public override Colour Colour => Colour.Red;
    public override string Name => "Redwood";
}
