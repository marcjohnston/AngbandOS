namespace AngbandOS.Core.CharacterClasses
{
    [Serializable]
    internal class FanaticCharacterClass : BaseCharacterClass
    {
        private FanaticCharacterClass(SaveGame savedGame) : base(savedGame) { }
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
        public override CastingType SpellCastingType => CastingType.Divine;
        public override int SpellStat => Ability.Intelligence;
        public override int MaximumWeight => 30;
        public override int AttackSpeedMultiplier => 4;
        public override IArtifactBias? ArtifactBias => SaveGame.SingletonRepository.ArtifactBiases.Get<ChaosArtifactBias>();
        public override int FromScrollWarriorArtifactBiasPercentageChance => 40;
        public override bool SenseInventoryTest(int level) => (0 != Program.Rng.RandomLessThan(80000 / ((level * level) + 40)));
        public override bool DetailedSenseInventory => true;
        public override BaseRealm[] AvailablePrimaryRealms => new BaseRealm[] {
            SaveGame.SingletonRepository.Realms.Get<ChaosRealm>()
        };

        protected override ItemFactory[] Outfit => new ItemFactory[]
        {
            SaveGame.SingletonRepository.ItemFactories.Get<BeginnersHandbookSorceryBookItemFactory>(),
            SaveGame.SingletonRepository.ItemFactories.Get<SwordBroadSword>(),
            SaveGame.SingletonRepository.ItemFactories.Get<HardArmorMetalScaleMail>()
        };
    }
}
