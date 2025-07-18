// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

/// <summary>
/// Represents the shell for a single item characteristic.  There are 6 variations of item characteristics that determine how the internal data type is defined and how the clone, merge and equals
/// operations are handled.
/// </summary>
[Serializable]
internal abstract class ItemProperty
{
    /// <summary>
    /// Returns a new instance of the item property with a copy/clone of the value.
    /// </summary>
    /// <returns></returns>
    public abstract ItemProperty Clone();

    public abstract ItemProperty Override(ItemProperty itemProperty);

    public abstract ItemProperty Merge(ItemProperty itemProperty);

    public abstract bool IsEqual(ItemProperty itemProperty);

    /// <summary>
    /// Returns the index into the <see cref="ItemPropertySet.ItemProperties"/> array that this property occupies.
    /// </summary>
    public readonly int Index;

    /// <summary>
    /// Constructs a new <see cref="ItemProperty"/>.
    /// </summary>
    /// <param name="index"></param>
    public ItemProperty(int index)
    {
        Index = index;
    }

    #region Equality
    public override bool Equals(object? obj)
    {
        if (obj is not ItemProperty other)
        {
            return false;
        }

        return IsEqual(other);
    }

    public static bool operator ==(ItemProperty? left, ItemProperty? right)
    {
        if (ReferenceEquals(left, right))
        {
            return true;
        }
        if (left is null || right is null)
        {
            return false;
        }

        return left.Equals(right);
    }

    public static bool operator !=(ItemProperty? left, ItemProperty? right)
    {
        return !(left == right);
    }
    #endregion
}
