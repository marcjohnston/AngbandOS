// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Projection;

[Serializable]
internal class PsiProjectile : Projectile
{
    private PsiProjectile(Game game) : base(game) { }

    protected override Animation EffectAnimation => Game.SingletonRepository.Animations.Get(nameof(DiamondSparkleAnimation));

    protected override bool ProjectileAngersMonster(Monster mPtr)
    {
        // Only stupid friends are affected.
        MonsterRace rPtr = mPtr.Race;
        return rPtr.EmptyMind;
    }

    protected override bool AffectMonster(int who, Monster mPtr, int dam, int r)
    {
        int tmp;
        MonsterRace rPtr = mPtr.Race;
        bool seen = mPtr.IsVisible;
        bool obvious = false;
        int doConf = 0;
        int doStun = 0;
        int doSleep = 0;
        int doFear = 0;
        string? note = null;
        string mName = mPtr.Name;
        if (seen)
        {
            obvious = true;
        }
        if (rPtr.EmptyMind)
        {
            dam = 0;
            note = " is immune!";
        }
        else if (rPtr.Stupid || rPtr.WeirdMind || rPtr.Animal || rPtr.Level > Game.DieRoll(3 * dam))
        {
            dam /= 3;
            note = " resists.";
            if ((rPtr.Undead || rPtr.Demon) && rPtr.Level > Game.ExperienceLevel.Value / 2 && Game.DieRoll(2) == 1)
            {
                note = null;
                string s = seen ? "'s" : "s";
                Game.MsgPrint($"{mName}{s} corrupted mind backlashes your attack!");
                if (Game.RandomLessThan(100) < Game.SkillSavingThrow)
                {
                    Game.MsgPrint("You resist the effects!");
                }
                else
                {
                    string killer = mPtr.IndefiniteVisibleName;
                    Game.TakeHit(dam, killer);
                    if (Game.DieRoll(4) == 1)
                    {
                        switch (Game.DieRoll(4))
                        {
                            case 1:
                                Game.ConfusedTimer.AddTimer(3 + Game.DieRoll(dam));
                                break;

                            case 2:
                                Game.StunTimer.AddTimer(Game.DieRoll(dam));
                                break;

                            case 3:
                                {
                                    if (rPtr.ImmuneFear)
                                    {
                                        note = " is unaffected.";
                                    }
                                    else
                                    {
                                        Game.FearTimer.AddTimer(3 + Game.DieRoll(dam));
                                    }
                                }
                                break;

                            default:
                                if (!Game.HasFreeAction)
                                {
                                    Game.ParalysisTimer.AddTimer(Game.DieRoll(dam));
                                }
                                break;
                        }
                    }
                }
                dam = 0;
            }
        }
        if (dam > 0 && Game.DieRoll(4) == 1)
        {
            switch (Game.DieRoll(4))
            {
                case 1:
                    doConf = 3 + Game.DieRoll(dam);
                    break;

                case 2:
                    doStun = 3 + Game.DieRoll(dam);
                    break;

                case 3:
                    doFear = 3 + Game.DieRoll(dam);
                    break;

                default:
                    doSleep = 3 + Game.DieRoll(dam);
                    break;
            }
        }
        string noteDies = " collapses, a mindless husk.";
        if (doStun != 0 && !rPtr.BreatheSound && !rPtr.BreatheForce)
        {
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
        else if (doConf != 0 && !rPtr.ImmuneConfusion && !rPtr.BreatheConfusion && !rPtr.BreatheChaos)
        {
            if (mPtr.ConfusionLevel != 0)
            {
                note = " looks more confused.";
                tmp = mPtr.ConfusionLevel + (doConf / 2);
            }
            else
            {
                note = " looks confused.";
                tmp = doConf;
            }
            mPtr.ConfusionLevel = tmp < 200 ? tmp : 200;
        }
        ApplyProjectileDamageToMonster(who, mPtr, dam, note, noteDies, doFear);

        // Put the monster to sleep, if not dead.
        if (mPtr.Health >= 0 && doSleep != 0)
        {
            mPtr.SleepLevel = doSleep;
        }
        return obvious;
    }
}