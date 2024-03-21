// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Projection;

[Serializable]
internal class OldCloneProjectile : Projectile
{
    private OldCloneProjectile(SaveGame saveGame) : base(saveGame) { }

    protected override ProjectileGraphic? BoltProjectileGraphic => SaveGame.SingletonRepository.ProjectileGraphics.Get(nameof(CopperBoltProjectileGraphic));

    protected override Animation EffectAnimation => SaveGame.SingletonRepository.Animations.Get(nameof(CopperExpandAnimation));

    protected override bool ProjectileAngersMonster(Monster mPtr)
    {
        // The attack will turn friends 1 in 8 times.
        return (SaveGame.DieRoll(8) == 1);
    }

    protected override bool AffectMonster(int who, Monster mPtr, int dam, int r)
    {
        GridTile cPtr = SaveGame.Grid[mPtr.MapY][mPtr.MapX];
        MonsterRace rPtr = mPtr.Race;
        bool seen = mPtr.IsVisible;
        bool obvious = false;
        string? note = null;
        bool isFriend = false;
        if (seen)
        {
            obvious = true;
        }
        if (mPtr.SmFriendly && SaveGame.DieRoll(3) != 1)
        {
            isFriend = true;
        }
        mPtr.Health = mPtr.MaxHealth;
        if (mPtr.Speed < 150)
        {
            mPtr.Speed += 10;
        }
        Monster targetMonster = SaveGame.Monsters[cPtr.MonsterIndex];
        if (SaveGame.MultiplyMonster(targetMonster, isFriend, true))
        {
            note = " spawns!";
        }
        dam = 0;
        ApplyProjectileDamageToMonster(who, mPtr, dam, note);
        return obvious;
    }
}