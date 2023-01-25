// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Projection
{
    internal class ProjectMeteor : Projectile
    {
        public ProjectMeteor(SaveGame saveGame) : base(saveGame)
        {
        }

        protected override string BoltGraphic => "BrightRedSplat";

        protected override string EffectAnimation => "RedOrangeFlash";

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
                if (oPtr.HatesFire())
                {
                    doKill = true;
                    noteKill = plural ? " burn up!" : " burns up!";
                    if (oPtr.Characteristics.IgnoreFire)
                    {
                        ignore = true;
                    }
                }
                if (oPtr.HatesCold())
                {
                    ignore = false;
                    doKill = true;
                    noteKill = plural ? " shatter!" : " shatters!";
                    if (oPtr.Characteristics.IgnoreCold)
                    {
                        ignore = true;
                    }
                }
                if (doKill)
                {
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
            ApplyProjectileDamageToMonster(who, mPtr, dam, note);
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
                SaveGame.MsgPrint("Something falls from the sky on you!");
            }
            SaveGame.Player.TakeHit(dam, killer);
            if (!SaveGame.Player.HasShardResistance || Program.Rng.DieRoll(13) == 1)
            {
                if (!SaveGame.Player.HasFireImmunity)
                {
                    SaveGame.Player.InvenDamage(SaveGame.SetFireDestroy, 2);
                }
                SaveGame.Player.InvenDamage(SaveGame.SetColdDestroy, 2);
            }
            return true;
        }
    }
}