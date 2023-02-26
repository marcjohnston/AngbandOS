namespace AngbandOS.Core.MushroomFlavours;

[Serializable]
internal class WhiteSpottedMushroomFlavour : MushroomFlavour
{
    private WhiteSpottedMushroomFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => ',';
    public override Colour Colour => Colour.Silver;
    public override string Name => "White Spotted";
}
