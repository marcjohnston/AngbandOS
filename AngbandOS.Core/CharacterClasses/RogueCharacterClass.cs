﻿using AngbandOS;

namespace AngbandOS.Core.CharacterClasses
{
    [Serializable]
    internal class RogueCharacterClass : BaseCharacterClass
    {
        private RogueCharacterClass(SaveGame savedGame) : base(savedGame) { }
        public override int ID => 3;
        public override string Title => "Rogue";
        public override int[] AbilityBonus => new[] { 2, 1, -2, 3, 1, -1 };
        public override int BaseDisarmBonus => 45;
        public override int BaseDeviceBonus => 32;
        public override int BaseSaveBonus => 28;
        public override int BaseStealthBonus => 5;
        public override int BaseSearchBonus => 32;
        public override int BaseSearchFrequency => 24;
        public override int BaseMeleeAttackBonus => 60;
        public override int BaseRangedAttackBonus => 66;
        public override int DisarmBonusPerLevel => 15;
        public override int DeviceBonusPerLevel => 10;
        public override int SaveBonusPerLevel => 10;
        public override int StealthBonusPerLevel => 0;
        public override int SearchBonusPerLevel => 0;
        public override int SearchFrequencyPerLevel => 0;
        public override int MeleeAttackBonusPerLevel => 40;
        public override int RangedAttackBonusPerLevel => 10;
        public override int HitDieBonus => 6;
        public override int ExperienceFactor => 25;
        public override string ClassSubName(Realm realm)
        {
            switch (realm)
            {
                case Realm.Sorcery:
                    return "Burglar";

                case Realm.Death:
                    return "Assassin";

                case Realm.Tarot:
                    return "Card Sharp";

                default:
                    return "Thief";
            }
        }
        public override int PrimeStat => Ability.Dexterity;
        public override string[] Info => new string[] {
            "Stealth based characters who are adept at picking locks,",
            "searching, and disarming traps. Rogues can use stealth to",
            "their advantage in order to backstab sleeping or fleeing",
            "foes. They also dabble in INT based magic, learning spells",
            "from the Tarot, Sorcery, Death, or Folk realms."
       };
        public override int SpellWeight => 350;
    }
}