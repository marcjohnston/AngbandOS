namespace AngbandOS.Core.PotionFlavours;

[Serializable]
internal class GreenSpeckledPotionFlavour : PotionFlavour
{
    private GreenSpeckledPotionFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '!';
    public override Colour Colour => Colour.Green;
    public override string Name => "Green Speckled";
}
