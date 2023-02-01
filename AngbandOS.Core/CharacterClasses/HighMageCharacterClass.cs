using AngbandOS;

namespace AngbandOS.Core.CharacterClasses
{
    [Serializable]
    internal class HighMageCharacterClass : BaseCharacterClass
    {
        private HighMageCharacterClass(SaveGame savedGame) : base(savedGame) { }
        public override int ID => 10;
        public override string Title => "High-Mage";
        public override int[] AbilityBonus => new[] { -5, 4, 0, 0, -2, 1 };
        public override int BaseDisarmBonus => 30;
        public override int BaseDeviceBonus => 38;
        public override int BaseSaveBonus => 30;
        public override int BaseStealthBonus => 2;
        public override int BaseSearchBonus => 16;
        public override int BaseSearchFrequency => 20;
        public override int BaseMeleeAttackBonus => 34;
        public override int BaseRangedAttackBonus => 20;
        public override int DisarmBonusPerLevel => 7;
        public override int DeviceBonusPerLevel => 13;
        public override int SaveBonusPerLevel => 9;
        public override int StealthBonusPerLevel => 0;
        public override int SearchBonusPerLevel => 0;
        public override int SearchFrequencyPerLevel => 0;
        public override int MeleeAttackBonusPerLevel => 15;
        public override int RangedAttackBonusPerLevel => 15;
        public override int HitDieBonus => 0;
        public override int ExperienceFactor => 30;
    }
}
