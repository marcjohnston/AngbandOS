using AngbandOS.Enumerations;

namespace AngbandOS.Core.Races
{
    [Serializable]
    internal class HalfTrollRace : Race
    {
        public override string Title => "Half Troll";
        public override int[] AbilityBonus => new int[] { 4, -4, -2, -4, 3, -6 };
        public override int BaseDisarmBonus => -5;
        public override int BaseDeviceBonus => -8;
        public override int BaseSaveBonus => -8;
        public override int BaseStealthBonus => -2;
        public override int BaseSearchBonus => -1;
        public override int BaseSearchFrequency => 5;
        public override int BaseMeleeAttackBonus => 20;
        public override int BaseRangedAttackBonus => -10;
        public override int HitDieBonus => 12;
        public override int ExperienceFactor => 137;
        public override int BaseAge => 20;
        public override int AgeRange => 10;
        public override int MaleBaseHeight => 96;
        public override int MaleHeightRange => 10;
        public override int MaleBaseWeight => 250;
        public override int MaleWeightRange => 50;
        public override int FemaleBaseHeight => 84;
        public override int FemaleHeightRange => 8;
        public override int FemaleBaseWeight => 225;
        public override int FemaleWeightRange => 40;
        public override int Infravision => 3;
        public override uint Choice => 0x0805;
        public override int Index => RaceId.HalfTroll;

    }
}