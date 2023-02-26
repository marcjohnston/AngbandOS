namespace AngbandOS.Core.PotionFlavours;

[Serializable]
internal class PinkSpeckledPotionFlavour : PotionFlavour
{
    private PinkSpeckledPotionFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '!';
    public override Colour Colour => Colour.BrightPink;
    public override string Name => "Pink Speckled";
}
