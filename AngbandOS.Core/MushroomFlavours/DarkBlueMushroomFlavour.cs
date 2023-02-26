namespace AngbandOS.Core.MushroomFlavours;

[Serializable]
internal class DarkBlueMushroomFlavour : MushroomFlavour
{
    private DarkBlueMushroomFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => ',';
    public override Colour Colour => Colour.Blue;
    public override string Name => "Dark Blue";
}
