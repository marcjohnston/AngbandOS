// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Races;

[Serializable]
internal class VampireRace : Race
{
    private VampireRace(SaveGame saveGame) : base(saveGame) { }
    public override string Title => "Vampire";
    public override int[] AbilityBonus => new int[] { 3, 3, -1, -1, 1, 2 };
    public override int BaseDisarmBonus => 4;
    public override int BaseDeviceBonus => 10;
    public override int BaseSaveBonus => 10;
    public override int BaseStealthBonus => 4;
    public override int BaseSearchBonus => 1;
    public override int BaseSearchFrequency => 8;
    public override int BaseMeleeAttackBonus => 5;
    public override int BaseRangedAttackBonus => 0;
    public override int HitDieBonus => 11;
    public override int ExperienceFactor => 200;
    public override int BaseAge => 100;
    public override int AgeRange => 30;
    public override int MaleBaseHeight => 72;
    public override int MaleHeightRange => 6;
    public override int MaleBaseWeight => 180;
    public override int MaleWeightRange => 25;
    public override int FemaleBaseHeight => 66;
    public override int FemaleHeightRange => 4;
    public override int FemaleBaseWeight => 150;
    public override int FemaleWeightRange => 20;
    public override int Infravision => 5;
    public override uint Choice => 0xFFFF;
    public override string Description => "Vampires are powerful undead. They resist darkness, nether,\ncold, poison, and having their life force drained. Vampires\nproduce their own ethereal light in the dark, but are hurt\nby direct sunlight. They can learn to drain the life force\nfrom their foes (at lvl 2).";

    /// <summary>
    /// Vampire 113->114->115->116->117->End
    /// </summary>
    public override int Chart => 113;

    public override string RacialPowersDescription(int lvl) => lvl < 2 ? "drain life         (racial, unusable until level 2)" : "drain life         (racial, cost 1 + lvl/3, based)";
    public override bool HasRacialPowers => true;
    public override void UpdateRacialAbilities(int level, ItemCharacteristics itemCharacteristics)
    {
        itemCharacteristics.HoldLife = true;
        itemCharacteristics.ResDark = true;
        itemCharacteristics.ResNether = true;
        itemCharacteristics.Lightsource = true;
        itemCharacteristics.ResPois = true;
        itemCharacteristics.ResCold = true;
    }
    public override string CreateRandomName() => CreateRandomNameFromSyllables(new HumanSyllables());

    public override string[]? SelfKnowledge(int level)
    {
        if (level > 1)
        {
            return new string[] { $"You can steal life from a foe, dam. {level + Math.Max(1, level / 10)}-{level + (level * Math.Max(1, level / 10))} (cost {1 + (level / 3)})." };
        }
        return null;
    }
    public override void CalcBonuses()
    {
        SaveGame.HasDarkResistance = true;
        SaveGame.HasHoldLife = true;
        SaveGame.HasNetherResistance = true;
        SaveGame.HasColdResistance = true;
        SaveGame.HasPoisonResistance = true;
        SaveGame.HasGlow = true;
    }
    public override bool RestsTillDuskInsteadOfDawn => true;

    public override bool IsBurnedBySunlight => true;

    public override bool IsDamagedByDarkness => false;

    public override void Eat(FoodItem item)
    {
        // Vampires only get 1/10th of the food value
        SaveGame.SetFood(SaveGame.Food + (item.TypeSpecificValue / 10));
        SaveGame.MsgPrint("Mere victuals hold scant sustenance for a being such as yourself.");
        if (SaveGame.Food < Constants.PyFoodAlert)
        {
            SaveGame.MsgPrint("Your hunger can only be satisfied with fresh blood!");
        }
    }

    public override void UseRacialPower()
    {
        // Vampires can drain health
        if (SaveGame.CheckIfRacialPowerWorks(2, 1 + (SaveGame.ExperienceLevel / 3), Ability.Constitution, 9))
        {
            if (SaveGame.GetDirectionNoAim(out int direction))
            {
                int y = SaveGame.MapY + SaveGame.KeypadDirectionYOffset[direction];
                int x = SaveGame.MapX + SaveGame.KeypadDirectionXOffset[direction];
                GridTile tile = SaveGame.Grid[y][x];
                if (tile.MonsterIndex == 0)
                {
                    SaveGame.MsgPrint("You bite into thin air!");
                }
                else
                {
                    SaveGame.MsgPrint("You grin and bare your fangs...");
                    int dummy = SaveGame.ExperienceLevel + (SaveGame.Rng.DieRoll(SaveGame.ExperienceLevel) * Math.Max(1, SaveGame.ExperienceLevel / 10));
                    if (SaveGame.DrainLife(direction, dummy))
                    {
                        if (SaveGame.Food < Constants.PyFoodFull)
                        {
                            SaveGame.RestoreHealth(dummy);
                        }
                        else
                        {
                            SaveGame.MsgPrint("You were not hungry.");
                        }
                        dummy = SaveGame.Food + Math.Min(5000, 100 * dummy);
                        if (SaveGame.Food < Constants.PyFoodMax)
                        {
                            SaveGame.SetFood(dummy >= Constants.PyFoodMax ? Constants.PyFoodMax - 1 : dummy);
                        }
                    }
                    else
                    {
                        SaveGame.MsgPrint("Yechh. That tastes foul.");
                    }
                }
            }
        }
    }
    public override bool OutfitsWithScrollsOfSatisfyHunger => true;
    public override bool OutfitsWithScrollsOfLight => true;
    public override int ChanceOfSanityBlastImmunity(int level) => level + 25;

    public override void ProcessWorld(ProcessWorldEventArgs processWorldEventArgs)
    {
        if (SaveGame.CurrentDepth <= 0 && 
            !SaveGame.HasLightResistance &&
            SaveGame.TimedInvulnerability.TurnsRemaining == 0 &&
            SaveGame.GameTime.IsLight)
        {
            if (SaveGame.Grid[SaveGame.MapY][SaveGame.MapX].TileFlags.IsSet(GridTile.SelfLit))
            {
                SaveGame.MsgPrint("The sun's rays scorch your undead flesh!");
                SaveGame.TakeHit(1, "sunlight");
                processWorldEventArgs.DisableRegeneration = true;
            }
        }
    }
}