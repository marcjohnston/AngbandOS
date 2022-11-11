using AngbandOS.Enumerations;

namespace AngbandOS.Core.Races
{
    [Serializable]
    internal class DwarfRace : Race
    {
        public override string Title => "Dwarf";
        public override int[] AbilityBonus => new int[] { 2, -2, 2, -2, 2, -3 };
        public override int BaseDisarmBonus => 2;
        public override int BaseDeviceBonus => 9;
        public override int BaseSaveBonus => 10;
        public override int BaseStealthBonus => -1;
        public override int BaseSearchBonus => 7;
        public override int BaseSearchFrequency => 10;
        public override int BaseMeleeAttackBonus => 15;
        public override int BaseRangedAttackBonus => 0;
        public override int HitDieBonus => 11;
        public override int ExperienceFactor => 125;
        public override int BaseAge => 35;
        public override int AgeRange => 15;
        public override int MaleBaseHeight => 48;
        public override int MaleHeightRange => 3;
        public override int MaleBaseWeight => 150;
        public override int MaleWeightRange => 10;
        public override int FemaleBaseHeight => 46;
        public override int FemaleHeightRange => 3;
        public override int FemaleBaseWeight => 120;
        public override int FemaleWeightRange => 10;
        public override int Infravision => 5;
        public override uint Choice => 0x4805;
        public override int Index => RaceId.Dwarf;

    }
}