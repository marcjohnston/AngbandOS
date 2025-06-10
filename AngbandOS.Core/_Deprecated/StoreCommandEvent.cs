// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.EventsArgs;

internal class StoreCommandEvent
{
    public Store Store { get; }

    /// <summary>
    /// Return true, if the store needs to rerender the inventory because the command used the screen.  Returns false, by default.
    /// </summary>
    public bool RequiresRerendering = false;

    /// <summary>
    /// Return true, if the player leaves the store.  Returns false, by default.
    /// </summary>
    public bool LeaveStore = false;

    public StoreCommandEvent(Store store)
    {
        Store = store;
    }
}