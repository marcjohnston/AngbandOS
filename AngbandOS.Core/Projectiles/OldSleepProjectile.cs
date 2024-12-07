// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Projectiles;

[Serializable]
internal class OldSleepProjectile : Projectile
{
    private OldSleepProjectile(Game game) : base(game) { }

    protected override Animation EffectAnimation => Game.SingletonRepository.Get<Animation>(nameof(YellowSparkleAnimation));

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
        string note;
        if (rPtr.Unique || rPtr.ImmuneSleep ||
            rPtr.Level > Game.DieRoll(dam - 10 < 1 ? 1 : dam - 10) + 10)
        {
            if (rPtr.ImmuneSleep)
            {
                if (seen)
                {
                    rPtr.Knowledge.Characteristics.ImmuneSleep = true;
                }
            }
            note = " is unaffected!";
            obvious = false;
        }
        else
        {
            note = " falls asleep!";
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

    protected override bool AffectPlayer(int who, int r, int y, int x, int dam, int aRad)
    {
        bool blind = Game.BlindnessTimer.Value != 0;
        if (dam > 1600)
        {
            dam = 1600;
        }
        dam = (dam + r) / (r + 1);
        if (Game.HasFreeAction)
        {
            return false;
        }
        if (blind)
        {
            Game.MsgPrint("You fall asleep!");
        }
        Game.ParalysisTimer.AddTimer(dam);
        return true;
    }
}