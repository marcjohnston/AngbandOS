namespace AngbandOS.Core.PotionFlavours;

[Serializable]
internal class TangerinePotionFlavour : PotionFlavour
{
    private TangerinePotionFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '!';
    public override Colour Colour => Colour.Orange;
    public override string Name => "Tangerine";
}
