using AngbandOS.Enumerations;

namespace AngbandOS.Core.Races
{
    [Serializable]
    internal class ElfRace : Race
    {
        public override string Title => "Elf";
        public override int[] AbilityBonus => new int[] { -1, 2, 2, 1, -2, 2 };
        public override int BaseDisarmBonus => 5;
        public override int BaseDeviceBonus => 6;
        public override int BaseSaveBonus => 6;
        public override int BaseStealthBonus => 2;
        public override int BaseSearchBonus => 8;
        public override int BaseSearchFrequency => 12;
        public override int BaseMeleeAttackBonus => -5;
        public override int BaseRangedAttackBonus => 15;
        public override int HitDieBonus => 8;
        public override int ExperienceFactor => 120;
        public override int BaseAge => 75;
        public override int AgeRange => 75;
        public override int MaleBaseHeight => 60;
        public override int MaleHeightRange => 4;
        public override int MaleBaseWeight => 100;
        public override int MaleWeightRange => 6;
        public override int FemaleBaseHeight => 54;
        public override int FemaleHeightRange => 4;
        public override int FemaleBaseWeight => 80;
        public override int FemaleWeightRange => 6;
        public override int Infravision => 3;
        public override uint Choice => 0xFF5F;
        public override int Index => RaceId.Elf;
        public override string Description => "Elves are creatures of the woods, and cultivate a symbiotic\nrelationship with trees. While not the sturdiest of races,\nthey are dextrous and have excellent mental faculties.\nBecause they are partially photosynthetic, elves are able\nto resist light based attacks.";

    }
}