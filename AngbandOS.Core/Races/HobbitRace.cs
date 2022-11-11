using AngbandOS.Enumerations;

namespace AngbandOS.Core.Races
{
    [Serializable]
    internal class HobbitRace : Race
    {
        public override string Title => "Hobbit";
        public override int[] AbilityBonus => new int[] { -2, 2, 1, 3, 2, 1 };
        public override int BaseDisarmBonus => 15;
        public override int BaseDeviceBonus => 18;
        public override int BaseSaveBonus => 18;
        public override int BaseStealthBonus => 5;
        public override int BaseSearchBonus => 12;
        public override int BaseSearchFrequency => 15;
        public override int BaseMeleeAttackBonus => -10;
        public override int BaseRangedAttackBonus => 20;
        public override int HitDieBonus => 7;
        public override int ExperienceFactor => 110;
        public override int BaseAge => 21;
        public override int AgeRange => 12;
        public override int MaleBaseHeight => 36;
        public override int MaleHeightRange => 3;
        public override int MaleBaseWeight => 60;
        public override int MaleWeightRange => 3;
        public override int FemaleBaseHeight => 33;
        public override int FemaleHeightRange => 3;
        public override int FemaleBaseWeight => 50;
        public override int FemaleWeightRange => 3;
        public override int Infravision => 4;
        public override uint Choice => 0xBC0B;
        public override int Index => RaceId.Hobbit;
        public override string Description => "Hobbits are small and surprisingly dextrous given their\npropensity for plumpness. They make excellent burglars\nand are adept at spell casting too. Hobbits can't have\ntheir dexterity reduced, and they can learn to put together\nnourishing meals from the barest scraps (at lvl 15).";

    }
}