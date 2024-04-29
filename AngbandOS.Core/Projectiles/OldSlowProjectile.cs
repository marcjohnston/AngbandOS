// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Projection;

[Serializable]
internal class OldSlowProjectile : Projectile
{
    private OldSlowProjectile(Game game) : base(game) { }

    protected override ProjectileGraphic? BoltProjectileGraphic => Game.SingletonRepository.ProjectileGraphics.Get(nameof(BlueBulletProjectileGraphic));

    protected override Animation EffectAnimation => Game.SingletonRepository.Get<Animation>(nameof(BlueSwirlAnimation));

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
        if (rPtr.Unique ||
            rPtr.Level > Game.DieRoll(dam - 10 < 1 ? 1 : dam - 10) + 10)
        {
            note = " is unaffected!";
            obvious = false;
        }
        else
        {
            if (mPtr.Speed > 60)
            {
                mPtr.Speed -= 10;
            }
            note = " starts moving slower.";
        }
        dam = 0;
        ApplyProjectileDamageToMonster(who, mPtr, dam, note);
        return obvious;
    }

    protected override bool AffectPlayer(int who, int r, int y, int x, int dam, int aRad)
    {
        bool blind = Game.BlindnessTimer.Value != 0;
        if (blind)
        {
            Game.MsgPrint("You are hit by something slow!");
        }
        Game.SlowTimer.AddTimer(Game.RandomLessThan(4) + 4);
        return true;
    }
}