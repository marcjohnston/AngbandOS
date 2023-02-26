namespace AngbandOS.Core.PotionFlavours;

[Serializable]
internal class BubblingPotionFlavour : PotionFlavour
{
    private BubblingPotionFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '!';
    public override Colour Colour => Colour.Diamond;
    public override string Name => "Bubbling";
}
