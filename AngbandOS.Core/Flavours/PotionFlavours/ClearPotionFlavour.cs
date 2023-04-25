namespace AngbandOS.Core.Flavours;

[Serializable]
internal class ClearPotionFlavour : PotionFlavour
{
    private ClearPotionFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '!';
    public override string Name => "Clear";
    /// <summary>
    /// Returns a shuffle weight of 3, so that it appears first.
    /// </summary>
    public override int ShuffleWeight => 3;
}
