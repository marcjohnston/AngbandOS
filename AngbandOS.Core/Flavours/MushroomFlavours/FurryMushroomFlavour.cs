namespace AngbandOS.Core.Flavours;

[Serializable]
internal class FurryMushroomFlavour : MushroomFlavour
{
    private FurryMushroomFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => ',';
    public override Colour Colour => Colour.BrightOrange;
    public override string Name => "Furry";
}
