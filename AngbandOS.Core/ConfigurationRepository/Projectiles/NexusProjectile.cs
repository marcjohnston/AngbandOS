﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Projection;

[Serializable]
internal class NexusProjectile : Projectile
{
    private NexusProjectile(SaveGame saveGame) : base(saveGame) { }

    protected override ProjectileGraphic? BoltProjectileGraphic => SaveGame.SingletonRepository.ProjectileGraphics.Get<PinkBulletProjectileGraphic>();

    protected override Animation EffectAnimation => SaveGame.SingletonRepository.Animations.Get<PinkSwirlAnimation>();

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
        if (rPtr.ResistNexus)
        {
            note = " resists.";
            dam *= 3;
            dam /= SaveGame.Rng.DieRoll(6) + 6;
            if (seen)
            {
                rPtr.Knowledge.Characteristics.ResistNexus = true;
            }
        }
        ApplyProjectileDamageToMonster(who, mPtr, dam, note);
        return obvious;
    }

    protected override bool AffectPlayer(int who, int r, int y, int x, int dam, int aRad)
    {
        bool blind = SaveGame.TimedBlindness.TurnsRemaining != 0;
        if (dam > 1600)
        {
            dam = 1600;
        }
        dam = (dam + r) / (r + 1);
        Monster mPtr = SaveGame.Monsters[who];
        string killer = mPtr.IndefiniteVisibleName;
        if (blind)
        {
            SaveGame.MsgPrint("You are hit by something strange!");
        }
        if (SaveGame.HasNexusResistance)
        {
            dam *= 6;
            dam /= SaveGame.Rng.DieRoll(6) + 6;
        }
        else
        {
            SaveGame.ApplyNexus(mPtr);
        }
        SaveGame.TakeHit(dam, killer);
        return true;
    }
}