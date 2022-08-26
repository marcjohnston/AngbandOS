using AngbandOS.Interface;

namespace AngbandOS.Core;

[Serializable]
internal abstract class BasePotionFlavour
{
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

    public override string ToString()
    {
        return Name;
    }
}
