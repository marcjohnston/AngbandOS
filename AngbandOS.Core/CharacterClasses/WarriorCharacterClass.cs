﻿namespace AngbandOS.Core.CharacterClasses
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
    }
}