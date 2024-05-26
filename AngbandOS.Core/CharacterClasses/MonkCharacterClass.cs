// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.CharacterClasses;

[Serializable]
internal class MonkCharacterClass : BaseCharacterClass
{
    private MonkCharacterClass(Game savedGame) : base(savedGame) { }
    public override int ID => 8;
    public override string Title => "Monk";
    public override int[] AbilityBonus => new[] { 2, -1, 1, 3, 2, 1 };
    public override int BaseDisarmBonus => 45;
    public override int BaseDeviceBonus => 32;
    public override int BaseSaveBonus => 28;
    public override int BaseStealthBonus => 5;
    public override int BaseSearchBonus => 32;
    public override int BaseSearchFrequency => 24;
    public override int BaseMeleeAttackBonus => 64;
    public override int BaseRangedAttackBonus => 50;
    public override int DisarmBonusPerLevel => 15;
    public override int DeviceBonusPerLevel => 12;
    public override int SaveBonusPerLevel => 10;
    public override int StealthBonusPerLevel => 0;
    public override int SearchBonusPerLevel => 0;
    public override int SearchFrequencyPerLevel => 0;
    public override int MeleeAttackBonusPerLevel => 40;
    public override int RangedAttackBonusPerLevel => 30;
    public override int HitDieBonus => 6;
    public override int ExperienceFactor => 40;

    public override string ClassSubName(Realm? realm)
    {
        switch (realm)
        {
            case CorporealRealm:
                return "Ascetic";

            case TarotRealm:
                return "Ninja";

            case ChaosRealm:
                return "Street Fighter";

            default:
                return "Monk";
        }
    }
    public override int PrimeStat => Ability.Dexterity;
    public override string[] Info => new string[] {
        "Masters of unarmed combat. While wearing only light armor",
        "they can move faster and dodge blows and can learn to",
        "resist paralysis (at lvl 25). While not wielding a weapon",
        "they have extra attacks and do increased damage. They are",
        "WIS based casters using Chaos, Tarot or Corporeal magic."
    };
    public override int SpellWeight => 300;

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
    /// Returns true, because the Monk class is divine and spellbooks should render as a simple book.
    /// </summary>
    public override bool UseAlternateItemNames => true;

    public override int SpellStat => Ability.Wisdom;
    public override int MaximumMeleeAttacksPerRound(int level) => level < 40 ? 3 : 4;
    public override int MaximumWeight => 40;
    public override int AttackSpeedMultiplier => 4;
    public override ArtifactBias? ArtifactBias => Game.SingletonRepository.Get<ArtifactBias>(nameof(PriestlyArtifactBias));
    public override bool SenseInventoryTest(int level) => (0 != Game.RandomLessThan(20000 / ((level * level) + 40)));
    public override Realm[] AvailablePrimaryRealms => new Realm[] {
        Game.SingletonRepository.Get<Realm>(nameof(ChaosRealm)),
        Game.SingletonRepository.Get<Realm>(nameof(TarotRealm)),
        Game.SingletonRepository.Get<Realm>(nameof(CorporealRealm))
    };

    protected override string[] OutfitItemFactoryNames => new string[]
    {
        nameof(HealingPotionItemFactory),
        nameof(SoftLeatherSoftArmorItemFactory)
    };
}
