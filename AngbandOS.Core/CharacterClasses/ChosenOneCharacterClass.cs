// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.CharacterClasses;

[Serializable]
internal class ChosenOneCharacterClass : BaseCharacterClass
{
    private ChosenOneCharacterClass(Game savedGame) : base(savedGame) { }
    public override int ID => 14;
    public override string Title => "Chosen One";
    public override int[] AbilityBonus => new[] { 3, -2, -2, 2, 2, -1 };
    public override int BaseDisarmBonus => 25;
    public override int BaseDeviceBonus => 18;
    public override int BaseSaveBonus => 20;
    public override int BaseStealthBonus => 1;
    public override int BaseSearchBonus => 16;
    public override int BaseSearchFrequency => 4;
    public override int BaseMeleeAttackBonus => 50;
    public override int BaseRangedAttackBonus => 32;
    public override int DisarmBonusPerLevel => 12;
    public override int DeviceBonusPerLevel => 7;
    public override int SaveBonusPerLevel => 10;
    public override int StealthBonusPerLevel => 0;
    public override int SearchBonusPerLevel => 0;
    public override int SearchFrequencyPerLevel => 0;
    public override int MeleeAttackBonusPerLevel => 20;
    public override int RangedAttackBonusPerLevel => 20;
    public override int HitDieBonus => 4;
    public override int ExperienceFactor => 20;
    public override int PrimeStat => AbilityEnum.Strength;
    public override string[] Info => new string[] {
        "Warriors of fate, who have no spell casting abilities but",
        "gain a large number of passive magical abilities (too long",
        "to list here) as they increase in level."
    };
    public override ArtifactBias? ArtifactBias => Game.SingletonRepository.Get<ArtifactBias>(nameof(WarriorArtifactBias));
    public override bool SenseInventoryTest(int level) => (0 != Game.RandomLessThan(9000 / ((level * level) + 40)));
    public override bool DetailedSenseInventory => true;
    public override bool OutfitsWithScrollsOfLight => true;

    protected override string[] OutfitItemFactoryNames => new string[]
    {
        nameof(SmallSwordWeaponItemFactory),
        nameof(HealingPotionItemFactory),
        nameof(SoftLeatherSoftArmorItemFactory)
    };

    public override void CalcBonuses()
    {
        Game.GlowInTheDarkRadius = 1;
        if (Game.ExperienceLevel.IntValue >= 2)
        {
            Game.HasConfusionResistance = true;
        }
        if (Game.ExperienceLevel.IntValue >= 4)
        {
            Game.HasFearResistance = true;
        }
        if (Game.ExperienceLevel.IntValue >= 6)
        {
            Game.BlindnessTimer.HasResistance = true;
        }
        if (Game.ExperienceLevel.IntValue >= 8)
        {
            Game.HasFeatherFall = true;
        }
        if (Game.ExperienceLevel.IntValue >= 10)
        {
            Game.HasSeeInvisibility = true;
        }
        if (Game.ExperienceLevel.IntValue >= 12)
        {
            Game.HasSlowDigestion = true;
        }
        if (Game.ExperienceLevel.IntValue >= 14)
        {
            Game.HasSustainConstitution = true;
        }
        if (Game.ExperienceLevel.IntValue >= 16)
        {
            Game.HasPoisonResistance = true;
        }
        if (Game.ExperienceLevel.IntValue >= 18)
        {
            Game.HasSustainDexterity = true;
        }
        if (Game.ExperienceLevel.IntValue >= 20)
        {
            Game.HasSustainStrength = true;
        }
        if (Game.ExperienceLevel.IntValue >= 22)
        {
            Game.HasHoldLife = true;
        }
        if (Game.ExperienceLevel.IntValue >= 24)
        {
            Game.HasFreeAction = true;
        }
        if (Game.ExperienceLevel.IntValue >= 26)
        {
            Game.HasTelepathy = true;
        }
        if (Game.ExperienceLevel.IntValue >= 28)
        {
            Game.HasDarkResistance = true;
        }
        if (Game.ExperienceLevel.IntValue >= 30)
        {
            Game.HasLightResistance = true;
        }
        if (Game.ExperienceLevel.IntValue >= 32)
        {
            Game.HasSustainCharisma = true;
        }
        if (Game.ExperienceLevel.IntValue >= 34)
        {
            Game.HasSoundResistance = true;
        }
        if (Game.ExperienceLevel.IntValue >= 36)
        {
            Game.HasDisenchantResistance = true;
        }
        if (Game.ExperienceLevel.IntValue >= 38)
        {
            Game.HasRegeneration = true;
        }
        if (Game.ExperienceLevel.IntValue >= 40)
        {
            Game.HasSustainIntelligence = true;
        }
        if (Game.ExperienceLevel.IntValue >= 42)
        {
            Game.HasChaosResistance = true;
        }
        if (Game.ExperienceLevel.IntValue >= 44)
        {
            Game.HasSustainWisdom = true;
        }
        if (Game.ExperienceLevel.IntValue >= 46)
        {
            Game.HasNexusResistance = true;
        }
        if (Game.ExperienceLevel.IntValue >= 48)
        {
            Game.HasShardResistance = true;
        }
        if (Game.ExperienceLevel.IntValue >= 50)
        {
            Game.HasNetherResistance = true;
        }
    }
}
