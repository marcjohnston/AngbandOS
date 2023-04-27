namespace AngbandOS.Core.Flavours;

/// <summary>
/// Represents a single flavour for a group of items that participate in the IFlavour interface.
/// </summary>
[Serializable]
internal abstract class Flavour
{
    protected SaveGame SaveGame;
    protected Flavour(SaveGame saveGame)
    {
        SaveGame = saveGame;
    }

    /// <summary>
    /// The character to use for the visual.
    /// </summary>
    public abstract char Character { get; }

    /// <summary>
    /// The color to use for the visual.
    /// </summary>
    public virtual Colour Colour => Colour.White;

    /// <summary>
    /// A unique identifier for the inscription.
    /// </summary>
    public abstract string Name { get; }

    public override string ToString()
    {
        return Name;
    }
}
