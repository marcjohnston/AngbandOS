namespace AngbandOS.Core.PotionFlavours;

[Serializable]
internal class MetallicPurplePotionFlavour : PotionFlavour
{
    private MetallicPurplePotionFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '!';
    public override Colour Colour => Colour.Purple;
    public override string Name => "Metallic Purple";
}
