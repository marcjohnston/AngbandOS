// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.CharacterClasses;

[Serializable]
internal class ChannelerCharacterClass : BaseCharacterClass
{
    private ChannelerCharacterClass(SaveGame savedGame) : base(savedGame) { }
    public override int ID => 13;
    public override string Title => "Channeler";
    public override int[] AbilityBonus => new[] { -1, 0, 2, -1, -1, 3 };
    public override int BaseDisarmBonus => 40;
    public override int BaseDeviceBonus => 40;
    public override int BaseSaveBonus => 30;
    public override int BaseStealthBonus => 2;
    public override int BaseSearchBonus => 16;
    public override int BaseSearchFrequency => 20;
    public override int BaseMeleeAttackBonus => 40;
    public override int BaseRangedAttackBonus => 30;
    public override int DisarmBonusPerLevel => 12;
    public override int DeviceBonusPerLevel => 13;
    public override int SaveBonusPerLevel => 9;
    public override int StealthBonusPerLevel => 0;
    public override int SearchBonusPerLevel => 0;
    public override int SearchFrequencyPerLevel => 0;
    public override int MeleeAttackBonusPerLevel => 15;
    public override int RangedAttackBonusPerLevel => 15;
    public override int HitDieBonus => 1;
    public override int ExperienceFactor => 30;
    public override int PrimeStat => Ability.Charisma;
    public override string[] Info => new string[] {
        "Similar to a spell caster, but rather than casting spells",
        "from a book, they can use their CHA to channel mana into",
        "most types of item, powering the effects of the items",
        "without depleting them."
    };
    public override int SpellWeight => 400;
    public override CastingType SpellCastingType => SaveGame.SingletonRepository.CastingTypes.Get(nameof(ChannelingCastingType));
    public override int SpellStat => Ability.Charisma;
    public override int MaximumMeleeAttacksPerRound(int level) => 4;
    public override int MaximumWeight => 40;
    public override int AttackSpeedMultiplier => 2;
    public override IArtifactBias? ArtifactBias => SaveGame.SingletonRepository.ArtifactBiases.Get(nameof(MageArtifactBias));
    public override bool SenseInventoryTest(int level) => (0 != SaveGame.RandomLessThan(9000 / ((level * level) + 40)));
    public override bool DetailedSenseInventory => true;

    protected override string[] OutfitItemFactoryNames => new string[]
    {
        nameof(MagicMissileWandItemFactory),
        nameof(DaggerWeaponItemFactory),
        nameof(SustainCharismaRingItemFactory)
   };
}
