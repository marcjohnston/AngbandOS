// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Projection;

[Serializable]
internal class TimeProjectile : Projectile
{
    private TimeProjectile(SaveGame saveGame) : base(saveGame) { }

    protected override ProjectileGraphic? BoltProjectileGraphic => SaveGame.SingletonRepository.ProjectileGraphics.Get(nameof(BrightGreenBoltProjectileGraphic));

    protected override Animation EffectAnimation => SaveGame.SingletonRepository.Animations.Get(nameof(BrightGreenCloudAnimation));

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
        if (rPtr.BreatheTime)
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
        int k = 0;
        bool blind = SaveGame.TimedBlindness.TurnsRemaining != 0;
        string act = null;
        if (dam > 1600)
        {
            dam = 1600;
        }
        dam = (dam + r) / (r + 1);
        Monster mPtr = SaveGame.Monsters[who];
        string killer = mPtr.IndefiniteVisibleName;
        if (blind)
        {
            SaveGame.MsgPrint("You are hit by a blast from the past!");
        }
        if (SaveGame.HasTimeResistance)
        {
            dam *= 4;
            dam /= SaveGame.Rng.DieRoll(6) + 6;
            SaveGame.MsgPrint("You feel as if time is passing you by.");
        }
        else
        {
            switch (SaveGame.Rng.DieRoll(10))
            {
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                    {
                        SaveGame.MsgPrint("You feel life has clocked back.");
                        SaveGame.LoseExperience(100 + (SaveGame.ExperiencePoints / 100 * Constants.MonDrainLife));
                        break;
                    }
                case 6:
                case 7:
                case 8:
                case 9:
                    {
                        switch (SaveGame.Rng.DieRoll(6))
                        {
                            case 1:
                                k = Ability.Strength;
                                act = "strong";
                                break;

                            case 2:
                                k = Ability.Intelligence;
                                act = "bright";
                                break;

                            case 3:
                                k = Ability.Wisdom;
                                act = "wise";
                                break;

                            case 4:
                                k = Ability.Dexterity;
                                act = "agile";
                                break;

                            case 5:
                                k = Ability.Constitution;
                                act = "hale";
                                break;

                            case 6:
                                k = Ability.Charisma;
                                act = "beautiful";
                                break;
                        }
                        SaveGame.MsgPrint($"You're not as {act} as you used to be...");
                        SaveGame.AbilityScores[k].Innate = SaveGame.AbilityScores[k].Innate * 3 / 4;
                        if (SaveGame.AbilityScores[k].Innate < 3)
                        {
                            SaveGame.AbilityScores[k].Innate = 3;
                        }
                        SaveGame.SingletonRepository.FlaggedActions.Get(nameof(UpdateBonusesFlaggedAction)).Set();
                        break;
                    }
                case 10:
                    {
                        SaveGame.MsgPrint("You're not as powerful as you used to be...");
                        for (k = 0; k < 6; k++)
                        {
                            SaveGame.AbilityScores[k].Innate = SaveGame.AbilityScores[k].Innate * 3 / 4;
                            if (SaveGame.AbilityScores[k].Innate < 3)
                            {
                                SaveGame.AbilityScores[k].Innate = 3;
                            }
                        }
                        SaveGame.SingletonRepository.FlaggedActions.Get(nameof(UpdateBonusesFlaggedAction)).Set();
                        break;
                    }
            }
        }
        SaveGame.TakeHit(dam, killer);
        return true;
    }
}