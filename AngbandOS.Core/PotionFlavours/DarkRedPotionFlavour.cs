namespace AngbandOS.Core.PotionFlavours;

[Serializable]
internal class DarkRedPotionFlavour : PotionFlavour
{
    private DarkRedPotionFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '!';
    public override Colour Colour => Colour.Red;
    public override string Name => "Dark Red";
}
