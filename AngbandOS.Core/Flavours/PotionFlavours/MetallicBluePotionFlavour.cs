namespace AngbandOS.Core.Flavours;

[Serializable]
internal class MetallicBluePotionFlavour : PotionFlavour
{
    private MetallicBluePotionFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '!';
    public override Colour Colour => Colour.BrightBlue;
    public override string Name => "Metallic Blue";
}
