// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

/// <summary>
/// Represents the shell for an immutable single item attribute.  There are 6 variations of item characteristics that determine how the internal data type is defined and how the clone, merge and equals
/// operations are handled.
/// </summary>
[Serializable]
internal abstract class AttributeValue
{
    protected AttributeFactory Factory { get; }
    protected AttributeValue(AttributeFactory factory)
    {
        Factory = factory;
    }
    /// <summary>
    /// Returns a new instance of the item property with a copy/clone of the value.
    /// </summary>
    /// <returns></returns>
    public abstract AttributeValue Clone();

    public abstract AttributeValue Merge(AttributeValue itemProperty);

    public abstract bool IsEqual(AttributeValue itemProperty);
    public override string ToString()
    {
        return Enum.GetName(typeof(AttributeEnum), Factory.Index) ?? "";
    }

    #region Equality
    public override bool Equals(object? obj)
    {
        if (obj is not AttributeValue other)
        {
            return false;
        }

        return IsEqual(other);
    }

    public static bool operator ==(AttributeValue? left, AttributeValue? right)
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

    public static bool operator !=(AttributeValue? left, AttributeValue? right)
    {
        return !(left == right);
    }
    #endregion
}
