namespace AngbandOS.Core.MushroomFlavours;

[Serializable]
internal class BlueMushroomFlavour : MushroomFlavour
{
    private BlueMushroomFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => ',';
    public override Colour Colour => Colour.Blue;
    public override string Name => "Blue";
}
