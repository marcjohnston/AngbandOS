﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Projection;

[Serializable]
internal class OldDrainProjectile : Projectile
{
    private OldDrainProjectile(SaveGame saveGame) : base(saveGame) { }

    protected override ProjectileGraphic? BoltProjectileGraphic => SaveGame.SingletonRepository.ProjectileGraphics.Get<BlackBoltProjectileGraphic>();

    protected override Animation EffectAnimation => SaveGame.SingletonRepository.Animations.Get<BlackContractAnimation>();

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