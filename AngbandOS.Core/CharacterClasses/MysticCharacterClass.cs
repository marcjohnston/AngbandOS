namespace AngbandOS.Core.CharacterClasses
{
    [Serializable]
    internal class MysticCharacterClass : BaseCharacterClass
    {
        private MysticCharacterClass(SaveGame savedGame) : base(savedGame) { }
        public override int ID => 15;
        public override string Title => "Mystic";
        public override int[] AbilityBonus => new[] { 2, -1, 2, 2, 2, 0 };
        public override int BaseDisarmBonus => 40;
        public override int BaseDeviceBonus => 30;
        public override int BaseSaveBonus => 30;
        public override int BaseStealthBonus => 5;
        public override int BaseSearchBonus => 32;
        public override int BaseSearchFrequency => 24;
        public override int BaseMeleeAttackBonus => 64;
        public override int BaseRangedAttackBonus => 50;
        public override int DisarmBonusPerLevel => 14;
        public override int DeviceBonusPerLevel => 11;
        public override int SaveBonusPerLevel => 11;
        public override int StealthBonusPerLevel => 0;
        public override int SearchBonusPerLevel => 0;
        public override int SearchFrequencyPerLevel => 0;
        public override int MeleeAttackBonusPerLevel => 40;
        public override int RangedAttackBonusPerLevel => 30;
        public override int HitDieBonus => 6;
        public override int ExperienceFactor => 40;
        public override int PrimeStat => Ability.Wisdom;
        public override string[] Info => new string[] {
            "Mystics master both martial and psionic arts, which they",
            "power using WIS. Can resist confusion (at lvl 10), fear",
            "(lvl 25), paralysis (lvl 30). Telepathy (lvl 40). While",
            "wearing only light armour they can move faster and dodge,",
            "and while not wielding a weapon they do increased damage."
        };
        public override int SpellWeight => 300;
        public override CastingType SpellCastingType => CastingType.Mentalism;
        public override int SpellStat => Ability.Wisdom;
        public override int MaximumMeleeAttacksPerRound(int level) => level < 40 ? 3 : 4;
        public override int MaximumWeight => 40;
        public override int AttackSpeedMultiplier => 4;
        public override IArtifactBias? ArtifactBias => SaveGame.SingletonRepository.ArtifactBiases.Get<PriestlyArtifactBias>();
        public override bool SenseInventoryTest(int level) => (0 != Program.Rng.RandomLessThan(55000 / ((level * level) + 40)));

        protected override ItemFactory[] Outfit => new ItemFactory[]
        {
            SaveGame.SingletonRepository.ItemFactories.Get<RingSustainWisdom>(),
            SaveGame.SingletonRepository.ItemFactories.Get<PotionHealing>(),
            SaveGame.SingletonRepository.ItemFactories.Get<SoftArmorSoftLeatherArmour>()
        };
    }
}
