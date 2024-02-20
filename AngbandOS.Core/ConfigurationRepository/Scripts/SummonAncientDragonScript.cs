// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class SummonAncientDragonScript : Script, IScript
{
    private SummonAncientDragonScript(SaveGame saveGame) : base(saveGame) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        SaveGame.MsgPrint("You concentrate on the image of an ancient dragon...");
        if (SaveGame.DieRoll(10) > 3)
        {
            if (!SaveGame.SummonSpecificFriendly(SaveGame.MapY, SaveGame.MapX, SaveGame.ExperienceLevel, SaveGame.SingletonRepository.MonsterFilters.Get(nameof(HiDragonNoUniquesMonsterFilter)), true))
            {
                SaveGame.MsgPrint("No-one ever turns up.");
            }
        }
        else if (SaveGame.SummonSpecific(SaveGame.MapY, SaveGame.MapX, SaveGame.ExperienceLevel, SaveGame.SingletonRepository.MonsterFilters.Get(nameof(HiDragonNoUniquesMonsterFilter))))
        {
            SaveGame.MsgPrint("The summoned dragon gets angry!");
        }
        else
        {
            SaveGame.MsgPrint("No-one ever turns up.");
        }
    }
}
