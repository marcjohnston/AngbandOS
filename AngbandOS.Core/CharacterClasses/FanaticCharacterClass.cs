// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.CharacterClasses;

[Serializable]
internal class FanaticCharacterClass : BaseCharacterClass
{
    private FanaticCharacterClass(Game savedGame) : base(savedGame) { }
    public override int ID => 7;
    public override string Title => "Fanatic";
    public override int[] AbilityBonus => new[] { 2, 1, 0, 1, 2, -2 };
    public override int BaseDisarmBonus => 20;
    public override int BaseDeviceBonus => 24;
    public override int BaseSaveBonus => 30;
    public override int BaseStealthBonus => 1;
    public override int BaseSearchBonus => 14;
    public override int BaseSearchFrequency => 12;
    public override int BaseMeleeAttackBonus => 66;
    public override int BaseRangedAttackBonus => 40;
    public override int DisarmBonusPerLevel => 7;
    public override int DeviceBonusPerLevel => 11;
    public override int SaveBonusPerLevel => 10;
    public override int StealthBonusPerLevel => 0;
    public override int SearchBonusPerLevel => 0;
    public override int SearchFrequencyPerLevel => 0;
    public override int MeleeAttackBonusPerLevel => 35;
    public override int RangedAttackBonusPerLevel => 30;
    public override int HitDieBonus => 6;
    public override int ExperienceFactor => 35;
    public override int PrimeStat => Ability.Intelligence;
    public override string[] Info => new string[] {
        "Warriors who dabble in INT based Chaos magic. Have a cult",
        "patron who will randomly give them rewards or punishments",
        "as they increase in level. Learn to resist chaos",
        "(at lvl 30) and fear (at lvl 40)."
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
    /// Returns true, because the Fanatic class is divine and spellbooks should render as a simple book.
    /// </summary>
    public override bool UseAlternateItemNames => true;

    public override int SpellStat => Ability.Intelligence;
    public override int MaximumWeight => 30;
    public override int AttackSpeedMultiplier => 4;
    public override ArtifactBias? ArtifactBias => Game.SingletonRepository.Get<ArtifactBias>(nameof(ChaosArtifactBias));
    public override int FromScrollWarriorArtifactBiasPercentageChance => 40;
    public override bool SenseInventoryTest(int level) => (0 != Game.RandomLessThan(80000 / ((level * level) + 40)));
    public override bool DetailedSenseInventory => true;
    public override Realm[] AvailablePrimaryRealms => new Realm[] {
        Game.SingletonRepository.Get<Realm>(nameof(ChaosRealm))
    };

    protected override string[] OutfitItemFactoryNames => new string[]
    {
        nameof(BroadSwordWeaponItemFactory),
        nameof(MetalScaleMailHardArmorItemFactory)
    };
}
