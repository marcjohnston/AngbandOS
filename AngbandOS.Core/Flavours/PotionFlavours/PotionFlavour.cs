namespace AngbandOS.Core.Flavours;

[Serializable]
internal abstract class PotionFlavour : Flavour, IWeightedShuffle
{
    protected PotionFlavour(SaveGame saveGame) : base(saveGame)
    {
    }

    /// <summary>
    /// Returns the shuffle weight for the potion flavour.  Potion flavours of a higher weight will appear before potion flavours of a lower weight.  Returns 0, by default.  The default
    /// value will be overriden by the Clear, IckyGreen and LightBrown flavours.
    /// </summary>
    public virtual int ShuffleWeight => 0;
}
