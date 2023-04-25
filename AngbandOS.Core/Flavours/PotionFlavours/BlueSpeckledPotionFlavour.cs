namespace AngbandOS.Core.Flavours;

[Serializable]
internal class BlueSpeckledPotionFlavour : PotionFlavour
{
    private BlueSpeckledPotionFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '!';
    public override Colour Colour => Colour.Blue;
    public override string Name => "Blue Speckled";
}
