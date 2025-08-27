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
    private VampireRace(Game game) : base(game) { }
    protected override string EnhancementBindingKey => nameof(VampireRaceItemEnhancement);
    public override string Title => "Vampire";
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
    public override int Infravision => 5;
    public override uint Choice => 0xFFFF;
    public override string Description => "Vampires are powerful undead. They resist darkness, nether,\ncold, poison, and having their life force drained. Vampires\nproduce their own ethereal light in the dark, but are hurt\nby direct sunlight. They can learn to drain the life force\nfrom their foes (at lvl 2).";

    /// <summary>
    /// Vampire 113->114->115->116->117->End
    /// </summary>
    public override int Chart => 113;

    public override string RacialPowersDescription(int lvl) => lvl < 2 ? "drain life         (racial, unusable until level 2)" : "drain life         (racial, cost 1 + lvl/3, based)";
    protected override string? RacialPowerScriptBindingKey => nameof(UseRacialPowerScript);
    public override bool HasRacialPowers => true;
    public override void UpdateRacialAbilities(int level, EffectiveAttributeSet itemCharacteristics)
    {
        itemCharacteristics.HoldLife = true;
        itemCharacteristics.SetBoolAttributeValue(AttributeEnum.ResDark, true);
        itemCharacteristics.SetBoolAttributeValue(AttributeEnum.ResNether, true);
        itemCharacteristics.SetBoolAttributeValue(AttributeEnum.ResPois, true);
        itemCharacteristics.SetBoolAttributeValue(AttributeEnum.ResCold, true);
    }
    protected override string GenerateNameSyllableSetName => nameof(HumanSyllableSet);

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
        Game.HasDarkResistance = true;
        Game.HasHoldLife = true;
        Game.HasNetherResistance = true;
        Game.HasColdResistance = true;
        Game.HasPoisonResistance = true;
        Game.GlowInTheDarkRadius = 1;
    }
    public override bool RestsTillDuskInsteadOfDawn => true;

    public override bool IsBurnedBySunlight => true;

    public override bool IsDamagedByDarkness => false;

    public override void Eat(Item item)
    {
        // Vampires only get 1/10th of the food value
        Game.SetFood(Game.Food.IntValue + (item.NutritionalValue / 10));
        Game.MsgPrint("Mere victuals hold scant sustenance for a being such as yourself.");
        if (Game.Food.IntValue < Constants.PyFoodAlert)
        {
            Game.MsgPrint("Your hunger can only be satisfied with fresh blood!");
        }
    }
    public override bool OutfitsWithScrollsOfSatisfyHunger => true;
    public override bool OutfitsWithScrollsOfLight => true;
    public override int ChanceOfSanityBlastImmunity(int level) => level + 25;

    /// <summary>
    /// Vampire races that are not invulnerable, do not have resistance to light and are on the town level or deeper during the daytime will take a hit when the grid tile is
    /// self-lit.
    /// </summary>
    /// <param name="processWorldEventArgs"></param>
    public override void ProcessWorld(ProcessWorldEventArgs processWorldEventArgs)
    {
        if (Game.CurrentDepth <= 0 && !Game.HasLightResistance && Game.InvulnerabilityTimer.Value == 0 && Game.IsLight)
        {
            if (Game.Map.Grid[Game.MapY.IntValue][Game.MapX.IntValue].SelfLit)
            {
                Game.MsgPrint("The sun's rays scorch your undead flesh!");
                Game.TakeHit(1, "sunlight");
                processWorldEventArgs.DisableRegeneration = true;
            }
        }
    }
}