// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class SummonGreaterUndeadScript : Script, IScript
{
    private SummonGreaterUndeadScript(SaveGame saveGame) : base(saveGame) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        SaveGame.MsgPrint("You concentrate on the image of a greater undead being...");
        if (SaveGame.DieRoll(10) > 3)
        {
            if (!SaveGame.SummonSpecificFriendly(SaveGame.MapY, SaveGame.MapX, SaveGame.ExperienceLevel, SaveGame.SingletonRepository.MonsterFilters.Get(nameof(HiUndeadNoUniquesMonsterFilter)), true))
            {
                SaveGame.MsgPrint("No-one ever turns up.");
            }
        }
        else if (SaveGame.SummonSpecific(SaveGame.MapY, SaveGame.MapX, SaveGame.ExperienceLevel, SaveGame.SingletonRepository.MonsterFilters.Get(nameof(HiUndeadNoUniquesMonsterFilter))))
        {
            SaveGame.MsgPrint("The summoned undead creature gets angry!");
        }
        else
        {
            SaveGame.MsgPrint("No-one ever turns up.");
        }
    }
}
