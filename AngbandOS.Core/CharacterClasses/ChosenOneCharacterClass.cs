namespace AngbandOS.Core.CharacterClasses
{
    [Serializable]
    internal class ChosenOneCharacterClass : BaseCharacterClass
    {
        private ChosenOneCharacterClass(SaveGame savedGame) : base(savedGame) { }
        public override int ID => 14;
        public override string Title => "Chosen One";
        public override int[] AbilityBonus => new[] { 3, -2, -2, 2, 2, -1 };
        public override int BaseDisarmBonus => 25;
        public override int BaseDeviceBonus => 18;
        public override int BaseSaveBonus => 20;
        public override int BaseStealthBonus => 1;
        public override int BaseSearchBonus => 16;
        public override int BaseSearchFrequency => 4;
        public override int BaseMeleeAttackBonus => 50;
        public override int BaseRangedAttackBonus => 32;
        public override int DisarmBonusPerLevel => 12;
        public override int DeviceBonusPerLevel => 7;
        public override int SaveBonusPerLevel => 10;
        public override int StealthBonusPerLevel => 0;
        public override int SearchBonusPerLevel => 0;
        public override int SearchFrequencyPerLevel => 0;
        public override int MeleeAttackBonusPerLevel => 20;
        public override int RangedAttackBonusPerLevel => 20;
        public override int HitDieBonus => 4;
        public override int ExperienceFactor => 20;
        public override int PrimeStat => Ability.Strength;
        public override string[] Info => new string[] {
            "Warriors of fate, who have no spell casting abilities but",
            "gain a large number of passive magical abilities (too long",
            "to list here) as they increase in level."
        };
        public override IArtifactBias? ArtifactBias => new WarriorArtifactBias();
        public override bool SenseInventoryTest(int level) => (0 != Program.Rng.RandomLessThan(9000 / ((level * level) + 40)));
        public override bool DetailedSenseInventory => true;

        public override ItemClass[] Outfit => new ItemClass[]
        {
            SaveGame.SingletonRepository.ItemCategories.Get<SwordSmallSword>(),
            SaveGame.SingletonRepository.ItemCategories.Get<PotionHealing>(),
            SaveGame.SingletonRepository.ItemCategories.Get<SoftArmorSoftLeatherArmour>()
        };
    }
}
