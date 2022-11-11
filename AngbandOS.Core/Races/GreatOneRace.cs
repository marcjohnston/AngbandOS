using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;
using System.Runtime.CompilerServices;

namespace AngbandOS.Core.Races
{
    [Serializable]
    internal class GreatOneRace : Race
    {
        public override string Title => "Great One";
        public override int[] AbilityBonus => new int[] { 1, 2, 2, 2, 3, 2 };
        public override int BaseDisarmBonus => 4;
        public override int BaseDeviceBonus => 5;
        public override int BaseSaveBonus => 5;
        public override int BaseStealthBonus => 2;
        public override int BaseSearchBonus => 3;
        public override int BaseSearchFrequency => 13;
        public override int BaseMeleeAttackBonus => 15;
        public override int BaseRangedAttackBonus => 10;
        public override int HitDieBonus => 10;
        public override int ExperienceFactor => 225;
        public override int BaseAge => 50;
        public override int AgeRange => 50;
        public override int MaleBaseHeight => 82;
        public override int MaleHeightRange => 5;
        public override int MaleBaseWeight => 190;
        public override int MaleWeightRange => 20;
        public override int FemaleBaseHeight => 78;
        public override int FemaleHeightRange => 6;
        public override int FemaleBaseWeight => 180;
        public override int FemaleWeightRange => 15;
        public override int Infravision => 0;
        public override uint Choice => 0xFFFF;
        public override int Index => RaceId.Great;
        public override string Description => "Great-Ones are the offspring of the petty gods that rule\nDreamlands. As such they are somewhat more than human.\nTheir constitution cannot be reduced, and they heal\nquickly. They can also learn to travel through dreams\n(at lvl 30) and restore their health (at lvl 40).";

        /// <summary>
        /// Great One 67->68->50->51->52->53->End 
        /// </summary>
        public override int Chart => 67;
    }
}