namespace AngbandOS.Core.PotionFlavours;

[Serializable]
internal class MetallicGreenPotionFlavour : PotionFlavour
{
    private MetallicGreenPotionFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '!';
    public override Colour Colour => Colour.BrightGreen;
    public override string Name => "Metallic Green";
}
