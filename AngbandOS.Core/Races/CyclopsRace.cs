using AngbandOS.Enumerations;

namespace AngbandOS.Core.Races
{
    [Serializable]
    internal class CyclopsRace : Race
    {
        public override string Title => "Cyclops";
        public override int[] AbilityBonus => new int[] { 4, -3, -3, -3, 4, -6 };
        public override int BaseDisarmBonus => -4;
        public override int BaseDeviceBonus => -5;
        public override int BaseSaveBonus => -5;
        public override int BaseStealthBonus => -2;
        public override int BaseSearchBonus => -2;
        public override int BaseSearchFrequency => 5;
        public override int BaseMeleeAttackBonus => 20;
        public override int BaseRangedAttackBonus => 12;
        public override int HitDieBonus => 13;
        public override int ExperienceFactor => 130;
        public override int BaseAge => 50;
        public override int AgeRange => 24;
        public override int MaleBaseHeight => 92;
        public override int MaleHeightRange => 10;
        public override int MaleBaseWeight => 255;
        public override int MaleWeightRange => 60;
        public override int FemaleBaseHeight => 80;
        public override int FemaleHeightRange => 8;
        public override int FemaleBaseWeight => 235;
        public override int FemaleWeightRange => 60;
        public override int Infravision => 1;
        public override uint Choice => 0x0005;

        public override int Index => RaceId.Cyclops;

    }
}