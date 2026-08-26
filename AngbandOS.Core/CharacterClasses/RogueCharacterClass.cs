// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.CharacterClasses;

internal class RogueCharacterClass : CharacterClass
{
    private RogueCharacterClass(Game savedGame) : base(savedGame) { }

    protected override (int, bool?, string)[]? MinimumExperienceLevelHasHeavyArmorAndEnhancementBindingTuples => new (int, bool?, string)[] { 
        (1, null, nameof(RogueCharacterClassItemEnhancement)) 
    };
    public override int ID => 3;
    public override bool CanBackstab => true;
    public override string Title => "Rogue";
    public override int BasePerception => 24;
    public override string TarotDrawRollExpression => "1d110+X/5";
    public override int MeleeToHit => 60;
    public override int RangedToHit => 66;
    public override int DisarmBonusPerLevel => 15;
    public override int MeleeAttackBonusPerLevel => 40;
    public override int RangedAttackBonusPerLevel => 10;
    public override int HitDieBonus => 6;
    public override int ExperienceFactor => 25;
    public override Ability PrimeStat => Game.SingletonRepository.Get<Ability>(nameof(DexterityAbility));
    public override string[] Info => new string[] {
        "Stealth based characters who are adept at picking locks,",
        "searching, and disarming traps. Rogues can use stealth to",
        "their advantage in order to backstab sleeping or fleeing",
        "foes. They also dabble in INT based magic, learning spells",
        "from the Tarot, Sorcery, Death, or Folk realms."
   };
    public override int SpellWeight => 350;


    /// <summary>
    /// Returns true, because arcane spell casting movement can be encumbered by the spell weight of the players armor.
    /// </summary>
    public override bool WeightEncumbersMovement => true;


    /// <summary>
    /// Returns true, because arcane spell casting requires the players hands to be unrestricted for spell casting.
    /// </summary>
    public override bool CoveredHandsRestrictCasting => true;


    public override bool DoesNotGainSpellLevelsUntilFirstSpellLevel => true;
    protected override string SpellAbilityBindingKey => nameof(IntelligenceAbility);
    public override int MaximumWeight => 30;
    protected override (string?, int)[]? ArtifactBiasAndWeightBindingKeys => new (string?, int)[] { (nameof(RogueArtifactBias), 1) };
    public override int FromScrollWarriorArtifactBiasPercentageChance => 25;
    public override bool SenseInventoryTest(int level) => (0 != Game.RandomLessThan(20000 / ((level * level) + 40)));
    public override bool DetailedSenseInventory => true;
    protected override string[] AvailablePrimaryRealmBindingKeys => new string[] {
        nameof(SorceryRealm),
        nameof(DeathRealm),
        nameof(TarotRealm),
        nameof(FolkRealm)
    };
}
