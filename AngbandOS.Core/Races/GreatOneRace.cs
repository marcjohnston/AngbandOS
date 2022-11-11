using AngbandOS.Enumerations;

namespace AngbandOS.Core.Races
{
    [Serializable]
    internal class GreatOneRace : Race
    {
        public override string Title => "Great One";
        public override int[] AbilityBonus => new int[] { 1, 2, 2, 2, 3, 2 };
        public override int BaseDisarmBonus => 4;
        public override int BaseDeviceBonus => 5;
        public override int BaseSaveBonus => 5;
        public override int BaseStealthBonus => 2;
        public override int BaseSearchBonus => 3;
        public override int BaseSearchFrequency => 13;
        public override int BaseMeleeAttackBonus => 15;
        public override int BaseRangedAttackBonus => 10;
        public override int HitDieBonus => 10;
        public override int ExperienceFactor => 225;
        public override int BaseAge => 50;
        public override int AgeRange => 50;
        public override int MaleBaseHeight => 82;
        public override int MaleHeightRange => 5;
        public override int MaleBaseWeight => 190;
        public override int MaleWeightRange => 20;
        public override int FemaleBaseHeight => 78;
        public override int FemaleHeightRange => 6;
        public override int FemaleBaseWeight => 180;
        public override int FemaleWeightRange => 15;
        public override int Infravision => 0;
        public override uint Choice => 0xFFFF;
        public override int Index => RaceId.Great;

    }
}