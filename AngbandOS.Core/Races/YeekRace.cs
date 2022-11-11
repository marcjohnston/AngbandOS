using AngbandOS.Enumerations;

namespace AngbandOS.Core.Races
{
    [Serializable]
    internal class YeekRace : Race
    {
        public override string Title => "Yeek";
        public override int[] AbilityBonus => new int[] { -2, 1, 1, 1, -2, -7 };
        public override int BaseDisarmBonus => 2;
        public override int BaseDeviceBonus => 4;
        public override int BaseSaveBonus => 10;
        public override int BaseStealthBonus => 3;
        public override int BaseSearchBonus => 5;
        public override int BaseSearchFrequency => 15;
        public override int BaseMeleeAttackBonus => -5;
        public override int BaseRangedAttackBonus => -5;
        public override int HitDieBonus => 7;
        public override int ExperienceFactor => 100;
        public override int BaseAge => 14;
        public override int AgeRange => 3;
        public override int MaleBaseHeight => 50;
        public override int MaleHeightRange => 3;
        public override int MaleBaseWeight => 90;
        public override int MaleWeightRange => 6;
        public override int FemaleBaseHeight => 50;
        public override int FemaleHeightRange => 3;
        public override int FemaleBaseWeight => 75;
        public override int FemaleWeightRange => 3;
        public override int Infravision => 2;
        public override uint Choice => 0xDE0F;
        public override int Index => RaceId.Yeek;
        public override string Description => "Yeeks are long-eared furry creatures that look vaguely\nlike humanoid rabbits. Although physically weak, they make\npassable spell casters. They are resistant to acid, and can\nlearn to scream to terrify their foes (at lvl 15) and\nbecome completely immune to acid (at lvl 20).";

        /// <summary>
        /// Yeek 78->79->80->81->135->136->137->End
        /// </summary>
        public override int Chart => 78;
    }
}