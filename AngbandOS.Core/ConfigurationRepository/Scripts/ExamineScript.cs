// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class ExamineScript : Script, IScript, IRepeatableScript, IStoreScript
{
    private ExamineScript(SaveGame saveGame) : base(saveGame) { }

    /// <summary>
    /// Executes the examine script.  Does not modify any of the store flags.
    /// </summary>
    /// <returns></returns>
    public void ExecuteStoreScript(StoreCommandEvent storeCommandEvent)
    {
        ExecuteScript();
    }

    /// <summary>
    /// Executes the examine script and returns false.
    /// </summary>
    /// <returns></returns>
    public bool ExecuteRepeatableScript()
    {
        ExecuteScript();
        return false;
    }

    /// <summary>
    /// Executes the examine script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        // Get the item to examine
        if (!SaveGame.SelectItem(out Item? item, "Examine which item? ", true, true, true, null))
        {
            SaveGame.MsgPrint("You have nothing to examine.");
            return;
        }
        if (item == null)
        {
            return;
        }
        // Do we know anything about it?
        if (!item.IdentMental)
        {
            SaveGame.MsgPrint("You have no special knowledge about that item.");
            return;
        }
        string itemName = item.Description(true, 3);
        SaveGame.MsgPrint($"Examining {itemName}...");
        // We're not actually identifying it, because it's already itentified, but we want to
        // repeat the identification text
        if (!item.IdentifyFully())
        {
            SaveGame.MsgPrint("You see nothing special.");
        }
    }
}
