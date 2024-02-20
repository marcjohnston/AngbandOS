// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class SummonHoundsScript : Script, IScript
{
    private SummonHoundsScript(SaveGame saveGame) : base(saveGame) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        SaveGame.MsgPrint("You concentrate on the image of a hound...");
        if (SaveGame.DieRoll(5) > 2)
        {
            if (!SaveGame.SummonSpecificFriendly(SaveGame.MapY, SaveGame.MapX, SaveGame.ExperienceLevel, SaveGame.SingletonRepository.MonsterFilters.Get(nameof(HoundMonsterFilter)), true))
            {
                SaveGame.MsgPrint("No-one ever turns up.");
            }
        }
        else if (SaveGame.SummonSpecific(SaveGame.MapY, SaveGame.MapX, SaveGame.ExperienceLevel, SaveGame.SingletonRepository.MonsterFilters.Get(nameof(HoundMonsterFilter))))
        {
            SaveGame.MsgPrint("The summoned hounds get angry!");
        }
        else
        {
            SaveGame.MsgPrint("No-one ever turns up.");
        }
    }
}
