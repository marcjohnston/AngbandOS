namespace AngbandOS.Core.Flavours;

[Serializable]
internal class GreyMushroomFlavour : MushroomFlavour
{
    private GreyMushroomFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => ',';
    public override Colour Colour => Colour.Grey;
    public override string Name => "Grey";
}
