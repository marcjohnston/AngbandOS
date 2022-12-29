// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Projection
{
    internal class ProjectPsi : Projectile
    {
        public ProjectPsi(SaveGame saveGame) : base(saveGame)
        {
        }

        protected override string BoltGraphic => "";

        protected override string EffectAnimation => "DiamondSparkle";

        protected override bool ProjectileAngersMonster(Monster mPtr)
        {
            // Only stupid friends are affected.
            MonsterRace rPtr = mPtr.Race;
            return rPtr.EmptyMind;
        }

        protected override bool AffectMonster(int who, Monster mPtr, int dam, int r)
        {
            GridTile cPtr = SaveGame.Level.Grid[mPtr.MapY][mPtr.MapX];
            int tmp;
            MonsterRace rPtr = mPtr.Race;
            bool seen = mPtr.IsVisible;
            bool obvious = false;
            int doConf = 0;
            int doStun = 0;
            int doSleep = 0;
            int doFear = 0;
            string note = null;
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
            else if (rPtr.Stupid || rPtr.WeirdMind ||
                     rPtr.Animal || rPtr.Level > Program.Rng.DieRoll(3 * dam))
            {
                dam /= 3;
                note = " resists.";
                if ((rPtr.Undead || rPtr.Demon) &&
                    rPtr.Level > SaveGame.Player.Level / 2 && Program.Rng.DieRoll(2) == 1)
                {
                    note = null;
                    string s = seen ? "'s" : "s";
                    SaveGame.MsgPrint($"{mName}{s} corrupted mind backlashes your attack!");
                    if (Program.Rng.RandomLessThan(100) < SaveGame.Player.SkillSavingThrow)
                    {
                        SaveGame.MsgPrint("You resist the effects!");
                    }
                    else
                    {
                        string killer = mPtr.IndefiniteVisibleName;
                        SaveGame.Player.TakeHit(dam, killer);
                        if (Program.Rng.DieRoll(4) == 1)
                        {
                            switch (Program.Rng.DieRoll(4))
                            {
                                case 1:
                                    SaveGame.Player.SetTimedConfusion(SaveGame.Player.TimedConfusion + 3 + Program.Rng.DieRoll(dam));
                                    break;

                                case 2:
                                    SaveGame.Player.SetTimedStun(SaveGame.Player.TimedStun + Program.Rng.DieRoll(dam));
                                    break;

                                case 3:
                                    {
                                        if (rPtr.ImmuneFear)
                                        {
                                            note = " is unaffected.";
                                        }
                                        else
                                        {
                                            SaveGame.Player.SetTimedFear(SaveGame.Player.TimedFear + 3 + Program.Rng.DieRoll(dam));
                                        }
                                    }
                                    break;

                                default:
                                    if (!SaveGame.Player.HasFreeAction)
                                    {
                                        SaveGame.Player.SetTimedParalysis(SaveGame.Player.TimedParalysis + Program.Rng.DieRoll(dam));
                                    }
                                    break;
                            }
                        }
                    }
                    dam = 0;
                }
            }
            if (dam > 0 && Program.Rng.DieRoll(4) == 1)
            {
                switch (Program.Rng.DieRoll(4))
                {
                    case 1:
                        doConf = 3 + Program.Rng.DieRoll(dam);
                        break;

                    case 2:
                        doStun = 3 + Program.Rng.DieRoll(dam);
                        break;

                    case 3:
                        doFear = 3 + Program.Rng.DieRoll(dam);
                        break;

                    default:
                        doSleep = 3 + Program.Rng.DieRoll(dam);
                        break;
                }
            }
            string noteDies = " collapses, a mindless husk.";
            if (rPtr.Guardian)
            {
                if (who != 0 && dam > mPtr.Health)
                {
                    dam = mPtr.Health;
                }
            }
            if (rPtr.Guardian)
            {
                if (who > 0 && dam > mPtr.Health)
                {
                    dam = mPtr.Health;
                }
            }
            if (dam > mPtr.Health)
            {
                note = noteDies;
            }
            else if (doStun != 0 && !rPtr.BreatheSound &&
                     !rPtr.BreatheForce)
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
            else if (doConf != 0 && !rPtr.ImmuneConfusion &&
                     !rPtr.BreatheConfusion && !rPtr.BreatheChaos)
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
            if (doFear != 0)
            {
                tmp = mPtr.FearLevel + doFear;
                mPtr.FearLevel = tmp < 200 ? tmp : 200;
            }
            if (who != 0)
            {
                if (SaveGame.TrackedMonsterIndex == cPtr.MonsterIndex)
                {
                    SaveGame.Player.RedrawNeeded.Set(RedrawFlag.PrHealth);
                }
                mPtr.SleepLevel = 0;
                mPtr.Health -= dam;
                if (mPtr.Health < 0)
                {
                    bool sad = mPtr.SmFriendly && !mPtr.IsVisible;
                    SaveGame.MonsterDeath(cPtr.MonsterIndex);
                    SaveGame.Level.Monsters.DeleteMonsterByIndex(cPtr.MonsterIndex, true);
                    if (string.IsNullOrEmpty(note) == false)
                    {
                        SaveGame.MsgPrint($"{mName}{note}");
                    }
                    if (sad)
                    {
                        SaveGame.MsgPrint("You feel sad for a moment.");
                    }
                }
                else
                {
                    if (string.IsNullOrEmpty(note) == false && seen)
                    {
                        SaveGame.MsgPrint($"{mName}{note}");
                    }
                    else if (dam > 0)
                    {
                        SaveGame.Level.Monsters.MessagePain(cPtr.MonsterIndex, dam);
                    }
                    if (doSleep != 0)
                    {
                        mPtr.SleepLevel = doSleep;
                    }
                }
            }
            else
            {
                if (SaveGame.Level.Monsters.DamageMonster(cPtr.MonsterIndex, dam, out bool fear, noteDies))
                {
                }
                else
                {
                    if (string.IsNullOrEmpty(note) == false && seen)
                    {
                        SaveGame.MsgPrint($"{mName}{note}");
                    }
                    else if (dam > 0)
                    {
                        SaveGame.Level.Monsters.MessagePain(cPtr.MonsterIndex, dam);
                    }
                    if ((fear || doFear != 0) && mPtr.IsVisible)
                    {
                        SaveGame.PlaySound(SoundEffect.MonsterFlees);
                        SaveGame.MsgPrint($"{mName} flees in terror!");
                    }
                    if (doSleep != 0)
                    {
                        mPtr.SleepLevel = doSleep;
                    }
                }
            }
            return obvious;
        }
    }
}