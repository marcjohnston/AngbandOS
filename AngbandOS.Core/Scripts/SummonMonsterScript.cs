// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class SummonMonsterScript : Script, IScript
{
    private SummonMonsterScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        Game.MsgPrint("You concentrate on the image of a monster...");
        if (Game.DieRoll(5) > 2)
        {
            if (!Game.SummonSpecificFriendly(Game.MapY.Value, Game.MapX.Value, Game.ExperienceLevel.Value, Game.SingletonRepository.MonsterFilters.Get(nameof(NoUniquesMonsterFilter)), false))
            {
                Game.MsgPrint("No-one ever turns up.");
            }
        }
        else if (Game.SummonSpecific(Game.MapY.Value, Game.MapX.Value, Game.ExperienceLevel.Value, null))
        {
            Game.MsgPrint("The summoned creature gets angry!");
        }
        else
        {
            Game.MsgPrint("No-one ever turns up.");
        }
    }
}
