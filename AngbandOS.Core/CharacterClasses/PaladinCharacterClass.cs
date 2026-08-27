// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.CharacterClasses;

internal class PaladinCharacterClass : CharacterClass
{
    private PaladinCharacterClass(Game savedGame) : base(savedGame) { }
    protected override (int, bool?, string)[]? ExperienceLevelHasHeavyArmorAndEnhancementBindingTuples => new (int, bool?, string)[]
    {
        (1, null, nameof(PaladinCharacterClassItemEnhancement)),
        (40, null, nameof(PaladinCharacterClassLevel40ItemEnhancement))
    };
    public override int ID => 5;
    public override string Title => "Paladin";
    public override int BasePerception => 2;
    public override int MeleeToHit => 68;
    public override int RangedToHit => 40;
    public override int DisarmBonusPerLevel => 7;
    public override int MeleeAttackBonusPerLevel => 35;
    public override int RangedAttackBonusPerLevel => 30;
    public override int HitDieBonus => 6;
    public override int ExperienceFactor => 35;

    public override Ability PrimeStat => Game.SingletonRepository.Get<Ability>(nameof(WisdomAbility));
    public override string[] Info => new string[] {
        "Holy warriors who use WIS based spell casting to supplement",
        "their fighting skills. Paladins can specialise in either",
        "Life or Death magic, but their spell casting is weak in",
        "comparison to a full priest. Paladins learn to resist fear",
        "(at lvl 40)."
    };
    public override int SpellWeight => 400;
    public override void Cast() => CastMentalism();
    protected override string SpellAbilityBindingKey => nameof(WisdomAbility);
    public override int MaximumWeight => 30;
    public override int AttackSpeedMultiplier => 4;
    protected override (string?, int)[]? ArtifactBiasAndWeightBindingKeys => new (string?, int)[] { (nameof(PriestlyArtifactBias), 1) };
    public override int FromScrollWarriorArtifactBiasPercentageChance => 40;
    public override bool SenseInventoryTest(int level) => (0 != Game.RandomLessThan(77777 / ((level * level) + 40)));
    public override bool DetailedSenseInventory => true;
    protected override string[] AvailablePrimaryRealmBindingKeys => new string[] {
        nameof(LifeRealm),
        nameof(DeathRealm)
    };
    protected override string[]? ItemActionNames => new string[]
    {
        nameof(GainExperienceForUnusableHighLevelSpellBookDestroyedItemAction)
    };
}
