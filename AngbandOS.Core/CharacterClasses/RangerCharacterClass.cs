namespace AngbandOS.Core.CharacterClasses
{
    [Serializable]
    internal class RangerCharacterClass : BaseCharacterClass
    {
        private RangerCharacterClass(SaveGame savedGame) : base(savedGame) { }
        public override int ID => 4;
        public override string Title => "Ranger";
        public override int[] AbilityBonus => new[] { 2, 2, 0, 1, 1, 1 };
        public override int BaseDisarmBonus => 30;
        public override int BaseDeviceBonus => 32;
        public override int BaseSaveBonus => 28;
        public override int BaseStealthBonus => 3;
        public override int BaseSearchBonus => 24;
        public override int BaseSearchFrequency => 16;
        public override int BaseMeleeAttackBonus => 56;
        public override int BaseRangedAttackBonus => 72;
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
        public override int PrimeStat => Ability.Intelligence;
        public override string[] Info => new string[] {
            "Masters of ranged combat, especiallly using bows. Rangers",
            "supplement their shooting and stealth with INT based spell",
            "casting from the Nature realm plus another realm of their",
            "choice from Death, Corporeal, Tarot, Chaos, and Folk."
        };
        public override int SpellWeight => 400;
        public override CastingType SpellCastingType => SaveGame.SingletonRepository.CastingTypes.Get<DivineCastingType>();
        public override int SpellStat => Ability.Intelligence;
        public override int AttackSpeedMultiplier => 4;
        public override IArtifactBias? ArtifactBias => SaveGame.SingletonRepository.ArtifactBiases.Get<RangerArtifactBias>();
        public override int FromScrollWarriorArtifactBiasPercentageChance => 30;
        public override bool SenseInventoryTest(int level) => (0 != Program.Rng.RandomLessThan(95000 / ((level * level) + 40)));
        public override bool DetailedSenseInventory => true;
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
            SaveGame.SingletonRepository.ItemFactories.Get<CallOfTheWildNatureBookItemFactory>(),
            SaveGame.SingletonRepository.ItemFactories.Get<SwordBroadSword>(),
            SaveGame.SingletonRepository.ItemFactories.Get<BlackPrayersDeathBookItemFactory>()
        };
    }
}
