﻿using AngbandOS.Core.Syllables;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.Races
{
    [Serializable]
    internal class HalfGiantRace : Race
    {
        public override string Title => "Half Giant";
        public override int[] AbilityBonus => new int[] { 4, -2, -2, -2, 3, -3 };
        public override int BaseDisarmBonus => -6;
        public override int BaseDeviceBonus => -8;
        public override int BaseSaveBonus => -6;
        public override int BaseStealthBonus => -2;
        public override int BaseSearchBonus => -1;
        public override int BaseSearchFrequency => 5;
        public override int BaseMeleeAttackBonus => 25;
        public override int BaseRangedAttackBonus => 5;
        public override int HitDieBonus => 13;
        public override int ExperienceFactor => 150;
        public override int BaseAge => 40;
        public override int AgeRange => 10;
        public override int MaleBaseHeight => 100;
        public override int MaleHeightRange => 10;
        public override int MaleBaseWeight => 255;
        public override int MaleWeightRange => 65;
        public override int FemaleBaseHeight => 80;
        public override int FemaleHeightRange => 10;
        public override int FemaleBaseWeight => 240;
        public override int FemaleWeightRange => 64;
        public override int Infravision => 3;
        public override uint Choice => 0x0011;
        public override int Index => RaceId.HalfGiant;
        public override string Description => "Half-Giants are immensely strong and tough, and their skin\nis stony. They can't have their strength reduced, and they\nresist damage from explosions that throw out shards of\nstone and metal. They can learn to soften rock into mud\n(at lvl 10).";

        /// <summary>
        /// Half-Giant 75->20->2->3->50->51->52->53->End
        /// </summary>
        public override int Chart => 75;

        public override string RacialPowersDescription(int lvl) => lvl < 20 ? "stone to mud       (racial, unusable until level 20)" : "stone to mud       (racial, cost 10, STR based)";
        public override bool HasRacialPowers => true;
        public override void UpdateRacialAbilities(int level, ItemCharacteristics itemCharacteristics)
        {
            itemCharacteristics.ResShards = true;
            itemCharacteristics.SustStr = true;
        }
        public override string CreateRandomName() => CreateRandomNameFromSyllables(new DwarvenSyllables());
    }
}