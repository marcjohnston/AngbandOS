namespace AngbandOS.Core.MushroomFlavours;

[Serializable]
internal class LightGreenMushroomFlavour : MushroomFlavour
{
    private LightGreenMushroomFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => ',';
    public override Colour Colour => Colour.BrightGreen;
    public override string Name => "Light Green";
}
