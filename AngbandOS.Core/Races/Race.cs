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

        /// <summary>
        /// Returns the PlayerHistory (SaveGame._backgroundTable) group used to produce the backstory fragments that are joined together on character generation.  Returns
        /// default argument values for races that do not have mutant powers.
        /// </summary>
        public abstract int Chart { get; }

        /// <summary>
        /// Returns a description of the racial powers, if the race has racial powers (HasRacialPowers == true).  Returns (none), by default.
        /// </summary>
        /// <param name="lvl"></param>
        /// <returns></returns>
        public virtual string RacialPowersDescription(int lvl) => "(none)";

        /// <summary>
        /// Returns true, if the race has mutant powers.  Returns false, by default.
        /// </summary>
        public virtual bool HasRacialPowers => false;
    }
}
