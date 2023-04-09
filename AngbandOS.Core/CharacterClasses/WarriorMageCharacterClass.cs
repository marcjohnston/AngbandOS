namespace AngbandOS.Core.CharacterClasses
{
    [Serializable]
    internal class WarriorMageCharacterClass : BaseCharacterClass
    {
        private WarriorMageCharacterClass(SaveGame savedGame) : base(savedGame) { }
        public override int ID => 6;
        public override string Title => "Warrior-Mage";
        public override int[] AbilityBonus => new[] { 2, 2, 0, 1, 0, 1 };
        public override int BaseDisarmBonus => 30;
        public override int BaseDeviceBonus => 30;
        public override int BaseSaveBonus => 28;
        public override int BaseStealthBonus => 2;
        public override int BaseSearchBonus => 18;
        public override int BaseSearchFrequency => 16;
        public override int BaseMeleeAttackBonus => 50;
        public override int BaseRangedAttackBonus => 26;
        public override int DisarmBonusPerLevel => 7;
        public override int DeviceBonusPerLevel => 10;
        public override int SaveBonusPerLevel => 9;
        public override int StealthBonusPerLevel => 0;
        public override int SearchBonusPerLevel => 0;
        public override int SearchFrequencyPerLevel => 0;
        public override int MeleeAttackBonusPerLevel => 20;
        public override int RangedAttackBonusPerLevel => 20;
        public override int HitDieBonus => 4;
        public override int ExperienceFactor => 50;
        public override int PrimeStat => Ability.Intelligence;
        public override string[] Info => new string[] {
            "A blend of both warrior and mage, getting the abilities of",
            "both but not being the best at either. They use INT based",
            "spell casting, getting access to the Folk realm plus a",
            "second realm of their choice. They pay for their extreme",
            "flexibility by increasing in level only slowly."
        };
        public override int SpellWeight => 350;
        public override CastingType SpellCastingType => CastingType.Arcane;
        public override int SpellStat => Ability.Intelligence;
        public override IArtifactBias? ArtifactBias => new MageArtifactBias();
        public override int FromScrollWarriorArtifactBiasPercentageChance => 40;
        public override bool SenseInventoryTest(int level) => (0 != Program.Rng.RandomLessThan(75000 / ((level * level) + 40)));
        public override BaseRealm[] AvailablePrimaryRealms => new BaseRealm[] {
            SaveGame.SingletonRepository.Realms.Get<NatureRealm>()
        };
        public override BaseRealm[] AvailableSecondaryRealms => new BaseRealm[] {
            SaveGame.SingletonRepository.Realms.Get<LifeRealm>(),
            SaveGame.SingletonRepository.Realms.Get<SorceryRealm>(),
            SaveGame.SingletonRepository.Realms.Get<NatureRealm>(),
            SaveGame.SingletonRepository.Realms.Get<ChaosRealm>(),
            SaveGame.SingletonRepository.Realms.Get<DeathRealm>(),
            SaveGame.SingletonRepository.Realms.Get<TarotRealm>(),
            SaveGame.SingletonRepository.Realms.Get<FolkRealm>(),
            SaveGame.SingletonRepository.Realms.Get<CorporealRealm>()
        };
        public override bool WorshipsADeity => true;

        protected override ItemFactory[] Outfit => new ItemFactory[]
        {
            SaveGame.SingletonRepository.ItemCategories.Get<SorceryBookBeginnersHandbook>(),
            SaveGame.SingletonRepository.ItemCategories.Get<SwordShortSword>(),
            SaveGame.SingletonRepository.ItemCategories.Get<DeathBookBlackPrayers>()
        };
    }
}
