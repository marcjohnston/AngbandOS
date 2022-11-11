using AngbandOS.Enumerations;

namespace AngbandOS.Core.Races
{
    [Serializable]
    internal class GnomeRace : Race
    {
        public override string Title => "Gnome";
        public override int[] AbilityBonus => new int[] { -1, 2, 0, 2, 1, -2 };
        public override int BaseDisarmBonus => 10;
        public override int BaseDeviceBonus => 12;
        public override int BaseSaveBonus => 12;
        public override int BaseStealthBonus => 3;
        public override int BaseSearchBonus => 6;
        public override int BaseSearchFrequency => 13;
        public override int BaseMeleeAttackBonus => -8;
        public override int BaseRangedAttackBonus => 12;
        public override int HitDieBonus => 8;
        public override int ExperienceFactor => 135;
        public override int BaseAge => 50;
        public override int AgeRange => 40;
        public override int MaleBaseHeight => 42;
        public override int MaleHeightRange => 3;
        public override int MaleBaseWeight => 90;
        public override int MaleWeightRange => 6;
        public override int FemaleBaseHeight => 39;
        public override int FemaleHeightRange => 3;
        public override int FemaleBaseWeight => 75;
        public override int FemaleWeightRange => 3;
        public override int Infravision => 4;
        public override uint Choice => 0x1E0F;
        public override int Index => RaceId.Gnome;

    }
}