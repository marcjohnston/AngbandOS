﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Projection;

[Serializable]
internal class ControlAnimalProjectile : Projectile
{
    private ControlAnimalProjectile(SaveGame saveGame) : base(saveGame) { }

    protected override ProjectileGraphic? BoltProjectileGraphic => SaveGame.SingletonRepository.ProjectileGraphics.Get<GreenBulletProjectileGraphic>();

    protected override Animation EffectAnimation => SaveGame.SingletonRepository.Animations.Get<GreenControlAnimation>();

    protected override bool ProjectileAngersMonster(Monster mPtr)
    {
        return false;
    }

    protected override bool AffectMonster(int who, Monster mPtr, int dam, int r)
    {
        MonsterRace rPtr = mPtr.Race;
        bool seen = mPtr.IsVisible;
        bool obvious = false;
        string? note = null;
        if (seen)
        {
            obvious = true;
        }
        if (rPtr.Unique || !rPtr.Animal ||
            rPtr.ImmuneConfusion ||
            rPtr.Level > SaveGame.Rng.DieRoll(dam - 10 < 1 ? 1 : dam - 10) + 10)
        {
            if (rPtr.ImmuneConfusion)
            {
                if (seen)
                {
                    rPtr.Knowledge.Characteristics.ImmuneConfusion = true;
                }
            }
            note = " is unaffected!";
            obvious = false;
        }
        else if (SaveGame.HasAggravation || rPtr.Guardian)
        {
            note = " hates you too much!";
        }
        else
        {
            note = " is tamed!";
            mPtr.SmFriendly = true;
        }
        dam = 0;
        ApplyProjectileDamageToMonster(who, mPtr, dam, note);
        return obvious;
    }
}