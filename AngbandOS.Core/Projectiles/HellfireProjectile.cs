﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Projection;

[Serializable]
internal class HellfireProjectile : Projectile
{
    private HellfireProjectile(Game game) : base(game) { }

    protected override ProjectileGraphic? BoltProjectileGraphic => Game.SingletonRepository.ProjectileGraphics.Get(nameof(RedSplatProjectileGraphic));

    protected override Animation EffectAnimation => Game.SingletonRepository.Animations.Get(nameof(RedBlackFlashAnimation));

    protected override bool AffectItem(int who, int y, int x)
    {
        GridTile cPtr = Game.Map.Grid[y][x];
        bool obvious = false;
        string oName = "";
        foreach (Item oPtr in cPtr.Items)
        {
            bool plural = false;
            bool doKill = false;
            string noteKill = null;
            if (oPtr.Count > 1)
            {
                plural = true;
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
            if (oPtr.IsArtifact)
            {
                if (oPtr.Marked)
                {
                    string s = plural ? "are" : "is";
                    Game.MsgPrint($"The {oName} {s} unaffected!");
                }
            }
            else
            {
                if (oPtr.Marked && string.IsNullOrEmpty(noteKill))
                {
                    Game.MsgPrint($"The {oName}{noteKill}");
                }
                bool isPotion = oPtr.Factory.CategoryEnum == ItemTypeEnum.Potion;
                Game.DeleteObject(oPtr);
                if (isPotion)
                {
                    PotionItemFactory potion = (PotionItemFactory)oPtr.Factory;
                    potion.Smash(who, y, x);
                }
                Game.MainForm.RefreshMapLocation(y, x);
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
        bool blind = Game.BlindnessTimer.Value != 0;
        if (dam > 1600)
        {
            dam = 1600;
        }
        dam = (dam + r) / (r + 1);
        Monster mPtr = Game.Monsters[who];
        string killer = mPtr.IndefiniteVisibleName;
        if (blind)
        {
            Game.MsgPrint("You are hit by something!");
        }
        
        if (Game.PrimaryRealm.ResistantToHolyAndHellProjectiles || Game.SecondaryRealm.ResistantToHolyAndHellProjectiles)
        {
            dam /= 2;
        }
        else if (Game.PrimaryRealm.SusceptibleToHolyAndHellProjectiles || Game.SecondaryRealm.SusceptibleToHolyAndHellProjectiles)
        {
            dam *= 2;
        }
        Game.TakeHit(dam, killer);
        return true;
    }
}