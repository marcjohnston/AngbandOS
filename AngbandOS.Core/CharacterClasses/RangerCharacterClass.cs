// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.CharacterClasses;

[Serializable]
internal class RangerCharacterClass : BaseCharacterClass
{
    private RangerCharacterClass(Game savedGame) : base(savedGame) { }
    protected override string EnhancementBindingKey => nameof(RangerCharacterClassItemEnhancement);
    public override int ID => 4;
    public override string Title => "Ranger";
    public override int UseDevice => 32;
    public override int SavingThrow => 28;
    public override int Stealth => 3;
    public override int Search => 24;
    public override int BaseSearchFrequency => 16;
    public override int MeleeToHit => 56;
    public override int RangedToHit => 72;
    public override int DisarmBonusPerLevel => 8;
    public override int DeviceBonusPerLevel => 10;
    public override int SaveBonusPerLevel => 10;
    public override int StealthBonusPerLevel => 0;
    public override int SearchBonusPerLevel => 0;
    public override int SearchFrequencyPerLevel => 0;
    public override int MeleeAttackBonusPerLevel => 30;
    public override int RangedAttackBonusPerLevel => 45;
    public override int HitDieBonus => 4;
    public override int ExperienceFactor => 30;
    public override Ability PrimeStat => Game.IntelligenceAbility;
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

    public override Ability SpellStat => Game.IntelligenceAbility;
    public override int AttackSpeedMultiplier => 4;
    public override ArtifactBias? ArtifactBias => Game.SingletonRepository.Get<ArtifactBias>(nameof(RangerArtifactBias));
    public override int FromScrollWarriorArtifactBiasPercentageChance => 30;
    public override bool SenseInventoryTest(int level) => (0 != Game.RandomLessThan(95000 / ((level * level) + 40)));
    public override bool DetailedSenseInventory => true;
    public override Realm[] AvailablePrimaryRealms => new Realm[] {
        Game.SingletonRepository.Get<Realm>(nameof(NatureRealm))
    };
    public override Realm[] AvailableSecondaryRealms => new Realm[] {
        Game.SingletonRepository.Get<Realm>(nameof(ChaosRealm)),
        Game.SingletonRepository.Get<Realm>(nameof(DeathRealm)),
        Game.SingletonRepository.Get<Realm>(nameof(TarotRealm)),
        Game.SingletonRepository.Get<Realm>(nameof(FolkRealm)),
        Game.SingletonRepository.Get<Realm>(nameof(CorporealRealm))
    };
    public override bool WorshipsADeity => true;

    protected override string[] OutfitItemFactoryNames => new string[]
    {
        nameof(CallOfTheWildNatureBookItemFactory),
        nameof(BroadSwordWeaponItemFactory),
        nameof(BlackPrayersDeathBookItemFactory)
    };
}
