using AngbandOS.Enumerations;

namespace AngbandOS.Core.Races
{
    [Serializable]
    internal class MiriNigriRace : Race
    {
        public override string Title => "Miri Nigri";
        public override int[] AbilityBonus => new int[] { 2, -2, -1, -1, 2, -4 };
        public override int BaseDisarmBonus => -5;
        public override int BaseDeviceBonus => -2;
        public override int BaseSaveBonus => -1;
        public override int BaseStealthBonus => -1;
        public override int BaseSearchBonus => -1;
        public override int BaseSearchFrequency => 5;
        public override int BaseMeleeAttackBonus => 12;
        public override int BaseRangedAttackBonus => 5;
        public override int HitDieBonus => 11;
        public override int ExperienceFactor => 140;
        public override int BaseAge => 14;
        public override int AgeRange => 6;
        public override int MaleBaseHeight => 65;
        public override int MaleHeightRange => 6;
        public override int MaleBaseWeight => 150;
        public override int MaleWeightRange => 20;
        public override int FemaleBaseHeight => 61;
        public override int FemaleHeightRange => 6;
        public override int FemaleBaseWeight => 120;
        public override int FemaleWeightRange => 15;
        public override int Infravision => 0;
        public override uint Choice => 0xDFCF;
        public override int Index => RaceId.MiriNigri;

    }
}