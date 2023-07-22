// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Projection;

[Serializable]
internal class ChaosProjectile : Projectile
{
    private ChaosProjectile(SaveGame saveGame) : base(saveGame) { }

    protected override ProjectileGraphic? BoltProjectileGraphic => SaveGame.SingletonRepository.ProjectileGraphics.Get<PurpleBulletProjectileGraphic>();

    protected override ProjectileGraphic? ImpactProjectileGraphic => SaveGame.SingletonRepository.ProjectileGraphics.Get<PurpleSplatProjectileGraphic>();

    protected override Animation? EffectAnimation => SaveGame.SingletonRepository.Animations.Get<PinkPurpleFlashAnimation>();

    protected override bool AffectFloor(int y, int x) => true;

    protected override bool AffectItem(int who, int y, int x)
    {
        GridTile cPtr = SaveGame.Level.Grid[y][x];
        bool obvious = false;
        string oName = "";
        foreach (Item oPtr in cPtr.Items)
        {
            bool isArt = false;
            bool ignore = false;
            bool plural = false;
            oPtr.RefreshFlagBasedProperties();
            if (oPtr.Count > 1)
            {
                plural = true;
            }
            if (oPtr.FixedArtifact != null || string.IsNullOrEmpty(oPtr.RandartName) == false)
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
                bool isPotion = oPtr.Factory.CategoryEnum == ItemTypeEnum.Potion;
                SaveGame.Level.DeleteObject(oPtr);
                if (isPotion)
                {
                    PotionItemFactory potion = (PotionItemFactory)oPtr.Factory;
                    potion.Smash(who, y, x);
                }
                SaveGame.Level.RedrawSingleLocation(y, x);
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
        string? note = null;
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
        if (doPoly && Program.Rng.DieRoll(90) > rPtr.Level)
        {
            note = " is unaffected!";
            bool charm = mPtr.SmFriendly;
            int tmp = SaveGame.PolymorphMonster(mPtr.Race);
            if (tmp != mPtr.Race.Index)
            {
                note = " changes!";
                dam = 0;
                SaveGame.Level.DeleteMonsterByIndex(cPtr.MonsterIndex, true);
                MonsterRace race = SaveGame.SingletonRepository.MonsterRaces[tmp];
                SaveGame.Level.PlaceMonsterAux(mPtr.MapY, mPtr.MapX, race, false, false, charm);
                mPtr = SaveGame.Level.Monsters[cPtr.MonsterIndex];
            }
        }
        else if (doConf != 0 && !rPtr.ImmuneConfusion && !rPtr.BreatheConfusion && !rPtr.BreatheChaos)
        {
            int tmp;
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
        Monster mPtr = SaveGame.Level.Monsters[who];
        string killer = mPtr.IndefiniteVisibleName;
        if (blind)
        {
            SaveGame.MsgPrint("You are hit by a wave of anarchy!");
        }
        if (SaveGame.HasChaosResistance)
        {
            dam *= 6;
            dam /= Program.Rng.DieRoll(6) + 6;
        }
        if (!SaveGame.HasConfusionResistance)
        {
            SaveGame.TimedConfusion.AddTimer(Program.Rng.RandomLessThan(20) + 10);
        }
        if (!SaveGame.HasChaosResistance)
        {
            SaveGame.TimedHallucinations.AddTimer(Program.Rng.DieRoll(10));
            if (Program.Rng.DieRoll(3) == 1)
            {
                SaveGame.MsgPrint("Your body is twisted by chaos!");
                SaveGame.Dna.GainMutation();
            }
        }
        if (!SaveGame.HasNetherResistance && !SaveGame.HasChaosResistance)
        {
            if (SaveGame.HasHoldLife && Program.Rng.RandomLessThan(100) < 75)
            {
                SaveGame.MsgPrint("You keep hold of your life force!");
            }
            else if (Program.Rng.DieRoll(10) <= SaveGame.Religion.GetNamedDeity(Pantheon.GodName.Hagarg_Ryonis).AdjustedFavour)
            {
                SaveGame.MsgPrint("Hagarg Ryonis's favour protects you!");
            }
            else if (SaveGame.HasHoldLife)
            {
                SaveGame.MsgPrint("You feel your life slipping away!");
                SaveGame.LoseExperience(500 + (SaveGame.ExperiencePoints / 1000 * Constants.MonDrainLife));
            }
            else
            {
                SaveGame.MsgPrint("You feel your life draining away!");
                SaveGame.LoseExperience(5000 + (SaveGame.ExperiencePoints / 100 * Constants.MonDrainLife));
            }
        }
        if (!SaveGame.HasChaosResistance || Program.Rng.DieRoll(9) == 1)
        {
            SaveGame.InvenDamage(SaveGame.SetElecDestroy, 2);
            SaveGame.InvenDamage(SaveGame.SetFireDestroy, 2);
        }
        SaveGame.TakeHit(dam, killer);
        return true;
    }
}