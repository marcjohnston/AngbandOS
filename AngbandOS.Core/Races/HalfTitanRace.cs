using AngbandOS.Enumerations;

namespace AngbandOS.Core.Races
{
    [Serializable]
    internal class HalfTitanRace : Race
    {
        public override string Title => "Half Titan";
        public override int[] AbilityBonus => new int[] { 5, 1, 1, -2, 3, 1 };
        public override int BaseDisarmBonus => -5;
        public override int BaseDeviceBonus => 5;
        public override int BaseSaveBonus => 2;
        public override int BaseStealthBonus => -2;
        public override int BaseSearchBonus => 1;
        public override int BaseSearchFrequency => 8;
        public override int BaseMeleeAttackBonus => 25;
        public override int BaseRangedAttackBonus => 0;
        public override int HitDieBonus => 14;
        public override int ExperienceFactor => 255;
        public override int BaseAge => 100;
        public override int AgeRange => 30;
        public override int MaleBaseHeight => 111;
        public override int MaleHeightRange => 11;
        public override int MaleBaseWeight => 255;
        public override int MaleWeightRange => 86;
        public override int FemaleBaseHeight => 99;
        public override int FemaleHeightRange => 11;
        public override int FemaleBaseWeight => 250;
        public override int FemaleWeightRange => 86;
        public override int Infravision => 0;
        public override uint Choice => 0x1F27;
        public override int Index => RaceId.HalfTitan;
        public override string Description => "Half-Titans are massively strong, being descended from the\npredecessors of the gods that grew from primal chaos. This\nlegacy lets them resist damage from chaos, and half-titans\ncan learn to magically probe their foes to find out their\nstrengths and weaknesses (at lvl 35).";

        /// <summary>
        /// Half-Titan 75->20->2->3->50->51->52->53->End
        /// </summary>
        public override int Chart => 76;
    }
}