// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.CharacterClasses;

internal class WarriorCharacterClass : CharacterClass
{
    private WarriorCharacterClass(Game savedGame) : base(savedGame) { }
    protected override (int, bool?, string)[]? ExperienceLevelHasHeavyArmorAndEnhancementBindingTuples => new (int, bool?, string)[]
    {
        (1, null, nameof(WarriorCharacterClassItemEnhancement)),
        (30, null, nameof(WarriorCharacterClassLevel30ItemEnhancement))
    };
    protected override string? MeleeAttacksPerRoundBonusExpression => "X/15";
    public override int ID => 0;
    public override string Title => "Warrior";
    public override int? AttackAndDamageBonusPerExperienceLevelDivisor => 5;
    public override int BasePerception => 2;
    public override int MeleeToHit => 70;
    public override int RangedToHit => 60;
    public override int DisarmBonusPerLevel => 12;
    public override int NonMagicRandomArtifact1InChance => 0;
    public override int MeleeAttackBonusPerLevel => 45;
    public override int RangedAttackBonusPerLevel => 45;
    public override int HitDieBonus => 9;
    public override int ExperienceFactor => 0;
    public override Ability PrimeStat => Game.SingletonRepository.Get<Ability>(nameof(StrengthAbility));
    public override string[] Info => new string[] {
        "Straightforward, no-nonsense fighters. They are the best",
        "characters at melee combat, and require the least amount",
        "of experience to increase in level. They can learn to",
        "resist fear (at lvl 30). The ideal class for novices."
    };
    public override int MaximumMeleeAttacksPerRound(int level) => 6;
    public override int MaximumWeight => 30;
    public override int AttackSpeedMultiplier => 5;
    protected override (string?, int)[]? ArtifactBiasAndWeightBindingKeys => new (string?, int)[] { (nameof(WarriorArtifactBias), 1) };
    public override bool SenseInventoryTest(int level) => (0 != Game.RandomLessThan(9000 / ((level * level) + 40)));
    public override bool DetailedSenseInventory => true;
    protected override string[]? ItemActionNames => new string[]
    {
        nameof(GainExperienceForHighLevelSpellBookDestroyedItemAction)
    };
    protected override string SpellAbilityBindingKey => nameof(StrengthAbility);
}
