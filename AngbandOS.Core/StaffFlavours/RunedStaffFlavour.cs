namespace AngbandOS.Core.StaffFlavours;

[Serializable]
internal class RunedStaffFlavour : StaffFlavour
{
    private RunedStaffFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '_';
    public override Colour Colour => Colour.Purple;
    public override string Name => "Runed";
}
