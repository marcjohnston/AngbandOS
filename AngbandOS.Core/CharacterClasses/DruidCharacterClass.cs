// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.CharacterClasses;

[Serializable]
internal class DruidCharacterClass : BaseCharacterClass
{
    private DruidCharacterClass(Game savedGame) : base(savedGame) { }
    public override int ID => 11;
    public override string Title => "Druid";
    public override int[] AbilityBonus => new[] { -1, -3, 4, -2, 0, 3 };
    public override int BaseDisarmBonus => 30;
    public override int BaseDeviceBonus => 30;
    public override int BaseSaveBonus => 32;
    public override int BaseStealthBonus => 3;
    public override int BaseSearchBonus => 20;
    public override int BaseSearchFrequency => 8;
    public override int BaseMeleeAttackBonus => 48;
    public override int BaseRangedAttackBonus => 36;
    public override int DisarmBonusPerLevel => 8;
    public override int DeviceBonusPerLevel => 10;
    public override int SaveBonusPerLevel => 12;
    public override int StealthBonusPerLevel => 0;
    public override int SearchBonusPerLevel => 0;
    public override int SearchFrequencyPerLevel => 0;
    public override int MeleeAttackBonusPerLevel => 20;
    public override int RangedAttackBonusPerLevel => 20;
    public override int HitDieBonus => 3;
    public override int ExperienceFactor => 20;
    public override int PrimeStat => Ability.Wisdom;
    public override string[] Info => new string[] {
        "Nature priests who use WIS based spell casting and who are",
        "limited to the Nature realm. As priests, they can't use",
        "edged weapons unless those weapons are holy; but they can",
        "wear heavy armor without it disrupting their casting."
    };
    public override int SpellWeight => 350;

    public override bool DoesNotGainSpellLevelsUntilFirstSpellLevel => true;

    /// <summary>
    /// Returns "prayer" because the diving casting type uses prayers.
    /// </summary>
    public override string MagicType => "prayer";

    /// <summary>
    /// Returns false, because the diving casting type does not allow the player to choose which prayer to learn.
    /// </summary>
    public override bool CanChooseSpellToStudy => false;

    /// <summary>
    /// Returns "prayer" because the diving casting type uses prayers for magic.
    /// </summary>
    public override string SpellNoun => "prayer";

    /// <summary>
    /// Returns "recite" because the divine casting type recites prayers; as opposed to casting spells.
    /// </summary>
    public override string CastVerb => "recite";

    /// <summary>
    /// Returns true, because the Druid class is divine and spellbooks should render as a simple book.
    /// </summary>
    public override bool UseAlternateItemNames => true;

    public override int SpellStat => Ability.Wisdom;
    public override ArtifactBias? ArtifactBias => Game.SingletonRepository.Get<ArtifactBias>(nameof(PriestlyArtifactBias));
    public override bool SenseInventoryTest(int level) => (0 != Game.RandomLessThan(10000 / ((level * level) + 40)));
    public override Realm[] AvailablePrimaryRealms => new Realm[] {
        Game.SingletonRepository.Get<Realm>(nameof(NatureRealm))
    };

    protected override string[] OutfitItemFactoryNames => new string[]
    {
        nameof(QuarterstaffHaftedWeaponItemFactory),
        nameof(SustainWisdomRingItemFactory)
    };
}
