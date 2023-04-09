// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

using AngbandOS.Core.Hooks;

namespace AngbandOS.Core.Projection
{
    internal class HellFireProjectile : Projectile
    {
        public HellFireProjectile(SaveGame saveGame) : base(saveGame)
        {
        }

        protected override ProjectileGraphic? BoltProjectileGraphic => SaveGame.SingletonRepository.ProjectileGraphics.Get<RedSplatProjectileGraphic>();

        protected override Animation EffectAnimation => SaveGame.SingletonRepository.Animations.Get<RedBlackFlashAnimation>();

        protected override bool AffectItem(int who, int y, int x)
        {
            GridTile cPtr = SaveGame.Level.Grid[y][x];
            int nextOIdx;
            bool obvious = false;
            string oName = "";
            foreach (Item oPtr in cPtr.Items)
            {
                bool isArt = false;
                bool plural = false;
                bool doKill = false;
                string noteKill = null;
                if (oPtr.Count > 1)
                {
                    plural = true;
                }
                if (oPtr.FixedArtifact != null || string.IsNullOrEmpty(oPtr.RandartName) == false)
                {
                    isArt = true;
                }
                if (oPtr.IsCursed())
                {
                    doKill = true;
                    noteKill = plural ? " are destroyed!" : " is destroyed!";
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
                    bool isPotion = oPtr.BaseItemCategory.CategoryEnum == ItemTypeEnum.Potion;
                    SaveGame.Level.DeleteObject(oPtr);
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
            MonsterRace rPtr = mPtr.Race;
            bool seen = mPtr.IsVisible;
            bool obvious = false;
            string? note = null;
            if (seen)
            {
                obvious = true;
            }
            if (rPtr.Evil)
            {
                dam *= 2;
                note = " is hit hard.";
                if (seen)
                {
                    rPtr.Knowledge.Characteristics.Evil = true;
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
                SaveGame.MsgPrint("You are hit by something!");
            }
            
            if (SaveGame.Player.PrimaryRealm.ResistantToHolyAndHellProjectiles || SaveGame.Player.SecondaryRealm.ResistantToHolyAndHellProjectiles)
            {
                dam /= 2;
            }
            else if (SaveGame.Player.PrimaryRealm.SusceptibleToHolyAndHellProjectiles || SaveGame.Player.SecondaryRealm.SusceptibleToHolyAndHellProjectiles)
            {
                dam *= 2;
            }
            SaveGame.Player.TakeHit(dam, killer);
            return true;
        }
    }
}