// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class MassSummonsScript : Script, IScript
{
    private MassSummonsScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        bool noneCame = true;
        Game.MsgPrint("You concentrate on several images at once...");
        for (int dummy = 0; dummy < 3 + (Game.ExperienceLevel.IntValue / 10); dummy++)
        {
            if (Game.DieRoll(10) > 3)
            {
                if (Game.SummonSpecificFriendly(Game.MapY.IntValue, Game.MapX.IntValue, Game.ExperienceLevel.IntValue, Game.SingletonRepository.Get<MonsterFilter>(nameof(NoUniquesMonsterFilter)), false))
                {
                    noneCame = false;
                }
            }
            else if (Game.SummonSpecific(Game.MapY.IntValue, Game.MapX.IntValue, Game.ExperienceLevel.IntValue, null))
            {
                Game.MsgPrint("A summoned creature gets angry!");
                noneCame = false;
            }
        }
        if (noneCame)
        {
            Game.MsgPrint("No-one ever turns up.");
        }
    }
}
