using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.Races
{
    [Serializable]
    internal abstract class Race
    {
        public abstract int[] AbilityBonus { get; }
        public abstract int AgeRange { get; }
        public abstract int BaseAge { get; }
        public abstract int BaseDeviceBonus { get; }
        public abstract int BaseDisarmBonus { get; }
        public abstract int BaseMeleeAttackBonus { get; }
        public abstract int BaseRangedAttackBonus { get; }
        public abstract int BaseSaveBonus { get; }
        public abstract int BaseSearchBonus { get; }
        public abstract int BaseSearchFrequency { get; }
        public abstract int BaseStealthBonus { get; }
        public abstract uint Choice { get; }
        public abstract int ExperienceFactor { get; }
        public abstract int FemaleBaseHeight { get; }
        public abstract int FemaleBaseWeight { get; }
        public abstract int FemaleHeightRange { get; }
        public abstract int FemaleWeightRange { get; }
        public abstract int HitDieBonus { get; }
        public abstract int Infravision { get; }
        public abstract int MaleBaseHeight { get; }
        public abstract int MaleBaseWeight { get; }
        public abstract int MaleHeightRange { get; }
        public abstract int MaleWeightRange { get; }
        public abstract string Title { get; }

        /// <summary>
        /// Returns the RaceId enumeration index for this race.  Deprecated.  Should be removed once all refactored.
        /// </summary>
        public abstract int Index { get; }

        /// <summary>
        /// Returns the description for the race.  The description is multi-line and has word-breaking macros \n built-in.  The description supports up to 6 lines.
        /// </summary>
        public abstract string Description { get; }
    }
}
