// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.CharacterClasses;

internal class ChosenOneCharacterClass : CharacterClass
{
    private ChosenOneCharacterClass(Game savedGame) : base(savedGame) { }
    protected override (int, bool?, string)[]? MinimumExperienceLevelHasHeavyArmorAndEnhancementBindingTuples => new (int, bool?, string)[]
    {
        (1, null, nameof(ChosenOneCharacterClassItemEnhancement)),
        (2, null, nameof(ChosenOneCharacterClassLevel2ItemEnhancement)),
        (4, null, nameof(ChosenOneCharacterClassLevel4ItemEnhancement)),
        (6, null, nameof(ChosenOneCharacterClassLevel6ItemEnhancement)),
        (8, null, nameof(ChosenOneCharacterClassLevel8ItemEnhancement)),
        (10, null, nameof(ChosenOneCharacterClassLevel10ItemEnhancement)),
        (12, null, nameof(ChosenOneCharacterClassLevel12ItemEnhancement)),
        (14, null, nameof(ChosenOneCharacterClassLevel14ItemEnhancement)),
        (16, null, nameof(ChosenOneCharacterClassLevel16ItemEnhancement)),
        (18, null, nameof(ChosenOneCharacterClassLevel18ItemEnhancement)),
        (20, null, nameof(ChosenOneCharacterClassLevel20ItemEnhancement)),
        (22, null, nameof(ChosenOneCharacterClassLevel22ItemEnhancement)),
        (24, null, nameof(ChosenOneCharacterClassLevel24ItemEnhancement)),
        (26, null, nameof(ChosenOneCharacterClassLevel26ItemEnhancement)),
        (28, null, nameof(ChosenOneCharacterClassLevel28ItemEnhancement)),
        (30, null, nameof(ChosenOneCharacterClassLevel30ItemEnhancement)),
        (32, null, nameof(ChosenOneCharacterClassLevel32ItemEnhancement)),
        (34, null, nameof(ChosenOneCharacterClassLevel34ItemEnhancement)),
        (36, null, nameof(ChosenOneCharacterClassLevel36ItemEnhancement)),
        (38, null, nameof(ChosenOneCharacterClassLevel38ItemEnhancement)),
        (40, null, nameof(ChosenOneCharacterClassLevel40ItemEnhancement)),
        (42, null, nameof(ChosenOneCharacterClassLevel42ItemEnhancement)),
        (44, null, nameof(ChosenOneCharacterClassLevel44ItemEnhancement)),
        (46, null, nameof(ChosenOneCharacterClassLevel46ItemEnhancement)),
        (48, null, nameof(ChosenOneCharacterClassLevel48ItemEnhancement)),
        (50, null, nameof(ChosenOneCharacterClassLevel50ItemEnhancement)),
    };
    public override int ID => 14;
    public override string Title => "Chosen One";
    public override int? InstantConfusionResistanceLevel => 2;
    public override int? InstantFearResistanceLevel => 4;
    public override int? InstantBlindnessResistanceLevel => 6;
    public override int? InstantFeatherFallingLevel => 8;
    public override int? InstantSeeInvisibilityLevel => 10;
    public override int? InstantSlowDigestionLevel => 12;
    public override int? InstantSustainConstitutionLevel => 14;
    public override int? InstantPoisonResistanceLevel => 16;
    public override int? InstantSustainDexterityLevel => 18;
    public override int? InstantSustainStrengthLevel => 20;
    public override int? InstantHoldLifeLevel => 22;
    public override int? InstantFreeActionLevel => 24;
    public override int? InstantTelepathyLevel => 26;
    public override int? InstantDarknessResistanceLevel => 28;
    public override int? InstantLightResistanceLevel => 30;
    public override int? InstantSustainCharismaLevel => 32;
    public override int? InstantSoundResistanceLevel => 34;
    public override int? InstantDisenchantmentResistanceLevel => 36;
    public override int? InstantRegenerationLevel => 38;
    public override int? InstantSustainIntelligenceLevel => 40;
    public override int? InstantChaosResistanceLevel => 42;
    public override int? InstantSustainWisdomLevel => 44;
    public override int? InstantNexusResistanceLevel => 46;
    public override int? InstantShardsResistanceLevel => 48;
    public override int? InstantNetherResistanceLevel => 50;
    public override int? ItemRadiusOverride => 2;
    public override int BasePerception => 4;
    public override int MeleeToHit => 50;
    public override int RangedToHit => 32;
    public override int DisarmBonusPerLevel => 12;
    public override int MeleeAttackBonusPerLevel => 20;
    public override int RangedAttackBonusPerLevel => 20;
    public override int HitDieBonus => 4;
    public override int ExperienceFactor => 20;
    public override Ability PrimeStat => Game.SingletonRepository.Get<Ability>(nameof(StrengthAbility));
    public override string[] Info => new string[] {
        "Warriors of fate, who have no spell casting abilities but",
        "gain a large number of passive magical abilities (too long",
        "to list here) as they increase in level."
    };
    protected override (string?, int)[]? ArtifactBiasAndWeightBindingKeys => new (string?, int)[] { (nameof(WarriorArtifactBias), 1) };
    public override bool SenseInventoryTest(int level) => (0 != Game.RandomLessThan(9000 / ((level * level) + 40)));
    public override bool DetailedSenseInventory => true;
    public override bool OutfitsWithScrollsOfLight => true;
    protected override string SpellAbilityBindingKey => nameof(StrengthAbility);
}
