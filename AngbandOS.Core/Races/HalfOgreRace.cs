using AngbandOS.Enumerations;

namespace AngbandOS.Core.Races
{
    [Serializable]
    internal class HalfOgreRace : Race
    {
        public override string Title => "Half Ogre";
        public override int[] AbilityBonus => new int[] { 3, -1, -1, -1, 3, -3 };
        public override int BaseDisarmBonus => -3;
        public override int BaseDeviceBonus => -5;
        public override int BaseSaveBonus => -5;
        public override int BaseStealthBonus => -2;
        public override int BaseSearchBonus => -1;
        public override int BaseSearchFrequency => 5;
        public override int BaseMeleeAttackBonus => 20;
        public override int BaseRangedAttackBonus => 0;
        public override int HitDieBonus => 12;
        public override int ExperienceFactor => 130;
        public override int BaseAge => 40;
        public override int AgeRange => 10;
        public override int MaleBaseHeight => 92;
        public override int MaleHeightRange => 10;
        public override int MaleBaseWeight => 255;
        public override int MaleWeightRange => 60;
        public override int FemaleBaseHeight => 80;
        public override int FemaleHeightRange => 8;
        public override int FemaleBaseWeight => 235;
        public override int FemaleWeightRange => 60;
        public override int Infravision => 3;
        public override uint Choice => 0x0C07;
        public override int Index => RaceId.HalfOgre;

    }
}