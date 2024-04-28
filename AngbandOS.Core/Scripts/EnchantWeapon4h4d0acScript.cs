// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class EnchantWeapon4h4d0acScript : Script, IScript, IScriptStore, ISuccessfulScript
{
    private EnchantWeapon4h4d0acScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the enchant weapon script.  Does not modify any of the store flags.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScriptStore(StoreCommandEvent storeCommandEvent)
    {
        if (!Game.ServiceHaggle(800, out int price))
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

    public bool ExecuteSuccessfulScript()
    {
        return Game.EnchantItem(4, 4, 0);
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
