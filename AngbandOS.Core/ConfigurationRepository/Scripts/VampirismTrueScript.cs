﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class VampirismTrueScript : Script, IScript
{
    private VampirismTrueScript(SaveGame saveGame) : base(saveGame) { }

    /// <summary>
    /// Drains 100 points of life from a monster in a chosen direction and adds 100 points to the player.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        if (!SaveGame.GetDirectionWithAim(out int dir))
        {
            return;
        }
        for (int dummy = 0; dummy < 3; dummy++)
        {
            if (SaveGame.DrainLife(dir, 100))
            {
                SaveGame.RestoreHealth(100);
            }
        }
    }
}