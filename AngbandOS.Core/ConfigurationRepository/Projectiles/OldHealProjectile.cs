// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Projection;

[Serializable]
internal class OldHealProjectile : Projectile
{
    private OldHealProjectile(SaveGame saveGame) : base(saveGame) { }

    protected override ProjectileGraphic? BoltProjectileGraphic => SaveGame.SingletonRepository.ProjectileGraphics.Get<WhiteBulletProjectileGraphic>();

    protected override Animation EffectAnimation => SaveGame.SingletonRepository.Animations.Get<WhiteSparkleAnimation>();

    protected override bool ProjectileAngersMonster(Monster mPtr)
    {
        return false;
    }

    protected override bool AffectMonster(int who, Monster mPtr, int dam, int r)
    {
        GridTile cPtr = SaveGame.Grid[mPtr.MapY][mPtr.MapX];
        MonsterRace rPtr = mPtr.Race;
        bool seen = mPtr.IsVisible;
        bool obvious = false;
        if (seen)
        {
            obvious = true;
        }
        mPtr.SleepLevel = 0;
        mPtr.Health += dam;
        if (mPtr.Health > mPtr.MaxHealth)
        {
            mPtr.Health = mPtr.MaxHealth;
        }
        if (SaveGame.TrackedMonsterIndex == cPtr.MonsterIndex)
        {
            SaveGame.SingletonRepository.FlaggedActions.Get<RedrawHealthFlaggedAction>().Set();
        }
        string? note = " looks healthier.";
        dam = 0;
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
        if (blind)
        {
            SaveGame.MsgPrint("You are hit by something invigorating!");
        }
        SaveGame.RestoreHealth(dam);
        return true;
    }
}