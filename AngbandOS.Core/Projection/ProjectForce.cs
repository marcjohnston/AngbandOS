// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
using AngbandOS.Enumerations;

using AngbandOS.Core.Interface;
using AngbandOS.Core.ItemCategories;
using AngbandOS.Core;
using AngbandOS.Core.MonsterRaces;
using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Projection
{
    internal class ProjectForce : Projectile
    {
        public ProjectForce(SaveGame saveGame) : base(saveGame)
        {
        }

        protected override string BoltGraphic => "BrightTurquoiseBolt";

        protected override string ImpactGraphic => "BrightTurquoiseSplat";

        protected override bool AffectItem(int who, int y, int x)
        {
            GridTile cPtr = SaveGame.Level.Grid[y][x];
            int nextOIdx;
            bool obvious = false;
            string oName = "";
            for (int thisOIdx = cPtr.ItemIndex; thisOIdx != 0; thisOIdx = nextOIdx)
            {
                bool isArt = false;
                bool plural = false;
                bool doKill = false;
                string noteKill = null;
                Item oPtr = SaveGame.Level.Items[thisOIdx];
                nextOIdx = oPtr.NextInStack;
                if (oPtr.Count > 1)
                {
                    plural = true;
                }
                if (oPtr.IsFixedArtifact() || string.IsNullOrEmpty(oPtr.RandartName) == false)
                {
                    isArt = true;
                }
                if (oPtr.HatesCold())
                {
                    noteKill = plural ? " shatter!" : " shatters!";
                    doKill = true;
                }
                if (doKill)
                {
                    if (oPtr.Marked)
                    {
                        obvious = true;
                        oName = oPtr.Description(false, 0);
                    }
                    if (isArt)
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
                        int oSval = oPtr.ItemSubCategory;
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
            }
            return obvious;
        }

        protected override bool AffectMonster(int who, Monster mPtr, int dam, int r)
        {
            GridTile cPtr = SaveGame.Level.Grid[mPtr.MapY][mPtr.MapX];
            MonsterRace rPtr = mPtr.Race;
            bool seen = mPtr.IsVisible;
            bool obvious = false;
            string note = null;
            string noteDies = NoteDiesOrIsDestroyed(rPtr);
            string mName = mPtr.MonsterDesc(0);
            if (seen)
            {
                obvious = true;
            }
            int doStun = (Program.Rng.DieRoll(15) + r) / (r + 1);
            if (rPtr.BreatheForce)
            {
                note = " resists.";
                dam *= 3;
                dam /= Program.Rng.DieRoll(6) + 6;
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
            else if (doStun != 0 && !rPtr.BreatheSound &&
                     !rPtr.BreatheForce)
            {
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
                    bool sad = (mPtr.Mind & Constants.SmFriendly) != 0 && !mPtr.IsVisible;
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
            bool blind = SaveGame.Player.TimedBlindness != 0;
            if (dam > 1600)
            {
                dam = 1600;
            }
            dam = (dam + r) / (r + 1);
            Monster mPtr = SaveGame.Level.Monsters[who];
            string killer = mPtr.MonsterDesc(0x88);
            if (blind)
            {
                SaveGame.MsgPrint("You are hit by kinetic force!");
            }
            if (!SaveGame.Player.HasSoundResistance)
            {
                SaveGame.Player.SetTimedStun(SaveGame.Player.TimedStun + Program.Rng.DieRoll(20));
            }
            SaveGame.Player.TakeHit(dam, killer);
            return true;
        }
    }
}