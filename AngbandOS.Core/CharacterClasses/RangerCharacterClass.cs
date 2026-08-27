// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.CharacterClasses;

internal class RangerCharacterClass : CharacterClass
{
    private RangerCharacterClass(Game savedGame) : base(savedGame) { }
    protected override (int, bool?, string)[]? MinimumExperienceLevelHasHeavyArmorAndEnhancementBindingTuples => new (int, bool?, string)[] { 
        (1, null, nameof(RangerCharacterClassItemEnhancement)) 
    };
    public override int ID => 4;
    public override string Title => "Ranger";
    public override int BasePerception => 16;
    public override int MeleeToHit => 56;
    public override int RangedToHit => 72;
    public override int DisarmBonusPerLevel => 8;
    public override int MeleeAttackBonusPerLevel => 30;
    public override int RangedAttackBonusPerLevel => 45;
    public override int HitDieBonus => 4;
    public override int ExperienceFactor => 30;
    public override Ability PrimeStat => Game.SingletonRepository.Get<Ability>(nameof(IntelligenceAbility));
    public override string[] Info => new string[] {
        "Masters of ranged combat, especiallly using bows. Rangers",
        "supplement their shooting and stealth with INT based spell",
        "casting from the Nature realm plus another realm of their",
        "choice from Death, Corporeal, Tarot, Chaos, and Folk."
    };
    public override int SpellWeight => 400;

    public override bool DoesNotGainSpellLevelsUntilFirstSpellLevel => true;

    /// <summary>
    /// Returns "prayer" because the diving casting type uses prayers for magic.
    /// </summary>
    public override string SpellNoun => "prayer";

    /// <summary>
    /// Returns "prayer" because the diving casting type uses prayers.
    /// </summary>
    public override string MagicType => "prayer";

    /// <summary>
    /// Returns false, because the diving casting type does not allow the player to choose which prayer to learn.
    /// </summary>
    public override bool CanChooseSpellToStudy => false;

    /// <summary>
    /// Returns "recite" because the divine casting type recites prayers; as opposed to casting spells.
    /// </summary>
    public override string CastVerb => "recite";

    /// <summary>
    /// Returns true, because the Ranger class is divine and spellbooks should render as a simple book.
    /// </summary>
    public override bool UseAlternateItemNames => true;

    protected override string SpellAbilityBindingKey => nameof(IntelligenceAbility);
    public override int AttackSpeedMultiplier => 4;
    protected override (string?, int)[]? ArtifactBiasAndWeightBindingKeys => new (string?, int)[] { (nameof(RangerArtifactBias), 1) };
    public override int FromScrollWarriorArtifactBiasPercentageChance => 30;
    public override bool SenseInventoryTest(int level) => (0 != Game.RandomLessThan(95000 / ((level * level) + 40)));
    public override bool DetailedSenseInventory => true;
    protected override string[] AvailablePrimaryRealmBindingKeys => new string[] {
        nameof(NatureRealm)
    };
    protected override string[] AvailableSecondaryRealmBindingKeys => new string[] {
        nameof(ChaosRealm),
        nameof(DeathRealm),
        nameof(TarotRealm),
        nameof(FolkRealm),
        nameof(CorporealRealm)
    };
    public override bool WorshipsADeity => true;
}
