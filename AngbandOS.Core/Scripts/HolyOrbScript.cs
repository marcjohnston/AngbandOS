﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class HolyOrbScript : Script, IScript
{
    private HolyOrbScript(Game game) : base(game) { }

    /// <summary>
    /// Fires a ball of holy fire in a chosen direction.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        if (!Game.GetDirectionWithAim(out int dir))
        {
            return;
        }
        Game.FireBall(Game.SingletonRepository.Projectiles.Get(nameof(HolyFireProjectile)), dir, Game.DiceRoll(3, 6) + Game.ExperienceLevel.Value + (Game.ExperienceLevel.Value / (Game.BaseCharacterClass.ID == CharacterClass.Priest || Game.BaseCharacterClass.ID == CharacterClass.HighMage ? 2 : 4)), Game.ExperienceLevel.Value < 30 ? 2 : 3);
    }
}