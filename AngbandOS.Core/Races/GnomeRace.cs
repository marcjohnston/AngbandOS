﻿using AngbandOS.Core.Syllables;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.Races
{
    [Serializable]
    internal class GnomeRace : Race
    {
        public override string Title => "Gnome";
        public override int[] AbilityBonus => new int[] { -1, 2, 0, 2, 1, -2 };
        public override int BaseDisarmBonus => 10;
        public override int BaseDeviceBonus => 12;
        public override int BaseSaveBonus => 12;
        public override int BaseStealthBonus => 3;
        public override int BaseSearchBonus => 6;
        public override int BaseSearchFrequency => 13;
        public override int BaseMeleeAttackBonus => -8;
        public override int BaseRangedAttackBonus => 12;
        public override int HitDieBonus => 8;
        public override int ExperienceFactor => 135;
        public override int BaseAge => 50;
        public override int AgeRange => 40;
        public override int MaleBaseHeight => 42;
        public override int MaleHeightRange => 3;
        public override int MaleBaseWeight => 90;
        public override int MaleWeightRange => 6;
        public override int FemaleBaseHeight => 39;
        public override int FemaleHeightRange => 3;
        public override int FemaleBaseWeight => 75;
        public override int FemaleWeightRange => 3;
        public override int Infravision => 4;
        public override uint Choice => 0x1E0F;
        public override int Index => RaceId.Gnome;
        public override string Description => "Gnomes are small, playful, and talented at magic. However,\nthey are almost chronically incapable of taking anything\nseriously. Gnomes are constantly fidgeting and always on\nthe move, and this makes them impossible to paralyse or\nmagically slow. Gnomes are even able to learn how to \nteleport short distances (at lvl 5).";

        /// <summary>
        /// Gnome 13->14->3->50->51->52->53->End
        /// </summary>
        public override int Chart => 13;

        public override string RacialPowersDescription(int lvl) => lvl < 5 ? "teleport           (racial, unusable until level 5)" : "teleport           (racial, cost 5 + lvl/5, INT based)";
        public override bool HasRacialPowers => true;

        public override void UpdateRacialAbilities(int level, ItemCharacteristics itemCharacteristics)
        {
            itemCharacteristics.FreeAct = true;
        }
        public override string CreateRandomName() => CreateRandomNameFromSyllables(new GnomishSyllables());
    }
}