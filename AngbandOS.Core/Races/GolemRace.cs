﻿using AngbandOS.Core.Syllables;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.Races
{
    [Serializable]
    internal class GolemRace : Race
    {
        public override string Title => "Golem";
        public override int[] AbilityBonus => new int[] { 4, -5, -5, 0, 4, -4 };
        public override int BaseDisarmBonus => -5;
        public override int BaseDeviceBonus => -5;
        public override int BaseSaveBonus => 10;
        public override int BaseStealthBonus => -1;
        public override int BaseSearchBonus => -1;
        public override int BaseSearchFrequency => 8;
        public override int BaseMeleeAttackBonus => 20;
        public override int BaseRangedAttackBonus => 0;
        public override int HitDieBonus => 12;
        public override int ExperienceFactor => 200;
        public override int BaseAge => 1;
        public override int AgeRange => 100;
        public override int MaleBaseHeight => 66;
        public override int MaleHeightRange => 1;
        public override int MaleBaseWeight => 200;
        public override int MaleWeightRange => 6;
        public override int FemaleBaseHeight => 62;
        public override int FemaleHeightRange => 1;
        public override int FemaleBaseWeight => 180;
        public override int FemaleWeightRange => 6;
        public override int Infravision => 4;
        public override uint Choice => 0x4001;
        public override int Index => RaceId.Golem;
        public override string Description => "Golems are animated statues. Their inorganic bodies make it\nhard for them to digest food properly, but they have innate\nnatural armour and can't be stunned or made to bleed. They\nalso resist poison and can see invisible creatures. Golems\ncan learn to use their armour more efficiently (at lvl 20)\nand avoid having their life force drained (at lvl 35).";

        /// <summary>
        /// Golem 98->99->100->101->End
        /// </summary>
        public override int Chart => 98;

        public override string RacialPowersDescription(int lvl) => lvl < 20 ? "stone skin         (racial, unusable until level 20)" : "stone skin         (racial, cost 15, dur 30+d20, CON based)";
        public override bool HasRacialPowers => true;

        public override void UpdateRacialAbilities(int level, ItemCharacteristics itemCharacteristics)
        {
            itemCharacteristics.SeeInvis = true;
            itemCharacteristics.FreeAct = true;
            itemCharacteristics.ResPois = true;
            itemCharacteristics.SlowDigest = true;
            if (level > 34)
            {
                itemCharacteristics.HoldLife = true;
            }
        }
        public override string CreateRandomName() => CreateRandomNameFromSyllables(new DwarvenSyllables());
    }
}