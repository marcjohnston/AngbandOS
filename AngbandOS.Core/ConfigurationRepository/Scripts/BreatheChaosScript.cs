﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class BreatheChaosScript : Script, IScript
{
    private BreatheChaosScript(SaveGame saveGame) : base(saveGame) { }

    /// <summary>
    /// Allows a direction to be chosen, then fires a chaos ball projectile with a damage that matches the players health with a radius of -2.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        if (!SaveGame.GetDirectionWithAim(out int dir))
        {
            return;
        }
        SaveGame.FireBall(SaveGame.SingletonRepository.Projectiles.Get(nameof(ChaosProjectile)), dir, SaveGame.Health, -2);
    }
}