﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class ResearchItemScript : Script, IScript, IStoreScript
{
    private ResearchItemScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the research item script.  Does not modify any of the store flags.
    /// </summary>
    /// <returns></returns>
    public void ExecuteStoreScript(StoreCommandEvent storeCommandEvent)
    {
        ExecuteScript();
    }

    /// <summary>
    /// Executes the research item script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        if (!Game.ServiceHaggle(2000, out int price))
        {
            if (price > Game.Gold.Value)
            {
                Game.MsgPrint("You do not have the gold!");
            }
            else
            {
                Game.Gold.Value -= price;
                Game.SayComment_1();
                Game.PlaySound(SoundEffectEnum.StoreTransaction);
                Game.StorePrtGold();
                Game.RunScript(nameof(IdentifyItemFullyScript));
            }
            Game.HandleStuff();
        }
    }
}