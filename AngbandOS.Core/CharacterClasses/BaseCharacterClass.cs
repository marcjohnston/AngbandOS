namespace AngbandOS.Core.CharacterClasses
{
    [Serializable]
    internal abstract class BaseCharacterClass
    {
        protected SaveGame SavedGame { get; }
        protected BaseCharacterClass(SaveGame savedGame)
        {
            SavedGame = savedGame;
        }

        /// <summary>
        /// Returns the deprecated CharacterClass constant for backwards compatibility.
        /// </summary>
        /// <value>The identifier.</value>
        public abstract int ID { get; }

        public abstract int[] AbilityBonus { get; }

        public abstract int BaseDeviceBonus { get; }

        public abstract int BaseDisarmBonus { get; }

        public abstract int BaseMeleeAttackBonus { get; }

        public abstract int BaseRangedAttackBonus { get; }

        public abstract int BaseSaveBonus { get; }

        public abstract int BaseSearchBonus { get; }

        public abstract int BaseSearchFrequency { get; }

        public abstract int BaseStealthBonus { get; }

        public abstract int DeviceBonusPerLevel { get; }

        public abstract int DisarmBonusPerLevel { get; }

        public abstract int ExperienceFactor { get; }

        public abstract int HitDieBonus { get; }

        public abstract int MeleeAttackBonusPerLevel { get; }

        public abstract int RangedAttackBonusPerLevel { get; }

        public abstract int SaveBonusPerLevel { get; }

        public abstract int SearchBonusPerLevel { get; }

        public abstract int SearchFrequencyPerLevel { get; }

        public abstract int StealthBonusPerLevel { get; }

        public abstract string Title { get; }

        public virtual string ClassSubName(Realm realm) => Title;
        public abstract int PrimeStat { get; }

        public abstract string[] Info { get; }
    }
}
