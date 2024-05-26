// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.CharacterClasses;

[Serializable]
internal class HighMageCharacterClass : BaseCharacterClass
{
    private HighMageCharacterClass(Game savedGame) : base(savedGame) { }
    public override int ID => 10;
    public override string Title => "High-Mage";
    public override int[] AbilityBonus => new[] { -5, 4, 0, 0, -2, 1 };
    public override int BaseDisarmBonus => 30;
    public override int BaseDeviceBonus => 38;
    public override int BaseSaveBonus => 30;
    public override int BaseStealthBonus => 2;
    public override int BaseSearchBonus => 16;
    public override int BaseSearchFrequency => 20;
    public override int BaseMeleeAttackBonus => 34;
    public override int BaseRangedAttackBonus => 20;
    public override int DisarmBonusPerLevel => 7;
    public override int DeviceBonusPerLevel => 13;
    public override int SaveBonusPerLevel => 9;
    public override int StealthBonusPerLevel => 0;
    public override int SearchBonusPerLevel => 0;
    public override int SearchFrequencyPerLevel => 0;
    public override int MeleeAttackBonusPerLevel => 15;
    public override int RangedAttackBonusPerLevel => 15;
    public override int HitDieBonus => 0;
    public override int ExperienceFactor => 30;

    public override string ClassSubName(Realm? realm)
    {
        switch (realm)
        {
            case LifeRealm:
                return "Vivimancer";

            case SorceryRealm:
                return "Sorcerer";

            case NatureRealm:
                return "Naturist";

            case ChaosRealm:
                return "Warlock";

            case DeathRealm:
                return "Necromancer";

            case TarotRealm:
                return "Summoner";

            case FolkRealm:
                return "Hedge Wizard";

            case CorporealRealm:
                return "Zen Master";

            default:
                return "High Mage";
        }
    }
    public override int PrimeStat => Ability.Intelligence;
    public override string[] Info => new string[] {
        "INT based spell casters who specialise in a single realm",
        "of magic. They may choose any realm, and are better at",
        "casting spells from that realm than a normal mage. High",
        "mages also get more mana than other spell casters do.",
        "Wearing too much armor disrupts their casting."
    };
    public override int SpellWeight => 300;

    /// <summary>
    /// Returns true, because arcane spell casting movement can be encumbered by the spell weight of the players armor.
    /// </summary>
    public override bool WeightEncumbersMovement => true;


    /// <summary>
    /// Returns true, because arcane spell casting requires the players hands to be uncovered or be of free-action, dexterity or typespecificvalue == 0.
    /// </summary>
    public override bool CoveredHandsRestrictCasting => true;


    public override bool DoesNotGainSpellLevelsUntilFirstSpellLevel => true;
    public override int SpellStat => Ability.Intelligence;
    public override int MaximumMeleeAttacksPerRound(int level) => 4;
    public override int MaximumWeight => 40;
    public override int AttackSpeedMultiplier => 2;
    public override ArtifactBias? ArtifactBias => Game.SingletonRepository.Get<ArtifactBias>(nameof(MageArtifactBias));
    public override bool SenseInventoryTest(int level) => (0 != Game.RandomLessThan(240000 / (level + 5)));
    public override Realm[] AvailablePrimaryRealms => new Realm[] {
        Game.SingletonRepository.Get<Realm>(nameof(LifeRealm)),
        Game.SingletonRepository.Get<Realm>(nameof(SorceryRealm)),
        Game.SingletonRepository.Get<Realm>(nameof(NatureRealm)),
        Game.SingletonRepository.Get<Realm>(nameof(ChaosRealm)),
        Game.SingletonRepository.Get<Realm>(nameof(DeathRealm)),
        Game.SingletonRepository.Get<Realm>(nameof(TarotRealm)),
        Game.SingletonRepository.Get<Realm>(nameof(FolkRealm)),
        Game.SingletonRepository.Get<Realm>(nameof(CorporealRealm))
    };

    protected override string[] OutfitItemFactoryNames => new string[]
    {
        nameof(DaggerWeaponItemFactory),
        nameof(SustainIntelligenceRingItemFactory)
    };
}
