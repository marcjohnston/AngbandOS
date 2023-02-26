namespace AngbandOS.Core.PotionFlavours;

[Serializable]
internal class BrownSpeckledPotionFlavour : PotionFlavour
{
    private BrownSpeckledPotionFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '!';
    public override Colour Colour => Colour.BrightBrown;
    public override string Name => "Brown Speckled";
}
