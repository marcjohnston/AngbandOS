namespace AngbandOS.Core.MushroomFlavours;

[Serializable]
internal class YellowMushroomFlavour : MushroomFlavour
{
    private YellowMushroomFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => ',';
    public override Colour Colour => Colour.Yellow;
    public override string Name => "Yellow";
}
