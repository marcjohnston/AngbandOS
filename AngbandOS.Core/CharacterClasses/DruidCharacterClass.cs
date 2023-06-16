namespace AngbandOS.Core.CharacterClasses;

[Serializable]
internal class DruidCharacterClass : BaseCharacterClass
{
    private DruidCharacterClass(SaveGame savedGame) : base(savedGame) { }
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
        "wear heavy armour without it disrupting their casting."
    };
    public override int SpellWeight => 350;
    public override CastingType SpellCastingType => SaveGame.SingletonRepository.CastingTypes.Get<DivineCastingType>();
    public override int SpellStat => Ability.Wisdom;
    public override IArtifactBias? ArtifactBias => SaveGame.SingletonRepository.ArtifactBiases.Get<PriestlyArtifactBias>();
    public override bool SenseInventoryTest(int level) => (0 != Program.Rng.RandomLessThan(10000 / ((level * level) + 40)));
    public override BaseRealm[] AvailablePrimaryRealms => new BaseRealm[] {
        SaveGame.SingletonRepository.Realms.Get<NatureRealm>()
    };

    protected override ItemFactory[] Outfit => new ItemFactory[]
    {
        SaveGame.SingletonRepository.ItemFactories.Get<BeginnersHandbookSorceryBookItemFactory>(),
        SaveGame.SingletonRepository.ItemFactories.Get<HaftedQuarterstaff>(),
        SaveGame.SingletonRepository.ItemFactories.Get<SustainWisdomRingItemFactory>()
    };
}
