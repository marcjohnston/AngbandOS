using AngbandOS;

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
    }
}
