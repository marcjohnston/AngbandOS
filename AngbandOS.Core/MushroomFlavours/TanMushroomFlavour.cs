namespace AngbandOS.Core.MushroomFlavours;

[Serializable]
internal class TanMushroomFlavour : MushroomFlavour
{
    private TanMushroomFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => ',';
    public override Colour Colour => Colour.BrightBrown;
    public override string Name => "Tan";
}
