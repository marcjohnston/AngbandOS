﻿using AngbandOS;

namespace AngbandOS.Core.CharacterClasses
{
    [Serializable]
    internal class PaladinCharacterClass : BaseCharacterClass
    {
        private PaladinCharacterClass(SaveGame savedGame) : base(savedGame) { }
        public override int ID => 5;
        public override string Title => "Paladin";
        public override int[] AbilityBonus => new[] { 3, -3, 1, 0, 2, 2 };
        public override int BaseDisarmBonus => 20;
        public override int BaseDeviceBonus => 24;
        public override int BaseSaveBonus => 26;
        public override int BaseStealthBonus => 1;
        public override int BaseSearchBonus => 12;
        public override int BaseSearchFrequency => 2;
        public override int BaseMeleeAttackBonus => 68;
        public override int BaseRangedAttackBonus => 40;
        public override int DisarmBonusPerLevel => 7;
        public override int DeviceBonusPerLevel => 10;
        public override int SaveBonusPerLevel => 11;
        public override int StealthBonusPerLevel => 0;
        public override int SearchBonusPerLevel => 0;
        public override int SearchFrequencyPerLevel => 0;
        public override int MeleeAttackBonusPerLevel => 35;
        public override int RangedAttackBonusPerLevel => 30;
        public override int HitDieBonus => 6;
        public override int ExperienceFactor => 35;

        public override string ClassSubName(Realm realm)
        {
            return realm == Realm.Death ? "Death Knight" : "Paladin";
        }
        public override int PrimeStat => Ability.Wisdom;
        public override string[] Info => new string[] {
            "Holy warriors who use WIS based spell casting to supplement",
            "their fighting skills. Paladins can specialise in either",
            "Life or Death magic, but their spell casting is weak in",
            "comparison to a full priest. Paladins learn to resist fear",
            "(at lvl 40)."
        };
        public override int SpellWeight => 400;
    }
}