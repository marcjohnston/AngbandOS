namespace AngbandOS.Core.PotionFlavours;

[Serializable]
internal class MetallicRedPotionFlavour : PotionFlavour
{
    private MetallicRedPotionFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '!';
    public override Colour Colour => Colour.BrightRed;
    public override string Name => "Metallic Red";
}
