// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.StoreCommands;

[Serializable]
internal class ScrollItemsStoreCommand : StoreCommand
{
    private ScrollItemsStoreCommand(SaveGame saveGame) : base(saveGame) { }
    public override char KeyChar => ';';

    /// <summary>
    /// Returns the text to render, if the store command is advertised.
    /// </summary>
    public override string Description => "";

    public override void Execute(StoreCommandEvent storeCommandEvent)
    {
        char ch = SaveGame.Inkey(true);
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

