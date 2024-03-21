// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class RaiseTheDeadScript : Script, IScript
{
    private RaiseTheDeadScript(Game game) : base(game) { }

    /// <summary>
    /// Summons specific monsters, 1/3 of the time they are not friendly.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        if (Game.DieRoll(3) == 1)
        {
            if (Game.SummonSpecific(Game.MapY, Game.MapX, Game.ExperienceLevel.Value * 3 / 2, Game.ExperienceLevel.Value > 47 ? Game.SingletonRepository.MonsterFilters.Get(nameof(HiUndeadMonsterFilter)) : Game.SingletonRepository.MonsterFilters.Get(nameof(UndeadMonsterFilter))))
            {
                Game.MsgPrint("Cold winds begin to swirl around you, carrying with them the stench of decay...");
                Game.MsgPrint("'The dead arise... to punish you for disturbing them!'");
            }
            else
            {
                Game.MsgPrint("No-one ever turns up.");
            }
        }
        else
        {
            if (Game.SummonSpecificFriendly(Game.MapY, Game.MapX, Game.ExperienceLevel.Value * 3 / 2, Game.ExperienceLevel.Value > 47 ? Game.SingletonRepository.MonsterFilters.Get(nameof(HiUndeadNoUniquesMonsterFilter)) : Game.SingletonRepository.MonsterFilters.Get(nameof(UndeadMonsterFilter)), Game.ExperienceLevel.Value > 24 && Game.DieRoll(3) == 1))
            {
                Game.MsgPrint("Cold winds begin to swirl around you, carrying with them the stench of decay...");
                Game.MsgPrint("Ancient, long-dead forms arise from the ground to serve you!");
            }
            else
            {
                Game.MsgPrint("No-one ever turns up.");
            }
        }
    }
}
