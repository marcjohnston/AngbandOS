namespace AngbandOS.Core.PotionFlavours;

[Serializable]
internal class VioletSpeckledPotionFlavour : PotionFlavour
{
    private VioletSpeckledPotionFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '!';
    public override Colour Colour => Colour.Purple;
    public override string Name => "Violet Speckled";
}
