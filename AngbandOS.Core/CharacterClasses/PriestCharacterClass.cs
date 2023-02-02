using AngbandOS;

namespace AngbandOS.Core.CharacterClasses
{
    [Serializable]
    internal class PriestCharacterClass : BaseCharacterClass
    {
        private PriestCharacterClass(SaveGame savedGame) : base(savedGame) { }
        public override int ID => 2;
        public override string Title => "Priest";
        public override int[] AbilityBonus => new[] { -1, -3, 3, -1, 0, 2 };
        public override int BaseDisarmBonus => 25;
        public override int BaseDeviceBonus => 30;
        public override int BaseSaveBonus => 32;
        public override int BaseStealthBonus => 2;
        public override int BaseSearchBonus => 16;
        public override int BaseSearchFrequency => 8;
        public override int BaseMeleeAttackBonus => 48;
        public override int BaseRangedAttackBonus => 36;
        public override int DisarmBonusPerLevel => 7;
        public override int DeviceBonusPerLevel => 10;
        public override int SaveBonusPerLevel => 12;
        public override int StealthBonusPerLevel => 0;
        public override int SearchBonusPerLevel => 0;
        public override int SearchFrequencyPerLevel => 0;
        public override int MeleeAttackBonusPerLevel => 20;
        public override int RangedAttackBonusPerLevel => 20;
        public override int HitDieBonus => 2;
        public override int ExperienceFactor => 20;
        public override string ClassSubName(Realm realm)
        {
            return realm == Realm.Death ? "Exorcist" : "Priest";
        }
        public override int PrimeStat => Ability.Wisdom;
    }
}
