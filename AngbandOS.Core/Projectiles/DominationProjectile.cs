// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Projection;

[Serializable]
internal class DominationProjectile : Projectile
{
    private DominationProjectile(SaveGame saveGame) : base(saveGame) { }

    protected override Animation EffectAnimation => SaveGame.SingletonRepository.Animations.Get<WhiteControlAnimation>();

    protected override bool ProjectileAngersMonster(Monster mPtr)
    {
        // Only evil friends are affected.
        MonsterRace rPtr = mPtr.Race;
        return rPtr.ImmuneConfusion;
    }

    protected override bool AffectMonster(int who, Monster mPtr, int dam, int r)
    {
        MonsterRace rPtr = mPtr.Race;
        bool seen = mPtr.IsVisible;
        bool obvious = false;
        int doConf = 0;
        int doStun = 0;
        int doFear = 0;
        string? note = null;
        string mName = mPtr.Name;
        if (seen)
        {
            obvious = true;
        }
        if (rPtr.Unique || rPtr.ImmuneConfusion || rPtr.Level > Program.Rng.DieRoll(dam - 10 < 1 ? 1 : dam - 10) + 10)
        {
            if (rPtr.ImmuneConfusion)
            {
                if (seen)
                {
                    rPtr.Knowledge.Characteristics.ImmuneConfusion = true;
                }
            }
            doConf = 0;
            if ((rPtr.Undead || rPtr.Demon) && rPtr.Level > SaveGame.ExperienceLevel / 2 && Program.Rng.DieRoll(2) == 1)
            {
                string s = seen ? "'s" : "s";
                SaveGame.MsgPrint($"{mName}{s} corrupted mind backlashes your attack!");
                if (Program.Rng.RandomLessThan(100) < SaveGame.SkillSavingThrow)
                {
                    SaveGame.MsgPrint("You resist the effects!");
                }
                else
                {
                    switch (Program.Rng.DieRoll(4))
                    {
                        case 1:
                            SaveGame.TimedStun.AddTimer((dam / 2));
                            break;

                        case 2:
                            SaveGame.TimedConfusion.AddTimer((dam / 2));
                            break;

                        default:
                            {
                                if (rPtr.ImmuneFear)
                                {
                                    note = " is unaffected.";
                                }
                                else
                                {
                                    SaveGame.TimedFear.AddTimer(dam);
                                }
                                break;
                            }
                    }
                }
            }
            else
            {
                note = " is unaffected!";
                obvious = false;
            }
        }
        else
        {
            if (rPtr.Guardian)
            {
                note = " hates you too much!";
            }
            else
            {
                if (dam > 29 && Program.Rng.DieRoll(100) < dam)
                {
                    note = " is in your thrall!";
                    mPtr.SmFriendly = true;
                }
                else
                {
                    switch (Program.Rng.DieRoll(4))
                    {
                        case 1:
                            doStun = dam / 2;
                            break;

                        case 2:
                            doConf = dam / 2;
                            break;

                        default:
                            doFear = dam;
                            break;
                    }
                }
            }
        }
        dam = 0;
        if (doStun != 0 && !rPtr.BreatheSound && !rPtr.BreatheForce)
        {
            if (seen)
            {
                obvious = true;
            }
            int tmp;
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
            if (seen)
            {
                obvious = true;
            }
            int tmp;
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
        ApplyProjectileDamageToMonster(who, mPtr, dam, note, doFear);
        return obvious;
    }
}