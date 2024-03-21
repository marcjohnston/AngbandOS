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
    private RaiseTheDeadScript(SaveGame saveGame) : base(saveGame) { }

    /// <summary>
    /// Summons specific monsters, 1/3 of the time they are not friendly.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        if (SaveGame.DieRoll(3) == 1)
        {
            if (SaveGame.SummonSpecific(SaveGame.MapY, SaveGame.MapX, SaveGame.ExperienceLevel.Value * 3 / 2, SaveGame.ExperienceLevel.Value > 47 ? SaveGame.SingletonRepository.MonsterFilters.Get(nameof(HiUndeadMonsterFilter)) : SaveGame.SingletonRepository.MonsterFilters.Get(nameof(UndeadMonsterFilter))))
            {
                SaveGame.MsgPrint("Cold winds begin to swirl around you, carrying with them the stench of decay...");
                SaveGame.MsgPrint("'The dead arise... to punish you for disturbing them!'");
            }
            else
            {
                SaveGame.MsgPrint("No-one ever turns up.");
            }
        }
        else
        {
            if (SaveGame.SummonSpecificFriendly(SaveGame.MapY, SaveGame.MapX, SaveGame.ExperienceLevel.Value * 3 / 2, SaveGame.ExperienceLevel.Value > 47 ? SaveGame.SingletonRepository.MonsterFilters.Get(nameof(HiUndeadNoUniquesMonsterFilter)) : SaveGame.SingletonRepository.MonsterFilters.Get(nameof(UndeadMonsterFilter)), SaveGame.ExperienceLevel.Value > 24 && SaveGame.DieRoll(3) == 1))
            {
                SaveGame.MsgPrint("Cold winds begin to swirl around you, carrying with them the stench of decay...");
                SaveGame.MsgPrint("Ancient, long-dead forms arise from the ground to serve you!");
            }
            else
            {
                SaveGame.MsgPrint("No-one ever turns up.");
            }
        }
    }
}
