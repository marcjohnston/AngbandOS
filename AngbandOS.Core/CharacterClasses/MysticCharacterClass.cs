using AngbandOS;

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
    }
}
