using AngbandOS.Enumerations;

namespace AngbandOS.Core.Races
{
    [Serializable]
    internal class HalfOrcRace : Race
    {
        public override string Title => "Half Orc";
        public override int[] AbilityBonus => new int[] { 2, -1, 0, 0, 1, -4 };
        public override int BaseDisarmBonus => -3;
        public override int BaseDeviceBonus => -3;
        public override int BaseSaveBonus => -3;
        public override int BaseStealthBonus => -1;
        public override int BaseSearchBonus => 0;
        public override int BaseSearchFrequency => 7;
        public override int BaseMeleeAttackBonus => 12;
        public override int BaseRangedAttackBonus => -5;
        public override int HitDieBonus => 10;
        public override int ExperienceFactor => 110;
        public override int BaseAge => 11;
        public override int AgeRange => 4;
        public override int MaleBaseHeight => 66;
        public override int MaleHeightRange => 1;
        public override int MaleBaseWeight => 150;
        public override int MaleWeightRange => 5;
        public override int FemaleBaseHeight => 62;
        public override int FemaleHeightRange => 1;
        public override int FemaleBaseWeight => 120;
        public override int FemaleWeightRange => 5;
        public override int Infravision => 3;
        public override uint Choice => 0x898D;
        public override int Index => RaceId.HalfOrc;
        public override string Description => "Half-Orcs are stronger than humans, and less dimwitted\ntheir orcish parentage would lead you to assume.\nHalf-Orcs are born of darkness and are resistant to that\nform of attack. They are also able to learn to shrug off\nmagical fear (at lvl 5).";

        /// <summary>
        /// Half-Orc 19->20->2->3->50->51->52->53->End
        /// </summary>
        public override int Chart => 19;
    }
}