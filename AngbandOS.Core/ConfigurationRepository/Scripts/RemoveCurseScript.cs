// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class RemoveCurseScript : Script, IScript, IStoreScript, ISuccessfulScript
{
    private RemoveCurseScript(SaveGame saveGame) : base(saveGame) { }

    /// <summary>
    /// Allows the player to purchase the remove curse for 500 gold.  Does not modify any of the store flags.
    /// </summary>
    /// <returns></returns>
    public void ExecuteStoreScript(StoreCommandEvent storeCommandEvent)
    {
        if (!SaveGame.ServiceHaggle(500, out int price))
        {
            if (price > SaveGame.Gold)
            {
                SaveGame.MsgPrint("You do not have the gold!");
            }
            else
            {
                SaveGame.Gold -= price;
                SaveGame.SayComment_1();
                SaveGame.PlaySound(SoundEffectEnum.StoreTransaction);
                SaveGame.StorePrtGold();
                ExecuteScript();
            }
            SaveGame.HandleStuff();
        }
    }

    /// <summary>
    /// Removes a curse from all items, excluding a heavy curse and returns true if a curse was removed from any items; false, otherwise.
    /// </summary>
    /// <returns></returns>
    public bool ExecuteSuccessfulScript()
    {
        return SaveGame.RemoveCurseAux(false);
    }

    /// <summary>
    /// Executes the successful script and disposes of the result.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        ExecuteSuccessfulScript();
    }
}
