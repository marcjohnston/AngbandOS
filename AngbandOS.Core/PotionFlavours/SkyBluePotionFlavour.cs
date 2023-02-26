namespace AngbandOS.Core.PotionFlavours;

[Serializable]
internal class SkyBluePotionFlavour : PotionFlavour
{
    private SkyBluePotionFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '!';
    public override Colour Colour => Colour.BrightBlue;
    public override string Name => "Sky Blue";
}
