namespace AngbandOS.Core.MushroomFlavours;

[Serializable]
internal class DarkGreenMushroomFlavour : MushroomFlavour
{
    private DarkGreenMushroomFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => ',';
    public override Colour Colour => Colour.Green;
    public override string Name => "Dark Green";
}
