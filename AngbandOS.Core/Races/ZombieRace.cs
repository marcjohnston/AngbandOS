using AngbandOS.Enumerations;

namespace AngbandOS.Core.Races
{
    [Serializable]
    internal class ZombieRace : Race
    {
        public override string Title => "Zombie";
        public override int[] AbilityBonus => new int[] { 2, -6, -6, 1, 4, -5 };
        public override int BaseDisarmBonus => -5;
        public override int BaseDeviceBonus => -5;
        public override int BaseSaveBonus => 8;
        public override int BaseStealthBonus => -1;
        public override int BaseSearchBonus => -1;
        public override int BaseSearchFrequency => 5;
        public override int BaseMeleeAttackBonus => 15;
        public override int BaseRangedAttackBonus => 0;
        public override int HitDieBonus => 13;
        public override int ExperienceFactor => 135;
        public override int BaseAge => 100;
        public override int AgeRange => 30;
        public override int MaleBaseHeight => 72;
        public override int MaleHeightRange => 6;
        public override int MaleBaseWeight => 100;
        public override int MaleWeightRange => 25;
        public override int FemaleBaseHeight => 66;
        public override int FemaleHeightRange => 4;
        public override int FemaleBaseWeight => 100;
        public override int FemaleWeightRange => 20;
        public override int Infravision => 2;
        public override uint Choice => 0x0001;
        public override int Index => RaceId.Zombie;
        public override string Description => "Zombies are undead creatures. Their decayed flesh resists\nnether and poison, and having their life force drained.\nZombies digest food slowly, and can see invisible monsters.\nThey can learn to restore their life force (at lvl 30).";

        /// <summary>
        /// Zombie 107->108->62->63->64->65->66->End
        /// </summary>
        public override int Chart => 107;

        public override string RacialPowersDescription(int lvl) => lvl < 30 ? "restore life       (racial, unusable until level 30)" : "restore life       (racial, cost 30, WIS based)";
        public override bool HasRacialPowers => true;
    }
}