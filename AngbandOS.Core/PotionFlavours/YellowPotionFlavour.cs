namespace AngbandOS.Core.PotionFlavours;

[Serializable]
internal class YellowPotionFlavour : PotionFlavour
{
    private YellowPotionFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '!';
    public override Colour Colour => Colour.Yellow;
    public override string Name => "Yellow";
}
