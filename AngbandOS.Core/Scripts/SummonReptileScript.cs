﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class SummonReptileScript : Script, IScript
{
    private SummonReptileScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        Game.MsgPrint("You concentrate on the image of a reptile...");
        if (Game.DieRoll(5) > 2)
        {
            if (!Game.SummonSpecificFriendly(Game.MapY.Value, Game.MapX.Value, Game.ExperienceLevel.Value, Game.SingletonRepository.MonsterFilters.Get(nameof(HydraMonsterFilter)), true))
            {
                Game.MsgPrint("No-one ever turns up.");
            }
        }
        else if (Game.SummonSpecific(Game.MapY.Value, Game.MapX.Value, Game.ExperienceLevel.Value, Game.SingletonRepository.MonsterFilters.Get(nameof(HydraMonsterFilter))))
        {
            Game.MsgPrint("The summoned reptile gets angry!");
        }
        else
        {
            Game.MsgPrint("No-one ever turns up.");
        }
    }
}