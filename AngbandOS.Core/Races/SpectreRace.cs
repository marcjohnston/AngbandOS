﻿using AngbandOS.Core.Syllables;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.Races
{
    [Serializable]
    internal class SpectreRace : Race
    {
        public override string Title => "Spectre";
        public override int[] AbilityBonus => new int[] { -5, 4, 4, 2, -3, -6 };
        public override int BaseDisarmBonus => 10;
        public override int BaseDeviceBonus => 25;
        public override int BaseSaveBonus => 20;
        public override int BaseStealthBonus => 5;
        public override int BaseSearchBonus => 5;
        public override int BaseSearchFrequency => 14;
        public override int BaseMeleeAttackBonus => -15;
        public override int BaseRangedAttackBonus => -5;
        public override int HitDieBonus => 7;
        public override int ExperienceFactor => 180;
        public override int BaseAge => 100;
        public override int AgeRange => 30;
        public override int MaleBaseHeight => 72;
        public override int MaleHeightRange => 6;
        public override int MaleBaseWeight => 100;
        public override int MaleWeightRange => 25;
        public override int FemaleBaseHeight => 66;
        public override int FemaleHeightRange => 4;
        public override int FemaleBaseWeight => 100;
        public override int FemaleWeightRange => 20;
        public override int Infravision => 5;
        public override uint Choice => 0x5F4E;
        public override int Index => RaceId.Spectre;
        public override string Description => "Spectres are ethereal and they can pass through walls and\nother obstacles. They resist nether, attacks, poison, and\ncold; and they need little food. They also resist having\ntheir life force drained and can see invisible creatures.\nFinally, they glow with their own light, can learn to\nscare monsters (at lvl 4) and gain telepathy (at lvl 35).";

        /// <summary>
        /// Spectre 118->119->134->120->121->122->123->End
        /// </summary>
        public override int Chart => 118;

        public override string RacialPowersDescription(int lvl) => lvl < 4 ? "scare monster      (racial, unusable until level 4)" : "scare monster      (racial, cost 3, INT based)";
        public override bool HasRacialPowers => true;
        public override void UpdateRacialAbilities(int level, ItemCharacteristics itemCharacteristics)
        {
            itemCharacteristics.ResCold = true;
            itemCharacteristics.SeeInvis = true;
            itemCharacteristics.HoldLife = true;
            itemCharacteristics.ResNether = true;
            itemCharacteristics.ResPois = true;
            itemCharacteristics.SlowDigest = true;
            itemCharacteristics.Lightsource = true;
            if (level > 34)
            {
                itemCharacteristics.Telepathy = true;
            }
        }
        public override string CreateRandomName() => CreateRandomNameFromSyllables(new HumanSyllables());
    }
}