using AngbandOS.Enumerations;

namespace AngbandOS.Core.Races
{
    [Serializable]
    internal class DraconianRace : Race
    {
        public override string Title => "Draconian";
        public override int[] AbilityBonus => new int[] { 2, 1, 1, 1, 2, -3 };
        public override int BaseDisarmBonus => -2;
        public override int BaseDeviceBonus => 5;
        public override int BaseSaveBonus => 3;
        public override int BaseStealthBonus => 0;
        public override int BaseSearchBonus => 1;
        public override int BaseSearchFrequency => 10;
        public override int BaseMeleeAttackBonus => 5;
        public override int BaseRangedAttackBonus => 5;
        public override int HitDieBonus => 11;
        public override int ExperienceFactor => 250;
        public override int BaseAge => 75;
        public override int AgeRange => 33;
        public override int MaleBaseHeight => 76;
        public override int MaleHeightRange => 1;
        public override int MaleBaseWeight => 160;
        public override int MaleWeightRange => 5;
        public override int FemaleBaseHeight => 72;
        public override int FemaleHeightRange => 1;
        public override int FemaleBaseWeight => 130;
        public override int FemaleWeightRange => 5;
        public override int Infravision => 2;
        public override uint Choice => 0xDF57;
        public override int Index => RaceId.Draconian;

    }
}