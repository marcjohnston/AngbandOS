namespace AngbandOS.Core.Flavours;

[Serializable]
internal class LightBrownPotionFlavour : PotionFlavour
{
    private LightBrownPotionFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '!';
    public override Colour Colour => Colour.BrightBrown;
    public override string Name => "Light Brown";
    /// <summary>
    /// Returns a shuffle weight of 2, so that it appears after the clear potion, but before the light brown potion flavour.
    /// </summary>
    public override int ShuffleWeight => 2;
}
