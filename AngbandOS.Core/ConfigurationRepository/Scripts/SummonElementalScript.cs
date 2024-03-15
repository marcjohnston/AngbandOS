// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class SummonElementalScript : Script, IScript
{
    private SummonElementalScript(SaveGame saveGame) : base(saveGame) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        if (SaveGame.DieRoll(6) > 3)
        {
            if (!SaveGame.SummonSpecificFriendly(SaveGame.MapY, SaveGame.MapX, SaveGame.ExperienceLevel.Value, SaveGame.SingletonRepository.MonsterFilters.Get(nameof(ElementalMonsterFilter)), false))
            {
                SaveGame.MsgPrint("No-one ever turns up.");
            }
        }
        else if (SaveGame.SummonSpecific(SaveGame.MapY, SaveGame.MapX, SaveGame.ExperienceLevel.Value, SaveGame.SingletonRepository.MonsterFilters.Get(nameof(ElementalMonsterFilter))))
        {
            SaveGame.MsgPrint("You fail to control the elemental creature!");
        }
        else
        {
            SaveGame.MsgPrint("No-one ever turns up.");
        }
    }
}
