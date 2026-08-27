// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.CharacterClasses;

internal class PriestCharacterClass : CharacterClass
{
    private PriestCharacterClass(Game savedGame) : base(savedGame) { }
    protected override (int, bool?, string)[]? ExperienceLevelHasHeavyArmorAndEnhancementBindingTuples => new (int, bool?, string)[] { 
        (1, null, nameof(PriestCharacterClassItemEnhancement)) 
    };
    public override int ID => 2;
    public override string Title => "Priest";
    public override int BasePerception => 8;
    public override int UnpriestlyWeaponAdditionalFailureChance => 25;
    public override int? AttackAndDamageBonusForUnpriestlyWeapon => -2;
    public override int MeleeToHit => 48;
    public override int RangedToHit => 36;
    public override int DisarmBonusPerLevel => 7;
    public override int MeleeAttackBonusPerLevel => 20;
    public override int RangedAttackBonusPerLevel => 20;
    public override int HitDieBonus => 2;
    public override int ExperienceFactor => 20;
    public override Ability PrimeStat => Game.SingletonRepository.Get<Ability>(nameof(WisdomAbility));
    public override int? SpellMinFailChance => 5;
    public override string[] Info => new string[] {
        "Devout followers of the Great Ones, Priests use WIS based",
        "spell casting. They may choose either Life or Death magic,",
        "and another realm of their choice. Priests can't use edged",
        "weapons unless they are blessed, but can use any armor."
    };
    public override int SpellWeight => 350;

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
    /// Returns true, because the Priest class is divine and spellbooks should render as a simple book.
    /// </summary>
    public override bool UseAlternateItemNames => true;

    protected override string SpellAbilityBindingKey => nameof(WisdomAbility);
    protected override (string?, int)[]? ArtifactBiasAndWeightBindingKeys => new (string?, int)[] { (nameof(PriestlyArtifactBias), 1) };
    public override bool SenseInventoryTest(int level) => (0 != Game.RandomLessThan(10000 / ((level * level) + 40)));
    protected override string[] AvailablePrimaryRealmBindingKeys => new string[] {
        nameof(LifeRealm),
        nameof(DeathRealm)
    };
    protected override string[] AvailableSecondaryRealmBindingKeys => new string[] {
        nameof(NatureRealm),
        nameof(ChaosRealm),
        nameof(TarotRealm),
        nameof(FolkRealm),
        nameof(CorporealRealm)
    };
    public override bool WorshipsADeity => true;
}
