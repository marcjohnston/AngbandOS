namespace AngbandOS.Core.PotionFlavours;

[Serializable]
internal class LightBrownPotionFlavour : PotionFlavour
{
    private LightBrownPotionFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '!';
    public override Colour Colour => Colour.BrightBrown;
    public override string Name => "Light Brown";
}
