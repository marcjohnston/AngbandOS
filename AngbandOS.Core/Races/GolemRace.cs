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

    }
}