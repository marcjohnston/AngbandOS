// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.MonsterEffects;

[Serializable]
internal class DominationMonsterEffect : AffectMonsterScript
{
    private DominationMonsterEffect(Game game) : base(game) { } // This object is a singleton.

    /// <summary>
    /// Returns the <see cref="ConfusionImmuneMonsterFilter"/> because pets that are already immune to confusion will become unfriendly when hit with this projectile.
    /// </summary>
    protected override string? UnfriendPetMonsterFilterBindingKey => nameof(ConfusionImmuneMonsterFilter);

    protected override bool Apply(int who, Monster mPtr, int dam, int r)
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
        if (rPtr.Unique || rPtr.ImmuneConfusion || rPtr.Level > Game.DieRoll(dam - 10 < 1 ? 1 : dam - 10) + 10)
        {
            if (rPtr.ImmuneConfusion)
            {
                if (seen)
                {
                    rPtr.Knowledge.Characteristics.ImmuneConfusion = true;
                }
            }
            doConf = 0;
            if ((rPtr.Undead || rPtr.Demon) && rPtr.Level > Game.ExperienceLevel.IntValue / 2 && Game.DieRoll(2) == 1)
            {
                string s = seen ? "'s" : "s";
                Game.MsgPrint($"{mName}{s} corrupted mind backlashes your attack!");
                if (Game.RandomLessThan(100) < Game.SkillSavingThrow)
                {
                    Game.MsgPrint("You resist the effects!");
                }
                else
                {
                    switch (Game.DieRoll(4))
                    {
                        case 1:
                            Game.StunTimer.AddTimer((dam / 2));
                            break;

                        case 2:
                            Game.ConfusedTimer.AddTimer((dam / 2));
                            break;

                        default:
                            {
                                if (rPtr.ImmuneFear)
                                {
                                    note = " is unaffected.";
                                }
                                else
                                {
                                    Game.FearTimer.AddTimer(dam);
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
                if (dam > 29 && Game.DieRoll(100) < dam)
                {
                    note = " is in your thrall!";
                    mPtr.IsPet = true;
                }
                else
                {
                    switch (Game.DieRoll(4))
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
        ApplyProjectileDamageToMonster(who, mPtr, dam, note, null, doFear);
        return obvious;
    }
}
