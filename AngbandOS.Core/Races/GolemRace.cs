// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Races;

[Serializable]
internal class GolemRace : Race
{
    private GolemRace(Game game) : base(game) { }
    public override string Title => "Golem";
    public override int BaseDisarmBonus => -5;
    public override int BaseDeviceBonus => -5;
    public override int BaseSaveBonus => 10;
    public override int BaseStealthBonus => -1;
    public override int BaseSearchBonus => -1;
    public override int BaseSearchFrequency => 8;
    public override int BaseMeleeAttackBonus => 20;
    public override int BaseRangedAttackBonus => 0;
    public override int HitDieBonus => 12;
    public override int ExperienceFactor => 200;
    public override int BaseAge => 1;
    public override int AgeRange => 100;
    public override int Infravision => 4;
    public override uint Choice => 0x4001;
    public override string Description => "Golems are animated statues. Their inorganic bodies make it\nhard for them to digest food properly, but they have innate\nnatural armor and can't be stunned or made to bleed. They\nalso resist poison and can see invisible creatures. Golems\ncan learn to use their armor more efficiently (at lvl 20)\nand avoid having their life force drained (at lvl 35).";

    /// <summary>
    /// Golem 98->99->100->101->End
    /// </summary>
    public override int Chart => 98;

    public override string RacialPowersDescription(int lvl) => lvl < 20 ? "stone skin         (racial, unusable until level 20)" : "stone skin         (racial, cost 15, dur 30+d20, CON based)";
    public override bool HasRacialPowers => true;

    public override void UpdateRacialAbilities(int level, RwItemPropertySet itemCharacteristics)
    {
        itemCharacteristics.SeeInvis = true;
        itemCharacteristics.FreeAct = true;
        itemCharacteristics.ResPois = true;
        itemCharacteristics.SlowDigest = true;
        if (level > 34)
        {
            itemCharacteristics.HoldLife = true;
        }
    }
    protected override string GenerateNameSyllableSetName => nameof(DwarvenSyllableSet);

    public override string[]? SelfKnowledge(int level)
    {
        if (level > 19)
        {
            return new string[] { "You can turn your skin to stone, dur d20+30 (cost 15)." };
        }
        return null;
    }
    public override void CalcBonuses()
    {
        if (Game.ExperienceLevel.IntValue > 34)
        {
            Game.HasHoldLife = true;
        }
        Game.HasSlowDigestion = true;
        Game.HasFreeAction = true;
        Game.HasSeeInvisibility = true;
        Game.HasPoisonResistance = true;
        Game.ArmorClassBonus += 20 + (Game.ExperienceLevel.IntValue / 5);
        Game.DisplayedArmorClassBonus.IntValue += 20 + (Game.ExperienceLevel.IntValue / 5);
    }

    public override void Eat(Item item)
    {
        // This race only gets 1/20th of the food value
        Game.MsgPrint("The food of mortals is poor sustenance for you.");
        Game.SetFood(Game.Food.IntValue + (item.NutritionalValue / 20));
    }

    public override bool CanBleed(int level) => false;

    public override void UseRacialPower()
    {
        // Golems can harden their skin
        if (Game.CheckIfRacialPowerWorks(20, 15, Game.ConstitutionAbility, 8))
        {
            Game.StoneskinTimer.AddTimer(Game.DieRoll(20) + 30);
        }
    }
    public override bool OutfitsWithScrollsOfSatisfyHunger => true;

    public override bool CanBeStunned => false;
}