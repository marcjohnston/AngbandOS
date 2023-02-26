namespace AngbandOS.Core.MushroomFlavours;

[Serializable]
internal class VioletMushroomFlavour : MushroomFlavour
{
    private VioletMushroomFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => ',';
    public override Colour Colour => Colour.BrightPurple;
    public override string Name => "Violet";
}
