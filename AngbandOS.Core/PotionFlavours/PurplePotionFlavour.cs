namespace AngbandOS.Core.PotionFlavours;

[Serializable]
internal class PurplePotionFlavour : PotionFlavour
{
    private PurplePotionFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '!';
    public override Colour Colour => Colour.Purple;
    public override string Name => "Purple";
}
