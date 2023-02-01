using AngbandOS;

namespace AngbandOS.Core.CharacterClasses
{
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
    }
}
