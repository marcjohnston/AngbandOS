﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Spells.Chaos;

[Serializable]
internal class ChaosSpellDisintegrate : Spell
{
    private ChaosSpellDisintegrate(SaveGame saveGame) : base(saveGame) { }
    public override void Cast()
    {
        if (!SaveGame.GetDirectionWithAim(out int dir))
        {
            return;
        }
        SaveGame.FireBall(SaveGame.SingletonRepository.Projectiles.Get<DisintegrateProjectile>(), dir, 80 + SaveGame.ExperienceLevel,
            3 + (SaveGame.ExperienceLevel / 40));
    }

    public override void CastFailed()
    {
        DoWildChaoticMagic(19);
    }

    public override string Name => "Disintegrate";
    
    protected override string? Info()
    {
        return $"dam {80 + SaveGame.ExperienceLevel}";
    }
}