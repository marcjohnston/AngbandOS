// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Projection;

[Serializable]
internal class SoundProjectile : Projectile
{
    private SoundProjectile(SaveGame saveGame) : base(saveGame) { }

    protected override ProjectileGraphic? BoltProjectileGraphic => SaveGame.SingletonRepository.ProjectileGraphics.Get(nameof(GoldSplatProjectileGraphic));

    protected override Animation EffectAnimation => SaveGame.SingletonRepository.Animations.Get(nameof(GoldCloudAnimation));

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
            if (oPtr.HatesCold())
            {
                noteKill = plural ? " shatter!" : " shatters!";
                doKill = true;
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
        int doStun = (10 + SaveGame.Rng.DieRoll(15) + r) / (r + 1);
        if (rPtr.BreatheSound)
        {
            note = " resists.";
            dam *= 2;
            dam /= SaveGame.Rng.DieRoll(6) + 6;
        }
        if (doStun != 0 && !rPtr.BreatheSound && !rPtr.BreatheForce)
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
            SaveGame.MsgPrint("You are hit by a loud noise!");
        }
        if (SaveGame.HasSoundResistance)
        {
            dam *= 5;
            dam /= SaveGame.Rng.DieRoll(6) + 6;
        }
        else
        {
            int kk = SaveGame.Rng.DieRoll(dam > 90 ? 35 : (dam / 3) + 5);
            SaveGame.TimedStun.AddTimer(kk);
        }
        if (!SaveGame.HasSoundResistance || SaveGame.Rng.DieRoll(13) == 1)
        {
            SaveGame.InvenDamage(SaveGame.SetColdDestroy, 2);
        }
        SaveGame.TakeHit(dam, killer);
        return true;
    }
}