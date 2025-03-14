// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Projectiles;

[Serializable]
internal class TimeProjectile : Projectile
{
    private TimeProjectile(Game game) : base(game) { }

    protected override ProjectileGraphic? BoltProjectileGraphic => Game.SingletonRepository.Get<ProjectileGraphic>(nameof(BrightGreenBoltProjectileGraphic));

    protected override Animation EffectAnimation => Game.SingletonRepository.Get<Animation>(nameof(BrightGreenCloudAnimation));

    protected override string AffectMonsterScriptBindingKey => nameof(TimeMonsterEffect);

    protected override bool AffectPlayer(int who, int r, int y, int x, int dam, int aRad)
    {
        int k = 0;
        bool blind = Game.BlindnessTimer.Value != 0;
        string act = null;
        if (dam > 1600)
        {
            dam = 1600;
        }
        dam = (dam + r) / (r + 1);
        Monster mPtr = Game.Monsters[who];
        string killer = mPtr.IndefiniteVisibleName;
        if (blind)
        {
            Game.MsgPrint("You are hit by a blast from the past!");
        }
        if (Game.HasTimeResistance)
        {
            dam *= 4;
            dam /= Game.DieRoll(6) + 6;
            Game.MsgPrint("You feel as if time is passing you by.");
        }
        else
        {
            switch (Game.DieRoll(10))
            {
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                    {
                        Game.MsgPrint("You feel life has clocked back.");
                        Game.LoseExperience(100 + (Game.ExperiencePoints.IntValue / 100 * Constants.MonDrainLife));
                        break;
                    }
                case 6:
                case 7:
                case 8:
                case 9:
                    {
                        switch (Game.DieRoll(6))
                        {
                            case 1:
                                k = AbilityEnum.Strength;
                                act = "strong";
                                break;

                            case 2:
                                k = AbilityEnum.Intelligence;
                                act = "bright";
                                break;

                            case 3:
                                k = AbilityEnum.Wisdom;
                                act = "wise";
                                break;

                            case 4:
                                k = AbilityEnum.Dexterity;
                                act = "agile";
                                break;

                            case 5:
                                k = AbilityEnum.Constitution;
                                act = "hale";
                                break;

                            case 6:
                                k = AbilityEnum.Charisma;
                                act = "beautiful";
                                break;
                        }
                        Game.MsgPrint($"You're not as {act} as you used to be...");
                        Game.AbilityScores[k].Innate = Game.AbilityScores[k].Innate * 3 / 4;
                        if (Game.AbilityScores[k].Innate < 3)
                        {
                            Game.AbilityScores[k].Innate = 3;
                        }
                        Game.SingletonRepository.Get<FlaggedAction>(nameof(UpdateBonusesFlaggedAction)).Set();
                        break;
                    }
                case 10:
                    {
                        Game.MsgPrint("You're not as powerful as you used to be...");
                        for (k = 0; k < 6; k++)
                        {
                            Game.AbilityScores[k].Innate = Game.AbilityScores[k].Innate * 3 / 4;
                            if (Game.AbilityScores[k].Innate < 3)
                            {
                                Game.AbilityScores[k].Innate = 3;
                            }
                        }
                        Game.SingletonRepository.Get<FlaggedAction>(nameof(UpdateBonusesFlaggedAction)).Set();
                        break;
                    }
            }
        }
        Game.TakeHit(dam, killer);
        return true;
    }
}