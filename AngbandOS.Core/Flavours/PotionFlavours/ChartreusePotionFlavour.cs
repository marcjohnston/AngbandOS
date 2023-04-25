namespace AngbandOS.Core.Flavours;

[Serializable]
internal class ChartreusePotionFlavour : PotionFlavour
{
    private ChartreusePotionFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '!';
    public override Colour Colour => Colour.Chartreuse;
    public override string Name => "Chartreuse";
}
