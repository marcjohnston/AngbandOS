﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Projectiles;

[Serializable]
internal class OldDrainLifeProjectile : Projectile
{
    private OldDrainLifeProjectile(Game game) : base(game) { }

    protected override ProjectileGraphic? BoltProjectileGraphic => Game.SingletonRepository.Get<ProjectileGraphic>(nameof(BlackBoltProjectileGraphic));

    protected override Animation EffectAnimation => Game.SingletonRepository.Get<Animation>(nameof(BlackContractAnimation));

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
        if (rPtr.Undead || rPtr.Demon || rPtr.Nonliving || "Egv".Contains(rPtr.Symbol.Character.ToString()))
        {
            if (rPtr.Undead)
            {
                if (seen)
                {
                    rPtr.Knowledge.Characteristics.Undead = true;
                }
            }
            if (rPtr.Demon)
            {
                if (seen)
                {
                    rPtr.Knowledge.Characteristics.Demon = true;
                }
            }
            note = " is unaffected!";
            obvious = false;
            dam = 0;
        }
        ApplyProjectileDamageToMonster(who, mPtr, dam, note);
        return obvious;
    }
}