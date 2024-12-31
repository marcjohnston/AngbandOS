// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class RemoveCurseScript : Script, IScript, IScriptStore, ISuccessByChanceScript, IIdentifiedAndUsedScript
{
    private RemoveCurseScript(Game game) : base(game) { }

    /// <summary>
    /// Allows the player to purchase the remove curse for 500 gold.  Does not modify any of the store flags.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScriptStore(StoreCommandEvent storeCommandEvent)
    {
        if (!Game.ServiceHaggle(500, out int price))
        {
            if (price > Game.Gold.IntValue)
            {
                Game.MsgPrint("You do not have the gold!");
            }
            else
            {
                Game.Gold.IntValue -= price;
                Game.SayComment_1();
                Game.PlaySound(SoundEffectEnum.StoreTransaction);
                Game.StorePrtGold();
                ExecuteScript();
            }
            Game.HandleStuff();
        }
    }

    /// <summary>
    /// Removes a curse from all items, excluding a heavy curse and returns true if a curse was removed from any items; false, otherwise.
    /// </summary>
    /// <returns></returns>
    public bool ExecuteSuccessByChanceScript()
    {
        return Game.RemoveCurseAux(false);
    }

    /// <summary>
    /// Executes the successful script and disposes of the result.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        ExecuteSuccessByChanceScript();
    }

    public (bool identified, bool used) ExecuteIdentifiedAndUsedScript()
    {
        bool identified = ExecuteSuccessByChanceScript();
        if (identified)
        {
            if (Game.BlindnessTimer.Value == 0)
            {
                Game.MsgPrint("The staff glows blue for a moment...");
            }
            return (true, true);
        }
        return (false, true);
    }
}
