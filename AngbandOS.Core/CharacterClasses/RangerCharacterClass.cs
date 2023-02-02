using AngbandOS;

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
    }
}
