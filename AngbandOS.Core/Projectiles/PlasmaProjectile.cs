// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Projection
{
    internal class PlasmaProjectile : Projectile
    {
        public PlasmaProjectile(SaveGame saveGame) : base(saveGame)
        {
        }

        protected override string BoltGraphic => "BrightRedBolt";

        protected override string ImpactGraphic => "BrightRedSplat";

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
                bool doKill = false;
                string noteKill = null;
                Item? oPtr = SaveGame.GetLevelItem(thisOIdx);
                nextOIdx = (oPtr == null ? 0 : oPtr.NextInStack);
                if (oPtr != null)
                {
                    oPtr.RefreshFlagBasedProperties();
                    if (oPtr.Count > 1)
                    {
                        plural = true;
                    }
                    if (oPtr.IsFixedArtifact() || string.IsNullOrEmpty(oPtr.RandartName) == false)
                    {
                        isArt = true;
                    }
                    if (oPtr.HatesFire())
                    {
                        doKill = true;
                        noteKill = plural ? " burn up!" : " burns up!";
                        if (oPtr.Characteristics.IgnoreFire)
                        {
                            ignore = true;
                        }
                    }
                    if (oPtr.HatesElec())
                    {
                        ignore = false;
                        doKill = true;
                        noteKill = plural ? " are destroyed!" : " is destroyed!";
                        if (oPtr.Characteristics.IgnoreElec)
                        {
                            ignore = true;
                        }
                    }
                    if (!doKill)
                    {
                        continue;
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
            }
            return obvious;
        }

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
            if (rPtr.ResistPlasma)
            {
                note = " resists.";
                dam *= 3;
                dam /= Program.Rng.DieRoll(6) + 6;
                if (seen)
                {
                    rPtr.Knowledge.Characteristics.ResistPlasma = true;
                }
            }
            ApplyProjectileDamageToMonster(who, mPtr, dam, note);
            return obvious;
        }

        protected override bool AffectPlayer(int who, int r, int y, int x, int dam, int aRad)
        {
            bool blind = SaveGame.Player.TimedBlindness.TurnsRemaining != 0;
            if (dam > 1600)
            {
                dam = 1600;
            }
            dam = (dam + r) / (r + 1);
            Monster mPtr = SaveGame.Level.Monsters[who];
            string killer = mPtr.IndefiniteVisibleName;
            if (blind)
            {
                SaveGame.MsgPrint("You are hit by something *HOT*!");
            }
            SaveGame.Player.TakeHit(dam, killer);
            if (!SaveGame.Player.HasSoundResistance)
            {
                int kk = Program.Rng.DieRoll(dam > 40 ? 35 : (dam * 3 / 4) + 5);
                SaveGame.Player.TimedStun.AddTimer(kk);
            }
            if (!(SaveGame.Player.HasFireResistance || SaveGame.Player.TimedFireResistance.TurnsRemaining != 0 || SaveGame.Player.HasFireImmunity))
            {
                SaveGame.Player.InvenDamage(SaveGame.SetAcidDestroy, 3);
            }
            return true;
        }
    }
}