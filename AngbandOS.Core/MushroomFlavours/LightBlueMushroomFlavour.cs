namespace AngbandOS.Core.MushroomFlavours;

[Serializable]
internal class LightBlueMushroomFlavour : MushroomFlavour
{
    private LightBlueMushroomFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => ',';
    public override Colour Colour => Colour.BrightBlue;
    public override string Name => "Light Blue";
}
