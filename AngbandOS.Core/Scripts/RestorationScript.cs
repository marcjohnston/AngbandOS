// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class RestorationScript : Script, IScript, IStoreScript
{
    private RestorationScript(Game game) : base(game) { }

    /// <summary>
    /// Allows the player to purchase the restoration for 750 gold.  Does not modify any of the store flags.
    /// </summary>
    /// <returns></returns>
    public void ExecuteStoreScript(StoreCommandEvent storeCommandEvent)
    {
        if (!Game.ServiceHaggle(750, out int price))
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
    /// Restores all statistics and experience.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        Game.RunScript(nameof(RestoreBodyScript));
        Game.RunScript(nameof(RestoreLevelScript));
    }
}
