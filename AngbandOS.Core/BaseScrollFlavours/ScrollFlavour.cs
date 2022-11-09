using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class ScrollFlavour
{
    /// <summary>
    /// The column from which to take the graphical tile.
    /// </summary>
    public char Character;

    /// <summary>
    /// The row from which to take the graphical tile
    /// </summary>
    public Colour Colour;

    /// <summary>
    /// A unique identifier for the entity.
    /// </summary>
    public string Name;
}
