﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Spells.Chaos;

[Serializable]
internal class ChaosSpellGravityBeam : Spell
{
    private ChaosSpellGravityBeam(SaveGame saveGame) : base(saveGame) { }
    public override void Cast()
    {
        if (!SaveGame.GetDirectionWithAim(out int dir))
        {
            return;
        }
        SaveGame.FireBeam(SaveGame.SingletonRepository.Projectiles.Get<GravityProjectile>(), dir,
            SaveGame.Rng.DiceRoll(9 + ((SaveGame.ExperienceLevel - 5) / 4), 8));
    }

    public override void CastFailed()
    {
        DoWildChaoticMagic(24);
    }

    public override string Name => "Gravity Beam";
    
    protected override string? Info()
    {
        return $"dam {9 + ((SaveGame.ExperienceLevel - 5) / 4)}d8";
    }
}