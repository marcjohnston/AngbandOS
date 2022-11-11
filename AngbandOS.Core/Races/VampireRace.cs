using AngbandOS.Enumerations;

namespace AngbandOS.Core.Races
{
    [Serializable]
    internal class VampireRace : Race
    {
        public override string Title => "Vampire";
        public override int[] AbilityBonus => new int[] { 3, 3, -1, -1, 1, 2 };
        public override int BaseDisarmBonus => 4;
        public override int BaseDeviceBonus => 10;
        public override int BaseSaveBonus => 10;
        public override int BaseStealthBonus => 4;
        public override int BaseSearchBonus => 1;
        public override int BaseSearchFrequency => 8;
        public override int BaseMeleeAttackBonus => 5;
        public override int BaseRangedAttackBonus => 0;
        public override int HitDieBonus => 11;
        public override int ExperienceFactor => 200;
        public override int BaseAge => 100;
        public override int AgeRange => 30;
        public override int MaleBaseHeight => 72;
        public override int MaleHeightRange => 6;
        public override int MaleBaseWeight => 180;
        public override int MaleWeightRange => 25;
        public override int FemaleBaseHeight => 66;
        public override int FemaleHeightRange => 4;
        public override int FemaleBaseWeight => 150;
        public override int FemaleWeightRange => 20;
        public override int Infravision => 5;
        public override uint Choice => 0xFFFF;
        public override int Index => RaceId.Vampire;
        public override string Description => "Vampires are powerful undead. They resist darkness, nether,\ncold, poison, and having their life force drained. Vampires\nproduce their own ethereal light in the dark, but are hurt\nby direct sunlight. They can learn to drain the life force\nfrom their foes (at lvl 2).";

    }
}