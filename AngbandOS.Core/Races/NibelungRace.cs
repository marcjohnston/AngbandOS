﻿using AngbandOS.Core.Syllables;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.Races
{
    [Serializable]
    internal class NibelungRace : Race
    {
        public override string Title => "Nibelung";
        public override int[] AbilityBonus => new int[] { 1, -1, 2, 0, 2, -4 };
        public override int BaseDisarmBonus => 3;
        public override int BaseDeviceBonus => 5;
        public override int BaseSaveBonus => 10;
        public override int BaseStealthBonus => 1;
        public override int BaseSearchBonus => 5;
        public override int BaseSearchFrequency => 10;
        public override int BaseMeleeAttackBonus => 9;
        public override int BaseRangedAttackBonus => 0;
        public override int HitDieBonus => 11;
        public override int ExperienceFactor => 135;
        public override int BaseAge => 40;
        public override int AgeRange => 12;
        public override int MaleBaseHeight => 43;
        public override int MaleHeightRange => 3;
        public override int MaleBaseWeight => 92;
        public override int MaleWeightRange => 6;
        public override int FemaleBaseHeight => 40;
        public override int FemaleHeightRange => 3;
        public override int FemaleBaseWeight => 78;
        public override int FemaleWeightRange => 3;
        public override int Infravision => 5;
        public override uint Choice => 0xDC0F;
        public override int Index => RaceId.Nibelung;
        public override string Description => "Nibelungen are also known as dark dwarves and are famous\nas the makers of (often cursed) magical items. They can\nresist darkness and protect the items they are carrying\nfrom disenchantment. They can also learn to detect traps,\nstairs, and secret doors (at lvl 5).";

        /// <summary>
        /// Nibelung 87->88->18->57->58->59->60->61->End
        /// </summary>
        public override int Chart => 87;

        public override string RacialPowersDescription(int lvl) => lvl < 5 ? "detect doors+traps (racial, WIS based, unusable until level 5)" : "detect doors+traps (racial, cost 5, WIS based)";
        public override bool HasRacialPowers => true;

        public override void UpdateRacialAbilities(int level, ItemCharacteristics itemCharacteristics)
        {
            itemCharacteristics.ResDisen = true;
            itemCharacteristics.ResDark = true;
        }
        public override string CreateRandomName() => CreateRandomNameFromSyllables(new DwarvenSyllables());
    }
}