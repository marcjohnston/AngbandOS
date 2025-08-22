// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.CharacterClasses;

[Serializable]
internal class PaladinCharacterClass : BaseCharacterClass
{
    private PaladinCharacterClass(Game savedGame) : base(savedGame) { }
    protected override string EnhancementBindingKey => nameof(PaladinCharacterClassItemEnhancement);
    public override int ID => 5;
    public override string Title => "Paladin";
    public override int? InstantFearResistanceLevel => 40;
    public override int BaseDisarmBonus => 20;
    public override int BaseDeviceBonus => 24;
    public override int BaseSaveBonus => 26;
    public override int BaseStealthBonus => 1;
    public override int BaseSearchBonus => 12;
    public override int BaseSearchFrequency => 2;
    public override int BaseMeleeAttackBonus => 68;
    public override int BaseRangedAttackBonus => 40;
    public override int DisarmBonusPerLevel => 7;
    public override int DeviceBonusPerLevel => 10;
    public override int SaveBonusPerLevel => 11;
    public override int StealthBonusPerLevel => 0;
    public override int SearchBonusPerLevel => 0;
    public override int SearchFrequencyPerLevel => 0;
    public override int MeleeAttackBonusPerLevel => 35;
    public override int RangedAttackBonusPerLevel => 30;
    public override int HitDieBonus => 6;
    public override int ExperienceFactor => 35;

    public override Ability PrimeStat => Game.WisdomAbility;
    public override string[] Info => new string[] {
        "Holy warriors who use WIS based spell casting to supplement",
        "their fighting skills. Paladins can specialise in either",
        "Life or Death magic, but their spell casting is weak in",
        "comparison to a full priest. Paladins learn to resist fear",
        "(at lvl 40)."
    };
    public override int SpellWeight => 400;
    public override void Cast() => CastMentalism();
    public override Ability SpellStat => Game.WisdomAbility;
    public override int MaximumWeight => 30;
    public override int AttackSpeedMultiplier => 4;
    public override ArtifactBias? ArtifactBias => Game.SingletonRepository.Get<ArtifactBias>(nameof(PriestlyArtifactBias));
    public override int FromScrollWarriorArtifactBiasPercentageChance => 40;
    public override bool SenseInventoryTest(int level) => (0 != Game.RandomLessThan(77777 / ((level * level) + 40)));
    public override bool DetailedSenseInventory => true;
    public override Realm[] AvailablePrimaryRealms => new Realm[] {
        Game.SingletonRepository.Get<Realm>(nameof(LifeRealm)),
        Game.SingletonRepository.Get<Realm>(nameof(DeathRealm))
    };

    protected override string[] OutfitItemFactoryNames => new string[]
    {
        nameof(BroadSwordWeaponItemFactory),
        nameof(ProtectionFromEvilScrollItemFactory)
    };

    public override void CalcBonuses()
    {
        if (Game.ExperienceLevel.IntValue > 39)
        {
            Game.HasFearResistance = true;
        }
    }
    protected override string[]? ItemActionNames => new string[]
    {
        nameof(GainExperienceForUnusableHighLevelSpellBookDestroyedItemAction)
    };
}
