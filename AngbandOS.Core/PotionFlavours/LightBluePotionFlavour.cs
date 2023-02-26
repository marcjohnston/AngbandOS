namespace AngbandOS.Core.PotionFlavours;

[Serializable]
internal class LightBluePotionFlavour : PotionFlavour
{
    private LightBluePotionFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '!';
    public override Colour Colour => Colour.BrightBlue;
    public override string Name => "Light Blue";
}
