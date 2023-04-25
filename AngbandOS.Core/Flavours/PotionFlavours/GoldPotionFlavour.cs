namespace AngbandOS.Core.Flavours;

[Serializable]
internal class GoldPotionFlavour : PotionFlavour
{
    private GoldPotionFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '!';
    public override Colour Colour => Colour.Gold;
    public override string Name => "Gold";
}
