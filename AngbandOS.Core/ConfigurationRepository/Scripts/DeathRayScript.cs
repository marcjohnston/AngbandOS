﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class DeathRayScript : Script, IScript
{
    private DeathRayScript(SaveGame saveGame) : base(saveGame) { }

    /// <summary>
    /// Projects a death ray in a chosen direction with damage equal to the player experience.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        if (!SaveGame.GetDirectionWithAim(out int dir))
        {
            return;
        }
        ProjectionFlag flg = ProjectionFlag.ProjectStop | ProjectionFlag.ProjectKill;
        SaveGame.TargetedProject(SaveGame.SingletonRepository.Projectiles.Get(nameof(DeathRayProjectile)), dir, SaveGame.ExperienceLevel, flg);
    }
}