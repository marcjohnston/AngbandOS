﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Interfaces;

/// <summary>
/// Represents the interface a script needs to implement for it available when the player is in a store.
/// </summary>
internal interface IStoreCommandScript
{
    void ExecuteStoreCommandScript(StoreCommandEvent storeCommandEvent);
}
