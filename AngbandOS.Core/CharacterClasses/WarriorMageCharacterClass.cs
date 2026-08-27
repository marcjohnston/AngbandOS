// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.CharacterClasses;

internal class WarriorMageCharacterClass : CharacterClass
{
    private WarriorMageCharacterClass(Game savedGame) : base(savedGame) { }
    protected override (int, bool?, string)[]? ExperienceLevelHasHeavyArmorAndEnhancementBindingTuples => new (int, bool?, string)[] { 
        (1, null, nameof(WarriorMageCharacterClassItemEnhancement)) 
    };
    public override int ID => 6;
    public override string Title => "Warrior-Mage";
    public override int BasePerception => 16;
    public override int MeleeToHit => 50;
    public override int RangedToHit => 26;
    public override int DisarmBonusPerLevel => 7;
    public override int MeleeAttackBonusPerLevel => 20;
    public override int RangedAttackBonusPerLevel => 20;
    public override int HitDieBonus => 4;
    public override int ExperienceFactor => 50;
    public override Ability PrimeStat => Game.SingletonRepository.Get<Ability>(nameof(IntelligenceAbility));
    public override string[] Info => new string[] {
        "A blend of both warrior and mage, getting the abilities of",
        "both but not being the best at either. They use INT based",
        "spell casting, getting access to the Folk realm plus a",
        "second realm of their choice. They pay for their extreme",
        "flexibility by increasing in level only slowly."
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
    protected override (string?, int)[]? ArtifactBiasAndWeightBindingKeys => new (string?, int)[] { (nameof(MageArtifactBias), 1) };
    public override int FromScrollWarriorArtifactBiasPercentageChance => 40;
    public override bool SenseInventoryTest(int level) => (0 != Game.RandomLessThan(75000 / ((level * level) + 40)));
    protected override string[] AvailablePrimaryRealmBindingKeys => new string[] {
        nameof(NatureRealm)
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
