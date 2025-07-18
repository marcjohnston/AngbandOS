﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Scripts;

[Serializable]
internal class MageDarkBoltScript : Script, IScript, ICastSpellScript
{
    private MageDarkBoltScript(Game game) : base(game) { }

    public void ExecuteCastSpellScript(Spell spell)
    {
        ExecuteScript();
    }

    /// <summary>
    /// Fires a bolt or beam of dark in a chosen direction with damage equal to 1/2 the experience or for mages, 1x experience or for high mages, experience + 10.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        if (!Game.GetDirectionWithAim(out int dir))
        {
            return;
        }
        Game.FireBoltOrBeam(Game.ExperienceLevel.IntValue, Game.SingletonRepository.Get<Projectile>(nameof(DarknessProjectile)), dir, Game.DiceRoll(4 + ((Game.ExperienceLevel.IntValue - 5) / 4), 8));
    }
    public string LearnedDetails => $"dam {4 + ((Game.ExperienceLevel.IntValue - 5) / 4)}d8";
}
