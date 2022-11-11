using AngbandOS.Enumerations;

namespace AngbandOS.Core.Races
{
    [Serializable]
    internal class YeekRace : Race
    {
        public override string Title => "Yeek";
        public override int[] AbilityBonus => new int[] { -2, 1, 1, 1, -2, -7 };
        public override int BaseDisarmBonus => 2;
        public override int BaseDeviceBonus => 4;
        public override int BaseSaveBonus => 10;
        public override int BaseStealthBonus => 3;
        public override int BaseSearchBonus => 5;
        public override int BaseSearchFrequency => 15;
        public override int BaseMeleeAttackBonus => -5;
        public override int BaseRangedAttackBonus => -5;
        public override int HitDieBonus => 7;
        public override int ExperienceFactor => 100;
        public override int BaseAge => 14;
        public override int AgeRange => 3;
        public override int MaleBaseHeight => 50;
        public override int MaleHeightRange => 3;
        public override int MaleBaseWeight => 90;
        public override int MaleWeightRange => 6;
        public override int FemaleBaseHeight => 50;
        public override int FemaleHeightRange => 3;
        public override int FemaleBaseWeight => 75;
        public override int FemaleWeightRange => 3;
        public override int Infravision => 2;
        public override uint Choice => 0xDE0F;
        public override int Index => RaceId.Yeek;

    }
}