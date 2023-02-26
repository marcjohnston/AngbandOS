namespace AngbandOS.Core.MushroomFlavours;

[Serializable]
internal class GreenMushroomFlavour : MushroomFlavour
{
    private GreenMushroomFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => ',';
    public override Colour Colour => Colour.Green;
    public override string Name => "Green";
}
