﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class DisintegrateScript : Script, IScript
{
    private DisintegrateScript(Game game) : base(game) { }

    /// <summary>
    /// Fires a ball of disintegration in a chosen direction.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        if (!Game.GetDirectionWithAim(out int dir))
        {
            return;
        }
        Game.FireBall(Game.SingletonRepository.Projectiles.Get(nameof(DisintegrateProjectile)), dir, 80 + Game.ExperienceLevel.Value, 3 + (Game.ExperienceLevel.Value / 40));
    }
}