﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Spells.Chaos;

[Serializable]
internal class ChaosSpellFlameStrike : Spell
{
    private ChaosSpellFlameStrike(SaveGame saveGame) : base(saveGame) { }
    public override void Cast()
    {
        SaveGame.FireBall(SaveGame.SingletonRepository.Projectiles.Get<FireProjectile>(), 0, 150 + (2 * SaveGame.ExperienceLevel), 8);
    }

    public override void CastFailed()
    {
        DoWildChaoticMagic(26);
    }

    public override string Name => "Flame Strike";
    
    protected override string? Info()
    {
        return $"dam {150 + (SaveGame.ExperienceLevel * 2)}";
    }
}