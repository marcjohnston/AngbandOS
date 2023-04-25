namespace AngbandOS.Core.Flavours;

[Serializable]
internal class IckyGreenPotionFlavour : PotionFlavour
{
    private IckyGreenPotionFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '!';
    public override Colour Colour => Colour.BrightGreen;
    public override string Name => "Icky Green";
    /// <summary>
    /// Returns a shuffle weight of 1, so that it appears after the light brown potion, but before all other unweighted potions.
    /// </summary>
    public override int ShuffleWeight => 1;
}
