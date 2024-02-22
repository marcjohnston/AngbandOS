// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Projection;

[Serializable]
internal class PlasmaProjectile : Projectile
{
    private PlasmaProjectile(SaveGame saveGame) : base(saveGame) { }

    protected override ProjectileGraphic? BoltProjectileGraphic => SaveGame.SingletonRepository.ProjectileGraphics.Get(nameof(BrightRedBoltProjectileGraphic));

    protected override ProjectileGraphic? ImpactProjectileGraphic => SaveGame.SingletonRepository.ProjectileGraphics.Get(nameof(BrightRedSplatProjectileGraphic));

    protected override bool AffectItem(int who, int y, int x)
    {
        GridTile cPtr = SaveGame.Grid[y][x];
        bool obvious = false;
        string oName = "";
        foreach (Item oPtr in cPtr.Items)
        {
            bool ignore = false;
            bool plural = false;
            bool doKill = false;
            string noteKill = null;
            oPtr.RefreshFlagBasedProperties();
            if (oPtr.Count > 1)
            {
                plural = true;
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
            if (oPtr.IsArtifact || ignore)
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
            dam /= SaveGame.DieRoll(6) + 6;
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
            SaveGame.MsgPrint("You are hit by something *HOT*!");
        }
        SaveGame.TakeHit(dam, killer);
        if (!SaveGame.HasSoundResistance)
        {
            int kk = SaveGame.DieRoll(dam > 40 ? 35 : (dam * 3 / 4) + 5);
            SaveGame.TimedStun.AddTimer(kk);
        }
        if (!(SaveGame.HasFireResistance || SaveGame.TimedFireResistance.TurnsRemaining != 0 || SaveGame.HasFireImmunity))
        {
            SaveGame.InvenDamage(SaveGame.SetAcidDestroy, 3);
        }
        return true;
    }
}