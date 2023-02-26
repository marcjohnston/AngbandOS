namespace AngbandOS.Core.PotionFlavours;

[Serializable]
internal class HazyPotionFlavour : PotionFlavour
{
    private HazyPotionFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '!';
    public override Colour Colour => Colour.Grey;
    public override string Name => "Hazy";
}
