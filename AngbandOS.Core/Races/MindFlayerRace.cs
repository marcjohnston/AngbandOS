﻿using AngbandOS.Core.Syllables;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.Races
{
    [Serializable]
    internal class MindFlayerRace : Race
    {
        public override string Title => "Mind Flayer";
        public override int[] AbilityBonus => new int[] { -3, 4, 4, 0, -2, -5 };
        public override int BaseDisarmBonus => 10;
        public override int BaseDeviceBonus => 25;
        public override int BaseSaveBonus => 15;
        public override int BaseStealthBonus => 2;
        public override int BaseSearchBonus => 5;
        public override int BaseSearchFrequency => 12;
        public override int BaseMeleeAttackBonus => -10;
        public override int BaseRangedAttackBonus => -5;
        public override int HitDieBonus => 9;
        public override int ExperienceFactor => 140;
        public override int BaseAge => 100;
        public override int AgeRange => 25;
        public override int MaleBaseHeight => 68;
        public override int MaleHeightRange => 6;
        public override int MaleBaseWeight => 142;
        public override int MaleWeightRange => 15;
        public override int FemaleBaseHeight => 63;
        public override int FemaleHeightRange => 6;
        public override int FemaleBaseWeight => 112;
        public override int FemaleWeightRange => 10;
        public override int Infravision => 4;
        public override uint Choice => 0xD746;
        public override int Index => RaceId.MindFlayer;
        public override string Description => "Mind-Flayers are slimy humanoids with squid-like tentacles\naround their mouths. They are all psychic, and neither\ntheir intelligence nor their wisdom can be reduced. They\ncan learn to see invisible (at lvl 15), blast people's\nminds (at lvl 15), and gain telepathy (at lvl 30).";

        /// <summary>
        /// Mind-Flayer 93->93->End
        /// </summary>
        public override int Chart => 92;

        public override string RacialPowersDescription(int lvl) => lvl < 15 ? "mind blast         (racial, unusable until level 15)" : "mind blast         (racial, cost 12, dam lvl, INT based)";
        public override bool HasRacialPowers => true;

        public override void UpdateRacialAbilities(int level, ItemCharacteristics itemCharacteristics)
        {
            itemCharacteristics.SustInt = true;
            itemCharacteristics.SustWis = true;
            if (level > 14)
            {
                itemCharacteristics.SeeInvis = true;
            }
            if (level > 29)
            {
                itemCharacteristics.Telepathy = true;
            }
        }
        public override string CreateRandomName() => CreateRandomNameFromSyllables(new CthuloidSyllables());
    }
}