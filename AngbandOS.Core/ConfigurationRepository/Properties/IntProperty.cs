﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Properties;

[Serializable]
internal abstract class IntProperty : Property, IIntChangeTrackable
{
    protected IntProperty(SaveGame saveGame) : base(saveGame) { }

    private int _value;
    public int Value
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
            Set();

            // Allow derived classes to perform additional after set functionality.
            OnAfterSet();
        }
    }


    protected virtual void OnBeforeSet() { }
    protected virtual void OnAfterSet() { }

    public override string ToString()
    {
        return _value.ToString();
    }
}