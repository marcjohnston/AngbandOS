﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class ManaBurstScript : Script, IScript
{
    private ManaBurstScript(Game game) : base(game) { }

    /// <summary>
    /// Fires a ball of missle in a chosen direction.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        if (!Game.GetDirectionWithAim(out int dir))
        {
            return;
        }
        int experienceDivisor = (Game.BaseCharacterClass.ID == CharacterClass.Mage || Game.BaseCharacterClass.ID == CharacterClass.HighMage ? 2 : 4);
        int damage = Game.DiceRoll(3, 5) + Game.ExperienceLevel.Value + (Game.ExperienceLevel.Value / experienceDivisor);
        int radius = Game.ExperienceLevel.Value < 30 ? 2 : 3;
        Game.FireBall(Game.SingletonRepository.Projectiles.Get(nameof(MissileProjectile)), dir, damage, radius);
    }
}