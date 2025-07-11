﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Scripts;

[Serializable]
internal class ScrollStoreInventoryScript : Script, IStoreCommandScript
{
    private ScrollStoreInventoryScript(Game game) : base(game) { }

    /// <summary>
    /// Scrolls the store inventory script up or down one item or one page.  Does not modify any of the store flags.
    /// </summary>
    /// <returns></returns>
    public void ExecuteStoreCommandScript(StoreCommandEvent storeCommandEvent)
    {
        char ch = Game.Inkey(true);
        switch (ch)
        {
            case '9':
                storeCommandEvent.Store.PageUp();
                break;
            case '3':
                storeCommandEvent.Store.PageDown();
                break;
            case '8':
                storeCommandEvent.Store.ScrollUp();
                break;
            case '2':
                storeCommandEvent.Store.ScrollDown();
                break;
        }
    }
}
