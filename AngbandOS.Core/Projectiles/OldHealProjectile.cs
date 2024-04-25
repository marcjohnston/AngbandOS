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
    private OldHealProjectile(Game game) : base(game) { }

    protected override ProjectileGraphic? BoltProjectileGraphic => Game.SingletonRepository.ProjectileGraphics.Get(nameof(WhiteBulletProjectileGraphic));

    protected override Animation EffectAnimation => Game.SingletonRepository.Animations.Get(nameof(WhiteSparkleAnimation));

    protected override bool ProjectileAngersMonster(Monster mPtr)
    {
        return false;
    }

    protected override bool AffectMonster(int who, Monster mPtr, int dam, int r)
    {
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
        if (Game.TrackedMonster != null && Game.TrackedMonster == mPtr)
        {
            Game.SingletonRepository.FlaggedActions.Get(nameof(RedrawMonsterHealthFlaggedAction)).Set();
        }
        string? note = " looks healthier.";
        dam = 0;
        ApplyProjectileDamageToMonster(who, mPtr, dam, note);
        return obvious;
    }

    protected override bool AffectPlayer(int who, int r, int y, int x, int dam, int aRad)
    {
        bool blind = Game.BlindnessTimer.Value != 0;
        if (dam > 1600)
        {
            dam = 1600;
        }
        dam = (dam + r) / (r + 1);
        if (blind)
        {
            Game.MsgPrint("You are hit by something invigorating!");
        }
        Game.RestoreHealth(dam);
        return true;
    }
}