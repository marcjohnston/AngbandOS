namespace AngbandOS.Core.PotionFlavours;

[Serializable]
internal class IvoryWhitePotionFlavour : PotionFlavour
{
    private IvoryWhitePotionFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '!';
    public override Colour Colour => Colour.BrightBeige;
    public override string Name => "Ivory White";
}
