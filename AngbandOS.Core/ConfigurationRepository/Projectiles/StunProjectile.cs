﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Projection;

[Serializable]
internal class StunProjectile : Projectile
{
    private StunProjectile(SaveGame saveGame) : base(saveGame) { }

    protected override ProjectileGraphic? BoltProjectileGraphic => SaveGame.SingletonRepository.ProjectileGraphics.Get<GoldBoltProjectileGraphic>();

    protected override ProjectileGraphic? ImpactProjectileGraphic => SaveGame.SingletonRepository.ProjectileGraphics.Get<GoldSplatProjectileGraphic>();

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
        int doStun = SaveGame.Rng.DiceRoll((SaveGame.ExperienceLevel / 10) + 3, dam) + 1;
        if (rPtr.Unique ||
            rPtr.Level > SaveGame.Rng.DieRoll(dam - 10 < 1 ? 1 : dam - 10) + 10)
        {
            doStun = 0;
            note = " is unaffected!";
            obvious = false;
        }
        dam = 0;
        if (doStun != 0 && !rPtr.BreatheSound && !rPtr.BreatheForce)
        {
            if (seen)
            {
                obvious = true;
            }
            int tmp;
            if (mPtr.StunLevel != 0)
            {
                note = " is more dazed.";
                tmp = mPtr.StunLevel + (doStun / 2);
            }
            else
            {
                note = " is dazed.";
                tmp = doStun;
            }
            mPtr.StunLevel = tmp < 200 ? tmp : 200;
        }
        ApplyProjectileDamageToMonster(who, mPtr, dam, note);
        return obvious;
    }
}