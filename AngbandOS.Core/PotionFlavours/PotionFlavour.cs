namespace AngbandOS.Core.PotionFlavours;

[Serializable]
internal abstract class PotionFlavour : IWeightedShuffle
{
    protected SaveGame SaveGame;
    protected PotionFlavour(SaveGame saveGame)
    {
        SaveGame = saveGame;
    }

    /// <summary>
    /// The column from which to take the graphical tile.
    /// </summary>
    public abstract char Character { get; }

    /// <summary>
    /// The row from which to take the graphical tile
    /// </summary>
    public virtual Colour Colour => Colour.White;

    /// <summary>
    /// A unique identifier for the entity
    /// </summary>
    public abstract string Name { get; }

    /// <summary>
    /// Returns the shuffle weight for the potion flavour.  Potion flavours of a higher weight will appear before potion flavours of a lower weight.  Returns 0, by default.
    /// </summary>
    public virtual int ShuffleWeight => 0;

    public override string ToString()
    {
        return Name;
    }
}
