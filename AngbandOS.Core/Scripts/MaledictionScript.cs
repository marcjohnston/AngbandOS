﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class MaledictionScript : Script, IScript
{
    private MaledictionScript(Game game) : base(game) { }

    /// <summary>
    /// Fires a ball of hellfire in a chosen direction and 80% of the time an additional bolt of deathray (0.001% [1/1000]), turn all (50%), old confusion (30%) or stun 
    /// on a monster (20%) of the time.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        if (!Game.GetDirectionWithAim(out int dir))
        {
            return;
        }
        Game.FireBall(Game.SingletonRepository.Projectiles.Get(nameof(HellfireProjectile)), dir, Game.DiceRoll(3 + ((Game.ExperienceLevel.Value - 1) / 5), 3), 0);
        if (Game.DieRoll(5) != 1)
        {
            return;
        }
        int dummy = Game.DieRoll(1000);
        if (dummy == 666)
        {
            Game.FireBolt(Game.SingletonRepository.Projectiles.Get(nameof(DeathRayProjectile)), dir, Game.ExperienceLevel.Value);
        }
        if (dummy < 500)
        {
            Game.FireBolt(Game.SingletonRepository.Projectiles.Get(nameof(TurnAllProjectile)), dir, Game.ExperienceLevel.Value);
        }
        if (dummy < 800)
        {
            Game.FireBolt(Game.SingletonRepository.Projectiles.Get(nameof(OldConfProjectile)), dir, Game.ExperienceLevel.Value);
        }
        Game.FireBolt(Game.SingletonRepository.Projectiles.Get(nameof(StunProjectile)), dir, Game.ExperienceLevel.Value);
    }
}