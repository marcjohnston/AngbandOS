// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Properties;

/// <summary>
/// Represents a property that includes change tracking for a nullable monster.
/// </summary>
[Serializable]
internal abstract class NullableMonsterProperty : Property, INullMonsterValue
{
    protected NullableMonsterProperty(Game game) : base(game) { }

    private Monster? _value;

    public Monster? Value
    {
        get
        {
            return _value;
        }
        set
        {
            // TODO: Currently there is no detection that the value is actually changing.  This allows us to use the Gold = Gold to set the flag for FlaggedActions compatability
            // Allow derived classes to perform additional after set functionality.
            OnBeforeSet();

            _value = value;

            // Call the set method for the base Property class.
            SetChangedFlag();

            // Allow derived classes to perform additional after set functionality.
            OnAfterSet();
        }
    }

    public Monster? NullMonsterValue => Value;

    protected virtual void OnBeforeSet() { }
    protected virtual void OnAfterSet() { }


    /// <summary>
    /// Returns a string representation of the property value.
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return _value == null ? "" : _value.Race.FriendlyName;
    }
}
