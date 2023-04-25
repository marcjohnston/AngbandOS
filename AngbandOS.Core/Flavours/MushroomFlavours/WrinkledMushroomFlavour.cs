namespace AngbandOS.Core.Flavours;

[Serializable]
internal class WrinkledMushroomFlavour : MushroomFlavour
{
    private WrinkledMushroomFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => ',';
    public override Colour Colour => Colour.Brown;
    public override string Name => "Wrinkled";
}
