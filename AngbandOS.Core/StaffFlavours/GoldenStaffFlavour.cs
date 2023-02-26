namespace AngbandOS.Core.StaffFlavours;

[Serializable]
internal class GoldenStaffFlavour : StaffFlavour
{
    private GoldenStaffFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '_';
    public override Colour Colour => Colour.Gold;
    public override string Name => "Golden";
}
