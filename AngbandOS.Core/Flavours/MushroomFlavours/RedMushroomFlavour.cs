namespace AngbandOS.Core.Flavours;

[Serializable]
internal class RedMushroomFlavour : MushroomFlavour
{
    private RedMushroomFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => ',';
    public override Colour Colour => Colour.BrightRed;
    public override string Name => "Red";
}
