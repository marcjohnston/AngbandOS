﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class PhantasmalServantScript : Script, IScript
{
    private PhantasmalServantScript(SaveGame saveGame) : base(saveGame) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        bool success = SaveGame.SummonSpecificFriendly(SaveGame.MapY, SaveGame.MapX, SaveGame.ExperienceLevel * 3 / 2, SaveGame.SingletonRepository.MonsterFilters.Get(nameof(PhantomMonsterFilter)), false);
        string msg = success ? "'Your wish, master?'" : "No-one ever turns up.";
        SaveGame.MsgPrint(msg);
    }
}