using AngbandOS.Enumerations;

namespace AngbandOS.Core.Races
{
    [Serializable]
    internal class KlackonRace : Race
    {
        public override string Title => "Klackon";
        public override int[] AbilityBonus => new int[] { 2, -1, -1, 1, 2, -2 };
        public override int BaseDisarmBonus => 10;
        public override int BaseDeviceBonus => 5;
        public override int BaseSaveBonus => 5;
        public override int BaseStealthBonus => 0;
        public override int BaseSearchBonus => -1;
        public override int BaseSearchFrequency => 10;
        public override int BaseMeleeAttackBonus => 5;
        public override int BaseRangedAttackBonus => 5;
        public override int HitDieBonus => 12;
        public override int ExperienceFactor => 135;
        public override int BaseAge => 20;
        public override int AgeRange => 3;
        public override int MaleBaseHeight => 60;
        public override int MaleHeightRange => 3;
        public override int MaleBaseWeight => 80;
        public override int MaleWeightRange => 4;
        public override int FemaleBaseHeight => 54;
        public override int FemaleHeightRange => 3;
        public override int FemaleBaseWeight => 70;
        public override int FemaleWeightRange => 4;
        public override int Infravision => 2;
        public override uint Choice => 0xC011;
        public override int Index => RaceId.Klackon;

    }
}