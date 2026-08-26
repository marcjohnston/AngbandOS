// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.CharacterClasses;

internal class MageCharacterClass : CharacterClass
{
    private MageCharacterClass(Game savedGame) : base(savedGame) { }
    protected override (int, bool?, string)[]? MinimumExperienceLevelHasHeavyArmorAndEnhancementBindingTuples => new (int, bool?, string)[] { 
        (1, null, nameof(MageCharacterClassItemEnhancement)) 
    };
    public override int ID => 1;
    public override int FriendsUpkeepDivider => 15;
    public override string Title => "Mage";
    public override int? SpellMinFailChance => 5;
    public override int BasePerception => 20;
    public override string InvokeSpiritsBeamProbabilityRollExpression => "X";
    public override string SpellOfWonderBeamProbabilityRollExpression => "X";
    public override int MeleeToHit => 34;
    public override int RangedToHit => 20;
    public override int DisarmBonusPerLevel => 7;
    public override int MeleeAttackBonusPerLevel => 15;
    public override int RangedAttackBonusPerLevel => 15;
    public override int HitDieBonus => 0;
    public override int ExperienceFactor => 30;
    public override Ability PrimeStat => Game.SingletonRepository.Get<Ability>(nameof(IntelligenceAbility));
    public override string[] Info => new string[] {
        "Flexible INT based spell casters who can cast magic from",
        "any two realms of their choice. However, they can't wear",
        "much armor before it starts disrupting their casting."
    };
    public override int SpellWeight => 300;


    /// <summary>
    /// Returns true, because arcane spell casting movement can be encumbered by the spell weight of the players armor.
    /// </summary>
    public override bool WeightEncumbersMovement => true;


    /// <summary>
    /// Returns true, because arcane spell casting requires the players hands to be unrestricted for spell casting.
    /// </summary>
    public override bool CoveredHandsRestrictCasting => true;


    public override bool DoesNotGainSpellLevelsUntilFirstSpellLevel => true;
    public override Ability SpellStat => Game.SingletonRepository.Get<Ability>(nameof(IntelligenceAbility));
    public override int MaximumMeleeAttacksPerRound(int level) => 4;
    public override int MaximumWeight => 40;
    public override int AttackSpeedMultiplier => 2;
    protected override (string?, int)[]? ArtifactBiasAndWeightBindingKeys => new (string?, int)[] { (nameof(MageArtifactBias), 1) };
    public override bool SenseInventoryTest(int level) => (0 != Game.RandomLessThan(240000 / (level + 5)));
    protected override string[] AvailablePrimaryRealmBindingKeys => new string[] {
        nameof(LifeRealm),
        nameof(SorceryRealm),
        nameof(NatureRealm),
        nameof(ChaosRealm),
        nameof(DeathRealm),
        nameof(TarotRealm),
        nameof(FolkRealm),
        nameof(CorporealRealm)
    };
    protected override string[] AvailableSecondaryRealmBindingKeys => new string[] {
        nameof(LifeRealm),
        nameof(SorceryRealm),
        nameof(NatureRealm),
        nameof(ChaosRealm),
        nameof(DeathRealm),
        nameof(TarotRealm),
        nameof(FolkRealm),
        nameof(CorporealRealm)
    };
    public override bool WorshipsADeity => true;
}
