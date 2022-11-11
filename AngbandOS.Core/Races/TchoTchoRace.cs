using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.Races
{
    [Serializable]
    internal class TchoTchoRace : Race
    {
        public override string Title => "Tcho-Tcho";
        public override int[] AbilityBonus => new int[] { 3, -2, -1, 1, 2, -2 };
        public override int BaseDisarmBonus => -2;
        public override int BaseDeviceBonus => -10;
        public override int BaseSaveBonus => 2;
        public override int BaseStealthBonus => -1;
        public override int BaseSearchBonus => 1;
        public override int BaseSearchFrequency => 7;
        public override int BaseMeleeAttackBonus => 12;
        public override int BaseRangedAttackBonus => 10;
        public override int HitDieBonus => 11;
        public override int ExperienceFactor => 120;
        public override int BaseAge => 14;
        public override int AgeRange => 8;
        public override int MaleBaseHeight => 82;
        public override int MaleHeightRange => 5;
        public override int MaleBaseWeight => 200;
        public override int MaleWeightRange => 20;
        public override int FemaleBaseHeight => 78;
        public override int FemaleHeightRange => 6;
        public override int FemaleBaseWeight => 190;
        public override int FemaleWeightRange => 15;
        public override int Infravision => 0;
        public override uint Choice => 0xC89D;
        public override int Index => RaceId.TchoTcho;
        public override string Description => "Tcho-Tchos are hairless cannibalistic near-humans who dwell\nin isolated parts of the world away from more civilised\nplaces where their dark rituals and sacrifices go unseen.\nTcho-Tchos are immune to fear, and can also learn to create\nThe Yellow Sign (at lvl 35).";

        /// <summary>
        /// Tcho-Tcho 138->139->140->141->142->End 
        /// </summary>
        public override int Chart => 138;
    }
}