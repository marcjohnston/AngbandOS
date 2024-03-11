// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class RestInStoreScript : Script, IScript, IStoreScript
{
    private RestInStoreScript(SaveGame saveGame) : base(saveGame) { }

    /// <summary>
    /// Executes the rest in store script.  Does not modify any of the store flags.
    /// </summary>
    /// <returns></returns>
    public void ExecuteStoreScript(StoreCommandEvent storeCommandEvent)
    {
        ExecuteScript();
    }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        if (SaveGame.PoisonTimer.Value > 0 || SaveGame.TimedBleeding.Value > 0)
        {
            SaveGame.MsgPrint("Your wounds prevent you from sleeping.");
        }
        else
        {
            SaveGame.RunScript(nameof(RestInRoomScript));
        }
    }
}
