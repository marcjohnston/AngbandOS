﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Projection;

[Serializable]
internal class HolyFireProjectile : Projectile
{
    private HolyFireProjectile(SaveGame saveGame) : base(saveGame) { }

    protected override ProjectileGraphic? BoltProjectileGraphic => SaveGame.SingletonRepository.ProjectileGraphics.Get<BrightRedSplatProjectileGraphic>();

    protected override Animation EffectAnimation => SaveGame.SingletonRepository.Animations.Get<RedWhiteFlashAnimation>();

    protected override bool AffectItem(int who, int y, int x)
    {
        GridTile cPtr = SaveGame.Grid[y][x];
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
                    bool isPotion = oPtr.Factory.CategoryEnum == ItemTypeEnum.Potion;
                    SaveGame.DeleteObject(oPtr);
                    if (isPotion)
                    {
                        PotionItemFactory potion = (PotionItemFactory)oPtr.Factory;
                        potion.Smash(who, y, x);
                    }
                    SaveGame.RedrawSingleLocation(y, x);
                }
            }
        }
        return obvious;
    }

    protected override bool ProjectileAngersMonster(Monster mPtr)
    {
        // Only good friends are affected.
        MonsterRace rPtr = mPtr.Race;
        return rPtr.Good;
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
        if (rPtr.Good)
        {
            dam = 0;
            note = " is immune.";
            if (seen)
            {
                rPtr.Knowledge.Characteristics.Good = true;
            }
        }
        else if (rPtr.Evil)
        {
            dam *= 2;
            note = " is hit hard.";
            if (seen)
            {
                rPtr.Knowledge.Characteristics.Evil = true;
            }
        }
        else
        {
            note = " resists.";
            dam *= 3;
            dam /= SaveGame.Rng.DieRoll(6) + 6;
        }
        ApplyProjectileDamageToMonster(who, mPtr, dam, note);
        return obvious;
    }

    protected override bool AffectPlayer(int who, int r, int y, int x, int dam, int aRad)
    {
        bool blind = SaveGame.TimedBlindness.TurnsRemaining != 0;
        if (dam > 1600)
        {
            dam = 1600;
        }
        dam = (dam + r) / (r + 1);
        Monster mPtr = SaveGame.Monsters[who];
        string killer = mPtr.IndefiniteVisibleName;
        if (blind)
        {
            SaveGame.MsgPrint("You are hit by something!");
        }
        if (SaveGame.PrimaryRealm.ResistantToHolyAndHellProjectiles || SaveGame.SecondaryRealm.ResistantToHolyAndHellProjectiles)
        {
            dam /= 2;
        }
        else if (SaveGame.PrimaryRealm.SusceptibleToHolyAndHellProjectiles || SaveGame.SecondaryRealm.SusceptibleToHolyAndHellProjectiles)
        {
            dam *= 2;
        }
        SaveGame.TakeHit(dam, killer);
        return true;
    }
}