﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class HorrifyScript : Script, IScript
{
    private HorrifyScript(SaveGame saveGame) : base(saveGame) { }

    /// <summary>
    /// Sets fear and stun on a monster in a chosen direction with damage equivalent to the player experience.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        if (!SaveGame.GetDirectionWithAim(out int dir))
        {
            return;
        }
        SaveGame.FearMonster(dir, SaveGame.ExperienceLevel);
        SaveGame.StunMonster(dir, SaveGame.ExperienceLevel);
    }
}