namespace AngbandOS.Core.PotionFlavours;

[Serializable]
internal class GloopyGreenPotionFlavour : PotionFlavour
{
    private GloopyGreenPotionFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '!';
    public override Colour Colour => Colour.Green;
    public override string Name => "Gloopy Green";
}
