namespace AngbandOS.Core.Flavours;

[Serializable]
internal class MistletoeStaffFlavour : StaffFlavour
{
    private MistletoeStaffFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '_';
    public override Colour Colour => Colour.BrightBrown;
    public override string Name => "Mistletoe";
}