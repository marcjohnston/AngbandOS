// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Projection;

[Serializable]
internal class ShardProjectile : Projectile
{
    private ShardProjectile(SaveGame saveGame) : base(saveGame) { }

    protected override ProjectileGraphic? BoltProjectileGraphic => SaveGame.SingletonRepository.ProjectileGraphics.Get(nameof(BrightBrownSplatProjectileGraphic));

    protected override ProjectileGraphic? ImpactProjectileGraphic => SaveGame.SingletonRepository.ProjectileGraphics.Get(nameof(BrightBrownSplatProjectileGraphic));

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
        if (rPtr.BreatheShards)
        {
            note = " resists.";
            dam *= 3;
            dam /= SaveGame.DieRoll(6) + 6;
        }
        ApplyProjectileDamageToMonster(who, mPtr, dam, note);
        return obvious;
    }

    protected override bool AffectPlayer(int who, int r, int y, int x, int dam, int aRad)
    {
        bool blind = SaveGame.TimedBlindness.Value != 0;
        if (dam > 1600)
        {
            dam = 1600;
        }
        dam = (dam + r) / (r + 1);
        Monster mPtr = SaveGame.Monsters[who];
        string killer = mPtr.IndefiniteVisibleName;
        if (blind)
        {
            SaveGame.MsgPrint("You are hit by shards of crystal!");
        }
        if (!SaveGame.HasSoundResistance)
        {
            SaveGame.TimedStun.AddTimer(SaveGame.DieRoll(20));
        }
        if (SaveGame.HasShardResistance)
        {
            dam /= 2;
        }
        else
        {
            SaveGame.TimedBleeding.AddTimer((dam / 2));
        }
        if (!SaveGame.HasShardResistance || SaveGame.DieRoll(12) == 1)
        {
            SaveGame.InvenDamage(SaveGame.SetColdDestroy, 3);
        }
        SaveGame.TakeHit(dam, killer);
        return true;
    }
}