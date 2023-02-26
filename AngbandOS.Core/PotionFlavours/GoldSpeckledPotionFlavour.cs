namespace AngbandOS.Core.PotionFlavours;

[Serializable]
internal class GoldSpeckledPotionFlavour : PotionFlavour
{
    private GoldSpeckledPotionFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '!';
    public override Colour Colour => Colour.BrightYellow;
    public override string Name => "Gold Speckled";
}
