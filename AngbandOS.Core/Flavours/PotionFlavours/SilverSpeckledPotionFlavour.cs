namespace AngbandOS.Core.Flavours;

[Serializable]
internal class SilverSpeckledPotionFlavour : PotionFlavour
{
    private SilverSpeckledPotionFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '!';
    public override Colour Colour => Colour.Silver;
    public override string Name => "Silver Speckled";
}
