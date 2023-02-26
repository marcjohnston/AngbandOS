namespace AngbandOS.Core.MushroomFlavours;

[Serializable]
internal class BlackMushroomFlavour : MushroomFlavour
{
    private BlackMushroomFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => ',';
    public override Colour Colour => Colour.Black;
    public override string Name => "Black";
}
