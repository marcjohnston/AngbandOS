﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Projection;

[Serializable]
internal class StasisProjectile : Projectile
{
    private StasisProjectile(SaveGame saveGame) : base(saveGame) { }

    protected override ProjectileGraphic? BoltProjectileGraphic => SaveGame.SingletonRepository.ProjectileGraphics.Get<SilverBoltProjectileGraphic>();

    protected override Animation EffectAnimation => SaveGame.SingletonRepository.Animations.Get<SilverCloudAnimation>();

    protected override bool AffectMonster(int who, Monster mPtr, int dam, int r)
    {
        MonsterRace rPtr = mPtr.Race;
        bool seen = mPtr.IsVisible;
        bool obvious = false;
        int doSleep = 0;
        if (seen)
        {
            obvious = true;
        }
        string? note = null;
        if (rPtr.Unique ||
            rPtr.Level > SaveGame.Rng.DieRoll(dam - 10 < 1 ? 1 : dam - 10) + 10)
        {
            note = " is unaffected!";
            obvious = false;
        }
        else
        {
            note = " is suspended!";
            doSleep = 500;
        }
        dam = 0;
        ApplyProjectileDamageToMonster(who, mPtr, dam, note);
        // Put the monster to sleep, if not dead.
        if (mPtr.Health >= 0 && doSleep != 0)
        {
            mPtr.SleepLevel = doSleep;
        }
        return obvious;
    }
}