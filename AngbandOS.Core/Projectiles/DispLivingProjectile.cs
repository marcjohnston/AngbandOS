﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Projection;

[Serializable]
internal class DispLivingProjectile : Projectile
{
    private DispLivingProjectile(Game game) : base(game) { }

    protected override ProjectileGraphic? BoltProjectileGraphic => Game.SingletonRepository.ProjectileGraphics.Get(nameof(GreenSplatProjectileGraphic));

    protected override Animation EffectAnimation => Game.SingletonRepository.Animations.Get(nameof(GreenExpandAnimation));

    protected override bool ProjectileAngersMonster(Monster mPtr)
    {
        MonsterRace rPtr = mPtr.Race;
        return !rPtr.Undead && !rPtr.Nonliving;
    }

    protected override bool AffectMonster(int who, Monster mPtr, int dam, int r)
    {
        bool seen = mPtr.IsVisible;
        bool obvious = false;
        bool skipped = false;
        string? note = null;
        string? noteDies = null;
        if (ProjectileAngersMonster(mPtr))
        {
            if (seen)
            {
                obvious = true;
            }
            note = " shudders.";
            noteDies = " dissolves!";
        }
        else
        {
            skipped = true;
            dam = 0;
        }
        if (skipped)
        {
            return false;
        }
        ApplyProjectileDamageToMonster(who, mPtr, dam, note, noteDies);
        return obvious;
    }
}