﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Properties;

/// <summary>
/// Represents a property that is used to track when the map needs to be refreshed.  This property is only used to flag a manual refreshing until the <see cref="RefreshMapFunction"/>
/// function has all dependencies setup properly.
/// </summary>
[Serializable]
internal class RefreshMapProperty : Property, IMapChangeTracking // TODO: This property has a meaningless value property and should be 
{
    private RefreshMapProperty(Game game) : base(game) { } // This object is a singleton.

    public new void SetChangedFlag() 
    {
        base.SetChangedFlag();
    }
}