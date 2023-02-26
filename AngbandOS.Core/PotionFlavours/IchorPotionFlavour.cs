namespace AngbandOS.Core.PotionFlavours;

[Serializable]
internal class IchorPotionFlavour : PotionFlavour
{
    private IchorPotionFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '!';
    public override Colour Colour => Colour.Black;
    public override string Name => "Ichor";
}
