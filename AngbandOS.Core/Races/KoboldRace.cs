﻿using AngbandOS.Core.Syllables;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.Races
{
    [Serializable]
    internal class KoboldRace : Race
    {
        public override string Title => "Kobold";
        public override int[] AbilityBonus => new int[] { 1, -1, 0, 1, 0, -4 };
        public override int BaseDisarmBonus => -2;
        public override int BaseDeviceBonus => -3;
        public override int BaseSaveBonus => -2;
        public override int BaseStealthBonus => -1;
        public override int BaseSearchBonus => 1;
        public override int BaseSearchFrequency => 8;
        public override int BaseMeleeAttackBonus => 10;
        public override int BaseRangedAttackBonus => -8;
        public override int HitDieBonus => 9;
        public override int ExperienceFactor => 125;
        public override int BaseAge => 11;
        public override int AgeRange => 3;
        public override int MaleBaseHeight => 60;
        public override int MaleHeightRange => 1;
        public override int MaleBaseWeight => 130;
        public override int MaleWeightRange => 5;
        public override int FemaleBaseHeight => 55;
        public override int FemaleHeightRange => 1;
        public override int FemaleBaseWeight => 100;
        public override int FemaleWeightRange => 5;
        public override int Infravision => 3;
        public override uint Choice => 0xC009;
        public override int Index => RaceId.Kobold;
        public override string Description => "Kobolds are small reptillian creatures whose claims to be\nrelated to dragons are generally not taken seriously. They\nare resistant to poison, and can learn to throw poison\ndarts (at lvl 9).";

        /// <summary>
        /// Kobold 82->83->24->25->26->End
        /// </summary>
        public override int Chart => 82;

        public override string RacialPowersDescription(int lvl) => lvl < 12 ? "poison dart        (racial, unusable until level 12)" : "poison dart        (racial, cost 8, dam lvl, DEX based)";
        public override bool HasRacialPowers => true;

        public override void UpdateRacialAbilities(int level, ItemCharacteristics itemCharacteristics)
        {
            itemCharacteristics.ResPois = true;
        }
        public override string CreateRandomName() => CreateRandomNameFromSyllables(new HobbitSyllables());
    }
}