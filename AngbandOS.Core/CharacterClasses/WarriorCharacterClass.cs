namespace AngbandOS.Core.CharacterClasses
{
    [Serializable]
    internal class WarriorCharacterClass : BaseCharacterClass
    {
        private WarriorCharacterClass(SaveGame savedGame) : base(savedGame) { }
        public override int ID => 0;
        public override string Title => "Warrior";
        public override int[] AbilityBonus => new[] { 5, -2, -2, 2, 2, -1 };
        public override int BaseDisarmBonus => 25;
        public override int BaseDeviceBonus => 18;
        public override int BaseSaveBonus => 18;
        public override int BaseStealthBonus => 1;
        public override int BaseSearchBonus => 14;
        public override int BaseSearchFrequency => 2;
        public override int BaseMeleeAttackBonus => 70;
        public override int BaseRangedAttackBonus => 60;
        public override int DisarmBonusPerLevel => 12;
        public override int DeviceBonusPerLevel => 7;
        public override int SaveBonusPerLevel => 10;
        public override int StealthBonusPerLevel => 0;
        public override int SearchBonusPerLevel => 0;
        public override int SearchFrequencyPerLevel => 0;
        public override int MeleeAttackBonusPerLevel => 45;
        public override int RangedAttackBonusPerLevel => 45;
        public override int HitDieBonus => 9;
        public override int ExperienceFactor => 0;
        public override int PrimeStat => Ability.Strength;
        public override string[] Info => new string[] {
            "Straightforward, no-nonsense fighters. They are the best",
            "characters at melee combat, and require the least amount",
            "of experience to increase in level. They can learn to",
            "resist fear (at lvl 30). The ideal class for novices."
        };
        public override int MaximumMeleeAttacksPerRound(int level) => 6;
        public override int MaximumWeight => 30;
        public override int AttackSpeedMultiplier => 5;
        public override IArtifactBias? ArtifactBias => new WarriorArtifactBias();
        public override bool SenseInventoryTest(int level) => (0 != Program.Rng.RandomLessThan(9000 / ((level * level) + 40)));
        public override bool DetailedSenseInventory => true;

        /// <summary>
        /// Warriors always gain experience when they destroy spell books.
        /// destroyed.
        /// </summary>
        /// <param name="item">The item.</param>
        public override void ItemDestroyed(Item item, int amount)
        {
            // Warriors and paladins get experience for destroying magic books
            if (SaveGame.ItemFilterHighLevelBook(item))
            {
                BookItem bookItem = (BookItem)item;
                GainExperienceFromSpellBookDestroy(bookItem, amount);
            }
        }

        protected override ItemFactory[] Outfit => new ItemFactory[]
        {
            SaveGame.SingletonRepository.ItemCategories.Get<RingFearResistance>(),
            SaveGame.SingletonRepository.ItemCategories.Get<SwordBroadSword>(),
            SaveGame.SingletonRepository.ItemCategories.Get<HardArmorChainMail>()
        };
    }
}
