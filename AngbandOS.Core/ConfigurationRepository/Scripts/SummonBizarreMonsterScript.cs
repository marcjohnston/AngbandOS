// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class SummonBizarreMonsterScript : Script, IScript
{
    private SummonBizarreMonsterScript(SaveGame saveGame) : base(saveGame) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        MonsterFilter? summonType = null;
        SaveGame.MsgPrint("You concentrate on the Fool card...");
        switch (SaveGame.DieRoll(4))
        {
            case 1:
                summonType = SaveGame.SingletonRepository.MonsterFilters.Get(nameof(Bizarre1MonsterFilter));
                break;

            case 2:
                summonType = SaveGame.SingletonRepository.MonsterFilters.Get(nameof(Bizarre2MonsterFilter));
                break;

            case 3:
                summonType = SaveGame.SingletonRepository.MonsterFilters.Get(nameof(Bizarre4MonsterFilter));
                break;

            case 4:
                summonType = SaveGame.SingletonRepository.MonsterFilters.Get(nameof(Bizarre5MonsterFilter));
                break;
        }
        if (SaveGame.DieRoll(2) == 1)
        {
            SaveGame.MsgPrint(SaveGame.SummonSpecific(SaveGame.MapY, SaveGame.MapX, SaveGame.ExperienceLevel, summonType)
                ? "The summoned creature gets angry!"
                : "No-one ever turns up.");
        }
        else
        {
            if (!SaveGame.SummonSpecificFriendly(SaveGame.MapY, SaveGame.MapX, SaveGame.ExperienceLevel, summonType, false))
            {
                SaveGame.MsgPrint("No-one ever turns up.");
            }
        }
    }
}
