namespace AngbandOS.Core.PotionFlavours;

[Serializable]
internal class OrangeSpeckledPotionFlavour : PotionFlavour
{
    private OrangeSpeckledPotionFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '!';
    public override Colour Colour => Colour.Orange;
    public override string Name => "Orange Speckled";
}
