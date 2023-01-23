// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Projection
{
    internal class ProjectChaos : Projectile
    {
        public ProjectChaos(SaveGame saveGame) : base(saveGame)
        {
        }

        protected override string BoltGraphic => "PurpleBullet";

        protected override string ImpactGraphic => "PurpleSplat";

        protected override string EffectAnimation => "PinkPurpleFlash";

        protected override bool AffectFloor(int y, int x) => true;

        protected override bool AffectItem(int who, int y, int x)
        {
            GridTile cPtr = SaveGame.Level.Grid[y][x];
            int nextOIdx;
            bool obvious = false;
            string oName = "";
            for (int thisOIdx = cPtr.ItemIndex; thisOIdx != 0; thisOIdx = nextOIdx)
            {
                bool isArt = false;
                bool ignore = false;
                bool plural = false;
                Item oPtr = SaveGame.Level.Items[thisOIdx];
                nextOIdx = oPtr.NextInStack;
                oPtr.RefreshFlagBasedProperties();
                if (oPtr.Count > 1)
                {
                    plural = true;
                }
                if (oPtr.IsFixedArtifact() || string.IsNullOrEmpty(oPtr.RandartName) == false)
                {
                    isArt = true;
                }
                string noteKill = plural ? " are destroyed!" : " is destroyed!";
                if (oPtr.Characteristics.ResChaos)
                {
                    ignore = true;
                }
                if (oPtr.Marked)
                {
                    obvious = true;
                    oName = oPtr.Description(false, 0);
                }
                if (isArt || ignore)
                {
                    if (oPtr.Marked)
                    {
                        string s = plural ? "are" : "is";
                        SaveGame.MsgPrint($"The {oName} {s} unaffected!");
                    }
                }
                else
                {
                    if (oPtr.Marked && string.IsNullOrEmpty(noteKill))
                    {
                        SaveGame.MsgPrint($"The {oName}{noteKill}");
                    }
                    bool isPotion = oPtr.BaseItemCategory.CategoryEnum == ItemTypeEnum.Potion;
                    SaveGame.Level.DeleteObjectIdx(thisOIdx);
                    if (isPotion)
                    {
                        PotionItemClass potion = (PotionItemClass)oPtr.BaseItemCategory;
                        potion.Smash(SaveGame, who, y, x);
                    }
                    SaveGame.Level.RedrawSingleLocation(y, x);
                }
            }
            return obvious;
        }

        protected override bool AffectMonster(int who, Monster mPtr, int dam, int r)
        {
            GridTile cPtr = SaveGame.Level.Grid[mPtr.MapY][mPtr.MapX];
            int tmp;
            MonsterRace rPtr = mPtr.Race;
            bool seen = mPtr.IsVisible;
            bool obvious = false;
            string note = null;
            string noteDies = rPtr.DeathNote();
            string mName = mPtr.Name;
            if (seen)
            {
                obvious = true;
            }
            bool doPoly = true;
            int doConf = (5 + Program.Rng.DieRoll(11) + r) / (r + 1);
            if (rPtr.BreatheChaos ||
                (rPtr.Demon && Program.Rng.DieRoll(3) == 1))
            {
                note = " resists.";
                dam *= 3;
                dam /= Program.Rng.DieRoll(6) + 6;
                doPoly = false;
            }
            if (rPtr.Unique)
            {
                doPoly = false;
            }
            if (rPtr.Guardian)
            {
                doPoly = false;
            }
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
            else if (doPoly && Program.Rng.DieRoll(90) > rPtr.Level)
            {
                note = " is unaffected!";
                bool charm = mPtr.SmFriendly;
                tmp = SaveGame.PolymorphMonster(mPtr.Race);
                if (tmp != mPtr.Race.Index)
                {
                    note = " changes!";
                    dam = 0;
                    SaveGame.Level.Monsters.DeleteMonsterByIndex(cPtr.MonsterIndex, true);
                    MonsterRace race = SaveGame.SingletonRepository.MonsterRaces[tmp];
                    SaveGame.Level.Monsters.PlaceMonsterAux(mPtr.MapY, mPtr.MapX, race, false, false, charm);
                    mPtr = SaveGame.Level.Monsters[cPtr.MonsterIndex];
                }
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
            if (who != 0)
            {
                if (SaveGame.TrackedMonsterIndex == cPtr.MonsterIndex)
                {
                    SaveGame.RedrawHealthFlaggedAction.Set();
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
                    if (fear && mPtr.IsVisible)
                    {
                        SaveGame.PlaySound(SoundEffect.MonsterFlees);
                        SaveGame.MsgPrint($"{mName} flees in terror!");
                    }
                }
            }
            return obvious;
        }

        protected override bool AffectPlayer(int who, int r, int y, int x, int dam, int aRad)
        {
            bool blind = SaveGame.Player.TimedBlindness.TimeRemaining != 0;
            if (dam > 1600)
            {
                dam = 1600;
            }
            dam = (dam + r) / (r + 1);
            Monster mPtr = SaveGame.Level.Monsters[who];
            string killer = mPtr.IndefiniteVisibleName;
            if (blind)
            {
                SaveGame.MsgPrint("You are hit by a wave of anarchy!");
            }
            if (SaveGame.Player.HasChaosResistance)
            {
                dam *= 6;
                dam /= Program.Rng.DieRoll(6) + 6;
            }
            if (!SaveGame.Player.HasConfusionResistance)
            {
                SaveGame.Player.TimedConfusion.SetTimer(SaveGame.Player.TimedConfusion.TimeRemaining + Program.Rng.RandomLessThan(20) + 10);
            }
            if (!SaveGame.Player.HasChaosResistance)
            {
                SaveGame.Player.TimedHallucinations.SetTimer(SaveGame.Player.TimedHallucinations.TimeRemaining + Program.Rng.DieRoll(10));
                if (Program.Rng.DieRoll(3) == 1)
                {
                    SaveGame.MsgPrint("Your body is twisted by chaos!");
                    SaveGame.Player.Dna.GainMutation(SaveGame);
                }
            }
            if (!SaveGame.Player.HasNetherResistance && !SaveGame.Player.HasChaosResistance)
            {
                if (SaveGame.Player.HasHoldLife && Program.Rng.RandomLessThan(100) < 75)
                {
                    SaveGame.MsgPrint("You keep hold of your life force!");
                }
                else if (Program.Rng.DieRoll(10) <= SaveGame.Player.Religion.GetNamedDeity(Pantheon.GodName.Hagarg_Ryonis).AdjustedFavour)
                {
                    SaveGame.MsgPrint("Hagarg Ryonis's favour protects you!");
                }
                else if (SaveGame.Player.HasHoldLife)
                {
                    SaveGame.MsgPrint("You feel your life slipping away!");
                    SaveGame.Player.LoseExperience(500 + (SaveGame.Player.ExperiencePoints / 1000 * Constants.MonDrainLife));
                }
                else
                {
                    SaveGame.MsgPrint("You feel your life draining away!");
                    SaveGame.Player.LoseExperience(5000 + (SaveGame.Player.ExperiencePoints / 100 * Constants.MonDrainLife));
                }
            }
            if (!SaveGame.Player.HasChaosResistance || Program.Rng.DieRoll(9) == 1)
            {
                SaveGame.Player.InvenDamage(SaveGame.SetElecDestroy, 2);
                SaveGame.Player.InvenDamage(SaveGame.SetFireDestroy, 2);
            }
            SaveGame.Player.TakeHit(dam, killer);
            return true;
        }
    }
}