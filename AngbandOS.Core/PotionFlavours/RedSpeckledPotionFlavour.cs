namespace AngbandOS.Core.PotionFlavours;

[Serializable]
internal class RedSpeckledPotionFlavour : PotionFlavour
{
    private RedSpeckledPotionFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '!';
    public override Colour Colour => Colour.BrightRed;
    public override string Name => "Red Speckled";
}
