﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Spells.Nature;

[Serializable]
internal class NatureSpellWhirlpool : Spell
{
    private NatureSpellWhirlpool(SaveGame saveGame) : base(saveGame) { }
    public override void Cast()
    {
        if (!SaveGame.GetDirectionWithAim(out int dir))
        {
            return;
        }
        SaveGame.FireBall(SaveGame.SingletonRepository.Projectiles.Get<WaterProjectile>(), dir, 100 + SaveGame.ExperienceLevel, (SaveGame.ExperienceLevel / 12) + 1);
    }

    public override string Name => "Whirlpool";
    
    protected override string? Info()
    {
        return $"dam {100 + SaveGame.ExperienceLevel}";
    }
}